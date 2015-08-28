using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace CooQ
{
  /// <summary>
  /// Transaction - Used to execute queries inside a database transaction
  /// 
  /// </summary>
  public sealed class Transaction : IDisposable
  {
    private static readonly object sLockObject = 0;
    /// <summary>
    /// Counter used to give each transaction a unique id mainly for debugging purposes
    /// 
    /// </summary>
    private static ulong COUNTER = 0UL;
    private static Dictionary<Thread, Transaction> FORCE_THREAD_DIC = new Dictionary<Thread, Transaction>();
    private bool hasBeenCommitted = false;
    private bool hasBeenRolledBack = false;
    private readonly ulong mId;
    private readonly IsolationLevel isolationLevel;
    private readonly DatabaseBase database;
    private DbConnection dbConnection;
    private DbTransaction dbTransaction;
    private Thread forceThread;
    private bool rollbackOnly;

    /// <summary>
    /// Transaction id. Used for debugging what transactions are being used to execute queries.
    /// 
    /// </summary>
    public ulong Id
    {
      get
      {
        return this.mId;
      }
    }

    public DatabaseBase Database
    {
      get
      {
        return this.database;
      }
    }

    /// <summary>
    /// Isolation level of transaction
    /// 
    /// </summary>
    public IsolationLevel IsolationLevel
    {
      get
      {
        return this.isolationLevel;
      }
    }

    /// <summary>
    /// Actual ado database transaction object. Only set once transaction has been used.
    /// 
    /// </summary>
    internal DbTransaction DbTransaction
    {
      get
      {
        return this.dbTransaction;
      }
    }

    /// <summary>
    /// Fired when commit is performed on the transaction
    /// 
    /// </summary>
    public event Transaction.CommitPerformed CommitEvent = () => {};

    public event Transaction.RollbackPerformed RollbackEvent = () => {};

    /// <summary>
    /// Creates a transaction with Read Committed isolation level
    /// 
    /// </summary>
    /// 

    public Transaction()
      : this(DatabaseProvider.INSTANCE, IsolationLevel.ReadCommitted, false)
    {
    }

    public Transaction(DatabaseBase database)
      : this(database, IsolationLevel.ReadCommitted, false)
    {
    }

    public Transaction(DatabaseBase database, IsolationLevel pIsolationLevel)
      : this(database, pIsolationLevel, false)
    {
    }

    public Transaction(IsolationLevel pIsolationLevel)
      : this(DatabaseProvider.INSTANCE, pIsolationLevel, false)
    {
    }

    /// <summary>
    /// Creates a transaction
    /// 
    /// </summary>
    /// <param name="pIsolationLevel"/><param name="pForceUseOnThread">Checks that on the current thread only this transaction is used for queries until either commit or rollback are called.</param>
    public Transaction(DatabaseBase database, IsolationLevel pIsolationLevel, bool pForceUseOnThread)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      this.database = database;
      this.mId = Transaction.GetNextId();
      this.isolationLevel = pIsolationLevel;
      if (!pForceUseOnThread)
        return;
      Transaction.RegisterForceThread(this);
    }

    public Transaction(IsolationLevel pIsolationLevel, bool pForceUseOnThread)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      this.database = DatabaseProvider.INSTANCE;
      this.mId = Transaction.GetNextId();
      this.isolationLevel = pIsolationLevel;
      if (!pForceUseOnThread)
        return;
      Transaction.RegisterForceThread(this);
    }

    /// <summary>
    /// Gets a new transaction id
    /// 
    /// </summary>
    /// 
    /// <returns/>
    private static ulong GetNextId()
    {
      lock (Transaction.sLockObject)
      {
        if ((long) Transaction.COUNTER == -1L)
          Transaction.COUNTER = 0UL;
        checked { ++Transaction.COUNTER; }
        return Transaction.COUNTER;
      }
    }

    private static void RegisterForceThread(Transaction transaction)
    {
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      lock (Transaction.FORCE_THREAD_DIC)
      {
        if (Transaction.FORCE_THREAD_DIC.ContainsKey(Thread.CurrentThread))
          throw new Exception("Cannot create transaction as this thread is being forced to use another transaction");
        Transaction.FORCE_THREAD_DIC.Add(Thread.CurrentThread, transaction);
        transaction.forceThread = Thread.CurrentThread;
      }
    }

    private static void CheckForceThread(Transaction transaction)
    {
      lock (Transaction.FORCE_THREAD_DIC)
      {
        if (Transaction.FORCE_THREAD_DIC.Count > 0 && Transaction.FORCE_THREAD_DIC.ContainsKey(Thread.CurrentThread) && (transaction == null || (long) Transaction.FORCE_THREAD_DIC[Thread.CurrentThread].mId != (long) transaction.mId))
          throw new Exception("Cannot create connection on this thread as it is being forced to use another transaction");
      }
    }

    private static void ReleaseForceThread(Transaction transaction)
    {
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      lock (Transaction.FORCE_THREAD_DIC)
      {
        if (transaction.forceThread == null)
          return;
        Transaction.FORCE_THREAD_DIC.Remove(transaction.forceThread);
      }
    }

    internal DbConnection GetOrSetConnection(DatabaseBase database)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      if (this.database != null && this.database != database)
        throw new Exception("Transaction connecting was opened using a different database class. All queries used within a transaction must have tables using the same DatabaseBase class.");
      lock (this)
      {
        if (this.dbConnection == null)
          this.dbConnection = database.GetConnection(false);
        return this.dbConnection;
      }
    }

    internal DbTransaction GetOrSetDbTransaction(DatabaseBase database)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      lock (this)
      {
        if (this.database != null && this.database != database)
          throw new Exception("Transaction connecting was opened using a different database class. All queries used within a transaction must have tables using the same DatabaseBase class.");
        if (this.dbConnection == null)
          this.GetOrSetConnection(database);
        if (this.dbTransaction == null)
          this.dbTransaction = this.dbConnection.BeginTransaction(this.isolationLevel);
        return this.dbTransaction;
      }
    }

    internal static DbCommand CreateCommand(DbConnection dbConnection, Transaction transaction)
    {
      if (dbConnection == null)
        throw new NullReferenceException("dbConnection cannot be null");
      Transaction.CheckForceThread(transaction);
      lock (dbConnection)
        return dbConnection.CreateCommand();
    }

    /// <summary>
    /// Stop the transaction from being committed. If Commit() is called and exception will be thrown
    /// 
    /// </summary>
    public void SetRollbackOnly()
    {
      this.rollbackOnly = true;
    }

    /// <summary>
    /// Commits transaction
    /// 
    /// </summary>
    public void Commit()
    {
      lock (this)
      {
        Transaction.ReleaseForceThread(this);
        if (this.hasBeenCommitted)
          throw new Exception("Transaction has already been committed");
        this.hasBeenCommitted = true;
        if (this.hasBeenRolledBack)
          throw new Exception("Transaction has already been rolled back");
        if (this.dbTransaction == null)
          return;
        if (this.rollbackOnly)
          throw new Exception("Transaction has been set so that it can only be rolled back");
        try
        {
          using (this.dbTransaction.Connection)
          {
            this.dbTransaction.Commit();
            if (this.CommitEvent != null)
            {
              this.CommitEvent();
              this.CommitEvent = (Transaction.CommitPerformed) null;
            }
          }
        }
        finally
        {
          this.dbTransaction = (DbTransaction) null;
        }
      }
    }

    /// <summary>
    /// Rollback transaction
    /// 
    /// </summary>
    public void Rollback()
    {
      Transaction.ReleaseForceThread(this);
      if (this.hasBeenRolledBack)
        throw new Exception("Transaction has already been rolled back");
      this.hasBeenRolledBack = true;
      if (this.dbTransaction == null)
      {
        if (this.RollbackEvent == null)
          return;
        this.RollbackEvent();
        this.RollbackEvent = (Transaction.RollbackPerformed) null;
      }
      else
      {
        try
        {
          using (this.dbTransaction.Connection)
          {
            using (this.dbTransaction)
            {
              if (this.dbTransaction.Connection != null && this.dbTransaction.Connection.State != ConnectionState.Closed && this.dbTransaction.Connection.State != ConnectionState.Broken)
                this.dbTransaction.Rollback();
            }
          }
        }
        finally
        {
          try
          {
            if (this.RollbackEvent != null)
            {
              this.RollbackEvent();
              this.RollbackEvent = (Transaction.RollbackPerformed) null;
            }
          }
          catch
          {
          }
        }
      }
    }

    /// <summary>
    /// Rolls back transaction if not committed
    /// 
    /// </summary>
    public void Dispose()
    {
      if (this.hasBeenCommitted || this.hasBeenRolledBack)
        return;
      this.Rollback();
    }

    public delegate void CommitPerformed();

    /// <summary>
    /// Called when rollback is performed on transaction
    /// 
    /// </summary>
    public delegate void RollbackPerformed();
  }
}
