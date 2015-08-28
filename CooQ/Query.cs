using CooQ.Builder;
using CooQ.Core;
using CooQ.Database;
using CooQ.Database.Mssql;
using CooQ.Database.PostgreSql;
using CooQ.Generate;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CooQ
{
  public static partial class Query
  {
    private static readonly Logs.Logger LOG = Logs.LogFactory.GetLog(typeof(Query));
    internal readonly static IDictionary<DatabaseType, ISchemaProvider> SCHEMA_PROVIDERS;
    static Query()
    {
      SCHEMA_PROVIDERS = new Dictionary<DatabaseType, ISchemaProvider>();
      SCHEMA_PROVIDERS.Add(DatabaseType.MSSQL, new CooQ.Database.Mssql.MssqlSchemaProvider());
      SCHEMA_PROVIDERS.Add(DatabaseType.POSTGRESQL, new CooQ.Database.PostgreSql.PostgresSchemaProvider());
      Settings.ExecutorExecuted += Settings_ExecutorExecuted;
      Settings.ExecutorExecuting += Settings_ExecutorExecuting;
      Settings.QueryExecuting += Settings_QueryExecuting;
      Settings.QueryPerformed += Settings_QueryPerformed;
    }

    /// <summary>
    /// Init config for system
    /// </summary>
    /// <param name="setting"></param>
    public static void Init(ConnectionSetting setting)
    {
      DatabaseProvider.Config(setting);
      QueryExecutor.Init(setting);
    }

    public static Boolean IsConnected()
    {
      var con = DatabaseProvider.INSTANCE.GetConnection(true);
      if (con != null)
      {
        con.Close();
      }
      return true;
    }

    #region Handle event
    static void Settings_QueryPerformed(DatabaseBase database, string pSql, int records, QueryType pQueryType,
      DateTime? pStart, DateTime? pEnd, Exception pException, IsolationLevel pIsolationLevel, int? pResultSize, ulong? transactionId)
    {
      if (pException == null)
      {
        LOG.Debug("End: start:{0:MM-dd-yy HH:mm:ss.fff}, end:{1:MM-dd-yy HH:mm:ss.fff}, rows affected:{2}", pStart, pEnd, records);
      }
      else
      {
        LOG.Error(string.Format("End: start:{0}, end:{1}, ERROR:{2}", pStart, pEnd, pException.Message), pException);
      }
    }

    static void Settings_QueryExecuting(DatabaseBase database, string pSql, QueryType pQueryType, DateTime? pStart, IsolationLevel pIsolationLevel, ulong? transactionId)
    {
      LOG.Debug("Begin: start:{0}, query:{1}", pStart, pSql);
    }

    static void Settings_ExecutorExecuting(string query, CommandType type)
    {
      LOG.Debug("Beign with cmdType, query:{0}", query);
    }

    static void Settings_ExecutorExecuted(string message)
    {
      LOG.Debug("End with cmdType message: {0}", message);
    }
    #endregion

    /// <summary>
    /// Select query
    /// 
    /// </summary>
    /// <param name="pField">Column, table or function to select. Cannot be null.</param><param name="pFields">Column, table or function to select</param>
    /// <returns/>
    public static IDistinct Select(ISelectableColumns pField, params ISelectableColumns[] pFields)
    {
      if (pField == null)
        throw new NullReferenceException("pField cannot be null");
      List<ISelectable> list = new List<ISelectable>();
      list.AddRange((IEnumerable<ISelectable>)pField.SelectableColumns);
      foreach (ISelectableColumns selectableColumns in pFields)
        list.AddRange((IEnumerable<ISelectable>)selectableColumns.SelectableColumns);
      return (IDistinct)new QueryBuilderBase(list.ToArray());
    }

    /// <summary>
    /// Insert query
    /// 
    /// </summary>
    /// <param name="table">Insert into table</param>
    /// <returns/>
    public static IInsert Insert(TableBase table)
    {
      return (IInsert)new InsertBuilder(table);
    }

    /// <summary>
    /// Insert select query
    /// 
    /// </summary>
    /// <param name="table"/>
    /// <returns/>
    public static IInsertSelect InsertSelect(TableBase table)
    {
      return (IInsertSelect)new InsertSelectBuilder(table);
    }

    /// <summary>
    /// Update query
    /// 
    /// </summary>
    /// <param name="table">Update table</param>
    /// <returns/>
    public static IUpdate Update(TableBase table)
    {
      return (IUpdate)new UpdateBuilder(table);
    }

    /// <summary>
    /// Delete query
    /// 
    /// </summary>
    /// <param name="table">Delete table</param>
    /// <returns/>
    public static IDelete Delete(TableBase table)
    {
      return (IDelete)new DeleteBuilder(table);
    }

    /// <summary>
    /// Truncate table query
    /// 
    /// </summary>
    /// <param name="table">Table to be truncated</param>
    /// <returns/>
    public static ITruncateTimeout Truncate(TableBase table)
    {
      return (ITruncateTimeout)new TruncateBuilder(table);
    }

    /// <summary>
    /// Gets sql to execute stored procedure
    /// 
    /// </summary>
    /// <param name="pSP"/><param name="transaction"/><param name="parameters"/>
    /// <returns/>
    public static string GetSpSql(TableBase pSP, Transaction transaction, params object[] parameters)
    {
      if (pSP == null)
        throw new NullReferenceException("pSP cannot be null");
      if (transaction.Database.DatabaseType != DatabaseType.MSSQL)
        throw new Exception("Stored procedures are only implemented for DatabaseType.Mssql. Not " + transaction.Database.DatabaseType.ToString());
      return new MssqlQueryBuilder().GetStoreProcedureQuery(transaction.Database, pSP, (Parameters)null, parameters);
    }

    /// <summary>
    /// Executes stored procedure.
    /// 
    /// </summary>
    /// <param name="pSP">Stored procedure</param><param name="transaction">Transaction</param><param name="parameters">Parameters being passed to stored procedure</param>
    /// <returns/>
    public static IResult ExecuteSP(TableBase pSP, Transaction transaction, params object[] parameters)
    {
      if (pSP == null)
        throw new NullReferenceException("pSP cannot be null");
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      if (transaction.Database.DatabaseType != DatabaseType.MSSQL)
        throw new Exception("Stored procedures are only implemented for DatabaseType.Mssql. Not " + transaction.Database.DatabaseType.ToString());
      DbConnection dbConnection = (DbConnection)null;
      string pSql = string.Empty;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      try
      {
        dbConnection = transaction.GetOrSetConnection(transaction.Database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          Parameters pParameters1 = Settings.UseParameters ? new Parameters(command) : (Parameters)null;
          pSql = QueryBuilderFactory.GetStoreProcedureQuery(transaction.Database, pSP, pParameters1, parameters);
          command.CommandText = pSql;
          command.CommandType = CommandType.Text;
          if (transaction != null)
            command.Transaction = transaction.GetOrSetDbTransaction(transaction.Database);
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(transaction.Database, pSql, QueryType.StoredProc, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          using (DbDataReader dataReader = command.ExecuteReader())
          {
            pEnd = new DateTime?(DateTime.Now);
            IList<ISelectable> pSelectColumns = (IList<ISelectable>)new List<ISelectable>(pSP.Columns.Count);
            foreach (ColumnBase ColumnBase in (IEnumerable<ColumnBase>)pSP.Columns)
              pSelectColumns.Add((ISelectable)ColumnBase);
            QueryResult queryResult = new QueryResult(transaction.Database, pSelectColumns, dataReader, command.CommandText);
            if (transaction == null)
              dbConnection.Close();
            Settings.FireQueryPerformedEvent(transaction.Database, pSql, queryResult.Count, QueryType.StoredProc, pStart, pEnd, (Exception)null, transaction.IsolationLevel, (IResult)queryResult, new ulong?(transaction.Id));
            return (IResult)queryResult;
          }
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, pSql, 0, QueryType.StoredProc, pStart, pEnd, ex, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
        throw;
      }
    }

    /// <summary>
    /// Executes non query in pSql
    /// 
    /// </summary>
    /// <param name="pSql">Plain text sql query to be executed</param><param name="database">Database to execute query on</param><param name="transaction">Transaction to execute query in</param>
    /// <returns/>
    public static int ExecuteNonQuery(string pSql, DatabaseBase database, Transaction transaction)
    {
      if (string.IsNullOrWhiteSpace(pSql))
        throw new Exception("pSql cannot be null or empty");
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      DbConnection dbConnection = (DbConnection)null;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      try
      {
        dbConnection = transaction.GetOrSetConnection(database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          command.CommandText = pSql;
          command.CommandType = CommandType.Text;
          if (transaction != null)
            command.Transaction = transaction.GetOrSetDbTransaction(database);
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(database, pSql, QueryType.PlainText, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          int records = command.ExecuteNonQuery();
          pEnd = new DateTime?(DateTime.Now);
          Settings.FireQueryPerformedEvent(database, pSql, records, QueryType.PlainText, pStart, pEnd, (Exception)null, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
          return records;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(database, pSql, 0, QueryType.PlainText, pStart, pEnd, ex, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
        throw;
      }
    }

   #region Factory    

    /// <summary>
    /// Get current connection inited
    /// </summary>
    /// <returns></returns>
    public static DbConnection GetConnection()
    {
      return GetConnection(DatabaseProvider.INSTANCE.Setting.Type, DatabaseProvider.INSTANCE.ConnectionString);
    }

    /// <summary>
    /// Get connection with databaseType and given connection string
    /// </summary>
    /// <param name="type"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static DbConnection GetConnection(DatabaseType type, String connectionString)
    {
      DbConnection connection = null;
      switch (type)
      {
        case CooQ.Types.DatabaseType.MSSQL:
          connection = new System.Data.SqlClient.SqlConnection(connectionString);
          break;
        case CooQ.Types.DatabaseType.POSTGRESQL:
          connection = new Npgsql.NpgsqlConnection(connectionString);
          break;
      }
      return connection;
    }
    #endregion
  }
}
