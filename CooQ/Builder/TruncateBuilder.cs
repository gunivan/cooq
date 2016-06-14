using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Data;
using System.Data.Common;

namespace CooQ.Builder
{
  internal class TruncateBuilder : ITruncateTimeout, ITrucateExecute
  {
    private readonly TableBase mTable;
    private int? mTimeout;

    internal TableBase Table
    {
      get
      {
        return this.mTable;
      }
    }

    internal TruncateBuilder(TableBase table)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      this.mTable = table;
    }

    public ITrucateExecute Timeout(int pTimeout)
    {
      if (pTimeout < 0)
        throw new Exception("pTimeout cannot be less than 0. Value = " + pTimeout.ToString());
      this.mTimeout = new int?(pTimeout);
      return (ITrucateExecute) this;
    }

    public string GetSql()
    {                                                                         
      return QueryBuilderFactory.GetTruncateQuery(DatabaseProvider.INSTANCE, this.mTable);
    }

    public string GetSql(DatabaseBase database)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null or empty");
      return QueryBuilderFactory.GetTruncateQuery(database, this.mTable);
    }

    public int Execute()
    {
      int res;
      using (var tran = new Transaction(DatabaseProvider.INSTANCE))
      {
        res = Execute(tran);
        tran.Commit();
      }

      return res;
    }

    public int Execute(Transaction transaction)
    {
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      string sql = this.GetSql(transaction.Database);
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      DbConnection dbConnection = (DbConnection) null;
      try
      {
        dbConnection = transaction.GetOrSetConnection(transaction.Database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          command.CommandText = sql;
          command.CommandType = CommandType.Text;
          command.CommandTimeout = this.mTimeout.HasValue ? this.mTimeout.Value : Settings.DefaultTimeout;
          command.Transaction = transaction.GetOrSetDbTransaction(transaction.Database);
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(transaction.Database, sql, QueryType.Truncate, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          int records = command.ExecuteNonQuery();
          pEnd = new DateTime?(DateTime.Now);
          Settings.FireQueryPerformedEvent(transaction.Database, sql, records, QueryType.Truncate, pStart, pEnd, (Exception) null, transaction.IsolationLevel, (IResult) null, new ulong?(transaction.Id));
          return records;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, sql, 0, QueryType.Truncate, pStart, pEnd, ex, transaction.IsolationLevel, (IResult) null, new ulong?(transaction.Id));
        throw;
      }
    }
  }
}
