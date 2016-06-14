using CooQ.Core;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Data;
using System.Data.Common;

namespace CooQ.Builder
{
  internal class InsertSelectBuilder : IInsertSelect, IInsertSelectQuery, IInsertSelectExecute
  {
    private readonly TableBase mTable;
    private ColumnBase[] mColumns;
    private IExecute mSelectQuery;

    internal TableBase Table
    {
      get
      {
        return this.mTable;
      }
    }

    internal ColumnBase[] InsertColumns
    {
      get
      {
        return this.mColumns;
      }
    }

    internal IExecute SelectQuery
    {
      get
      {
        return this.mSelectQuery;
      }
    }

    public InsertSelectBuilder(TableBase table)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      this.mTable = table;
    }

    public IInsertSelectQuery Columns(params ColumnBase[] columns)
    {
      if (columns == null)
        throw new NullReferenceException("columns cannot be null");
      if (columns.Length == 0)
        throw new Exception("columns cannot be empty");
      this.mColumns = columns;
      return this;
    }

    public IInsertSelectExecute Query(IExecute selectQuery)
    {
      if (selectQuery == null)
        throw new NullReferenceException("selectQuery cannot be null");
      this.mSelectQuery = selectQuery;
      return this;
    }

    public string GetSql()
    {
      return QueryBuilderFactory.GetInsertSelectQuery(DatabaseProvider.INSTANCE, this, (Parameters)null);
    }

    public string GetSql(DatabaseBase database)
    {
      return QueryBuilderFactory.GetInsertSelectQuery(database, this, (Parameters)null);
    }

    private string GetSql(DatabaseBase database, Parameters parameters)
    {
      return QueryBuilderFactory.GetInsertSelectQuery(database, this, parameters);
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
      DbConnection dbConnection = (DbConnection)null;
      string pSql = string.Empty;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      try
      {
        dbConnection = transaction.GetOrSetConnection(transaction.Database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          Parameters parameters = Settings.UseParameters ? new Parameters(command) : (Parameters)null;
          pSql = this.GetSql(transaction.Database, parameters);
          command.CommandText = pSql;
          command.CommandType = CommandType.Text;
          command.CommandTimeout = Settings.DefaultTimeout;
          command.Transaction = transaction.GetOrSetDbTransaction(transaction.Database);
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(transaction.Database, pSql, QueryType.Insert, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          int records = command.ExecuteNonQuery();
          pEnd = new DateTime?(DateTime.Now);
          Settings.FireQueryPerformedEvent(transaction.Database, pSql, records, QueryType.Insert, pStart, pEnd, (Exception)null, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
          return records;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, pSql, 0, QueryType.Insert, pStart, pEnd, ex, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
        throw;
      }
    }
  }
}
