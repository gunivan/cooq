using CooQ.Conditions;
using CooQ.Core;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CooQ.Builder
{
  internal class DeleteBuilder : IDelete, IDeleteUseParams, IDeleteTimeout, IDeleteReturning, IDeleteExecute
  {
    private bool? mUseParameters = new bool?();
    private int? mTimeout = new int?();
    private readonly TableBase mTable;
    private Condition mWhereCondition;

    public TableBase Table
    {
      get
      {
        return this.mTable;
      }
    }

    public Condition WhereCondition
    {
      get
      {
        return this.mWhereCondition;
      }
    }

    public ColumnBase[] ReturnColumns { get; private set; }

    public IDeleteUseParams NoWhereCondition
    {
      get
      {
        return this;
      }
    }

    internal DeleteBuilder(TableBase table)
    {
      if (table == null)
        throw new CooqDataException.CooqPreconditionException("table cannot be null");
      this.mTable = table;
    }

    public IDeleteUseParams Where(Condition condition)
    {
      if (condition == null)
        throw new CooqDataException.CooqPreconditionException("condition cannot be null");
      this.mWhereCondition = condition;
      return this;
    }

    public IDeleteTimeout UseParameters(bool useParameters)
    {
      this.mUseParameters = new bool?(useParameters);
      return this;
    }

    public IDeleteReturning Timeout(int seconds)
    {
      if (seconds < 0)
        throw new CooqDataException.CooqPreconditionException("seconds must be >= 0. seconds = " + seconds.ToString());
      this.mTimeout = new int?(seconds);
      return this;
    }

    public IDeleteExecute Returning(params ColumnBase[] columns)
    {
      if (columns == null)
        throw new CooqDataException.CooqPreconditionException("columns cannot be null");
      if (columns.Length == 0)
        throw new CooqDataException.CooqPreconditionException("columns cannot be empty");
      this.ReturnColumns = columns;
      return this;
    }

    public string GetSql()
    {    
      return QueryBuilderFactory.GetDeleteQuery(DatabaseProvider.INSTANCE, this, null);
    }

    public string GetSql(DatabaseBase database)
    {
      if (database == null)
        throw new CooqDataException.CooqPreconditionException("database cannot be null");
      return QueryBuilderFactory.GetDeleteQuery(database, this, null);
    }

    private string GetSql(DatabaseBase database, Parameters parameters)
    {
      if (database == null)
        throw new CooqDataException.CooqPreconditionException("database cannot be null");
      return QueryBuilderFactory.GetDeleteQuery(database, this, parameters);
    }

    public IResult Execute()
    {
      IResult res;
      using (var tran = new Transaction(DatabaseProvider.INSTANCE))
      {
        res = Execute(tran);
        tran.Commit();
      }
      return res;
    }

    public IResult Execute(Transaction transaction)
    {
      if (transaction == null)
        throw new CooqDataException.CooqPreconditionException("transaction cannot be null");
      DbConnection dbConnection = null;
      string str = string.Empty;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      try
      {
        dbConnection = transaction.GetOrSetConnection(transaction.Database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          Parameters parameters = !this.mUseParameters.HasValue ? (!Settings.UseParameters ? (Parameters) null : new Parameters(command)) : (this.mUseParameters.Value ? new Parameters(command) : (Parameters) null);
          str = this.GetSql(transaction.Database, parameters);
          command.CommandText = str;
          command.CommandType = CommandType.Text;
          command.CommandTimeout = this.mTimeout.HasValue ? this.mTimeout.Value : Settings.DefaultTimeout;
          command.Transaction = transaction.GetOrSetDbTransaction(transaction.Database);
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(transaction.Database, str, QueryType.Delete, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          QueryResult queryResult;
          if (this.ReturnColumns == null || this.ReturnColumns.Length == 0)
          {
            int num = command.ExecuteNonQuery();
            pEnd = new DateTime?(DateTime.Now);
            queryResult = new QueryResult(num, str);
            Settings.FireQueryPerformedEvent(transaction.Database, str, num, QueryType.Delete, pStart, pEnd,
              (Exception) null, 
              transaction.IsolationLevel, null, new ulong?(transaction.Id));
          }
          else
          {
            using (DbDataReader dataReader = command.ExecuteReader())
            {
              pEnd = new DateTime?(DateTime.Now);
              queryResult = new QueryResult(transaction.Database, (IList<ISelectable>) this.ReturnColumns, dataReader, command.CommandText);
              Settings.FireQueryPerformedEvent(transaction.Database, str, queryResult.Count,
                QueryType.Delete, pStart, pEnd, (Exception) null, transaction.IsolationLevel, null, new ulong?(transaction.Id));
            }
          }
          return queryResult;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, str, 0, QueryType.Delete, pStart, pEnd, 
          ex, transaction.IsolationLevel, null, new ulong?(transaction.Id));
        throw;
      }
    }
  }
}
