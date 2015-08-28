using CooQ;
using CooQ.Conditions;
using CooQ.Core;
using CooQ.Database;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CooQ.Builder
{
  internal class QueryBuilderBase : IDistinct, ITop, IFromInto, IFrom, IJoin, IWhere, IGroupBy, IHaving, IOrderBy, IAppend, IUseParams, ITimeout, IExecute
  {
    private int? mTopRows = new int?();
    private List<Join> mJoinList = new List<Join>();
    private bool? mUseParameters = new bool?();
    private int? mTimeout = new int?();
    private QueryBuilderBase mUnionQuery;
    private UnionType mUnionType;
    private readonly ISelectable[] mColumns;
    private bool mDistinct;
    private TableBase mIntoTable;
    private TableBase mFromTable;
    private string[] mFromHints;
    private Condition mWhereCondition;
    private ISelectable[] mGroupByColumns;
    private IOrderByColumn[] mOrderByColumns;
    private Condition mHavingCondition;
    private string mCustomSql;

    public QueryBuilderBase UnionQuery
    {
      get
      {
        return this.mUnionQuery;
      }
      private set
      {
        this.mUnionQuery = value;
      }
    }

    public UnionType UnionType
    {
      get
      {
        return this.mUnionType;
      }
      private set
      {
        this.mUnionType = value;
      }
    }

    public ISelectable[] SelectColumns
    {
      get
      {
        return this.mColumns;
      }
    }

    public bool IsDistinct
    {
      get
      {
        return this.mDistinct;
      }
    }


    public int? TopRows
    {
      get
      {
        return this.mTopRows;
      }
    }
    public int? Torecords
    {
      get
      {
        return this.mTopRows;
      }
    }

    public TableBase IntoTable
    {
      get
      {
        return this.mIntoTable;
      }
    }

    public TableBase FromTable
    {
      get
      {
        return this.mFromTable;
      }
    }

    public string[] FromHints
    {
      get
      {
        return this.mFromHints;
      }
    }

    public List<Join> JoinList
    {
      get
      {
        return this.mJoinList;
      }
    }

    public Condition WhereCondition
    {
      get
      {
        return this.mWhereCondition;
      }
    }

    public ISelectable[] GroupByColumns
    {
      get
      {
        return this.mGroupByColumns;
      }
    }

    public IOrderByColumn[] OrderByColumns
    {
      get
      {
        return this.mOrderByColumns;
      }
    }

    public Condition HavingCondition
    {
      get
      {
        return this.mHavingCondition;
      }
    }

    public string CustomSql
    {
      get
      {
        return this.mCustomSql;
      }
    }

    public ITop Distinct
    {
      get
      {
        this.mDistinct = true;
        return (ITop)this;
      }
    }

    internal QueryBuilderBase(ISelectable[] columns)
    {
      if (columns == null || columns.Length == 0)
        throw new Exception("columns cannot be null or empty");
      this.mColumns = columns;
    }

    public IFromInto Top(int records)
    {
      if (records < 0)
        throw new Exception("records must be >= 0. records = " + records.ToString());
      this.mTopRows = new int?(records);
      return (IFromInto)this;
    }

    public IFrom Into(TableBase table)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      this.mIntoTable = table;
      return (IFrom)this;
    }

    public IJoin From(TableBase pFromTable, params string[] hints)
    {
      if (pFromTable == null)
        throw new NullReferenceException("pFromTable cannot be null");
      this.mFromTable = pFromTable;
      this.mFromHints = hints != null ? hints : new string[0];
      return this;
    }

    public IJoin Join(TableBase table, Condition condition, params string[] hints)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (condition == null)
        throw new NullReferenceException("condition cannot be null");
      this.mJoinList.Add(new Join(JoinType.JOIN, table, condition, hints));
      return this;
    }

    public IJoin JoinIf(bool includeJoin, TableBase table, Condition condition, params string[] hints)
    {
      if (includeJoin)
        this.Join(table, condition, hints);
      return this;
    }

    public IJoin LeftJoin(TableBase table, Condition condition, params string[] hints)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (condition == null)
        throw new NullReferenceException("condition cannot be null");
      this.mJoinList.Add(new Join(JoinType.LEFT, table, condition, hints));
      return this;
    }

    public IJoin LeftJoinIf(bool includeJoin, TableBase table, Condition condition, params string[] hints)
    {
      if (includeJoin)
        this.LeftJoin(table, condition, hints);
      return this;
    }

    public IJoin RightJoin(TableBase table, Condition condition, params string[] hints)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (condition == null)
        throw new NullReferenceException("condition cannot be null");
      this.mJoinList.Add(new Join(JoinType.RIGHT, table, condition, hints));
      return this;
    }

    public IJoin RightJoinIf(bool includeJoin, TableBase table, Condition condition, params string[] hints)
    {
      if (includeJoin)
        this.RightJoin(table, condition, hints);
      return this;
    }

    public IGroupBy Where(Condition condition)
    {
      this.mWhereCondition = condition;
      return this;
    }

    public IHaving GroupBy(params ISelectable[] columns)
    {
      if (columns == null)
        throw new NullReferenceException("columns cannot be null");
      if (columns.Length == 0)
        throw new Exception("columns must be > 0 in length");
      this.mGroupByColumns = columns;
      return this;
    }

    public IOrderBy Having(Condition condition)
    {
      if (condition == null)
        throw new NullReferenceException("condition cannot be null");
      this.mHavingCondition = condition;
      return this;
    }

    public IAppend OrderBy(params IOrderByColumn[] orderByColumns)
    {
      if (orderByColumns == null)
        throw new NullReferenceException("orderByColumns cannot be null");
      if (orderByColumns.Length == 0)
        throw new Exception("orderByColumns must be > 0 in length");
      this.mOrderByColumns = orderByColumns;
      return this;
    }

    public string GetSql()
    {
      return QueryBuilderFactory.GetSelectQuery(DatabaseProvider.INSTANCE, this, null);
    }

    public string GetSql(DatabaseBase database)
    {
      return QueryBuilderFactory.GetSelectQuery(database ?? DatabaseProvider.INSTANCE, this, null);
    }

    private string GetSql(DatabaseBase database, Parameters parameters)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      return QueryBuilderFactory.GetSelectQuery(database, this, parameters);
    }

    public IUseParams Append(string pCustomSql)
    {
      this.mCustomSql = pCustomSql;
      return this;
    }

    public ITimeout UseParameters(bool useParameters)
    {
      this.mUseParameters = new bool?(useParameters);
      return this;
    }

    public IExecute Timeout(int seconds)
    {
      if (seconds < 0)
        throw new Exception("seconds must be >=. Current value = " + seconds.ToString());
      this.mTimeout = new int?(seconds);
      return this;
    }

    public IResult Execute(DatabaseBase database)
    {
      return this.ExecuteQuery(database, (Transaction)null);
    }

    public IResult Execute()
    {
      return this.ExecuteQuery(this.mFromTable.DefaultDatabase, (Transaction)null);
    }

    public IResult ExecuteUncommitted(DatabaseBase database)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      using (Transaction transaction = new Transaction(database, IsolationLevel.ReadUncommitted))
      {
        IResult result = this.Execute(transaction);
        transaction.Commit();
        return result;
      }
    }

    public IResult ExecuteUncommitted()
    {
      return this.ExecuteUncommitted(this.mFromTable.DefaultDatabase);
    }

    public IResult Execute(Transaction transaction)
    {
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      return this.ExecuteQuery(transaction.Database, transaction);
    }

    private IResult ExecuteQuery(DatabaseBase database, Transaction transaction)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      if (transaction != null && transaction.Database != database)
        throw new ArgumentException("transaction is using a different database connection than database.");
      DbConnection dbConnection = null;
      string pSql = string.Empty;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      IsolationLevel pIsolationLevel = IsolationLevel.Unspecified;
      try
      {
        dbConnection = transaction != null ? transaction.GetOrSetConnection(database) : database.GetConnection(true);
      }
      catch (Exception e)
      {
        throw new CooqDataException.DataAccessException("Cannot open connection." + e.Message, e);
      }

      try
      {
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          Parameters parameters = !this.mUseParameters.HasValue ? (!Settings.UseParameters ? (Parameters)null : new Parameters(command)) : (this.mUseParameters.Value ? new Parameters(command) : (Parameters)null);
          pSql = this.GetSql(database, parameters);
          command.CommandText = pSql;
          command.CommandType = CommandType.Text;
          command.CommandTimeout = this.mTimeout.HasValue ? this.mTimeout.Value : Settings.DefaultTimeout;
          if (transaction != null)
            command.Transaction = transaction.GetOrSetDbTransaction(database);
          if (command.Transaction != null)
            pIsolationLevel = command.Transaction.IsolationLevel;
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(database, pSql, QueryType.Select, pStart, pIsolationLevel, transaction != null ? new ulong?(transaction.Id) : new ulong?());
          using (DbDataReader dataReader = command.ExecuteReader())
          {
            pEnd = new DateTime?(DateTime.Now);
            QueryResult queryResult = new QueryResult(database, (IList<ISelectable>)this.mColumns, dataReader, command.CommandText);
            if (transaction == null)
              dbConnection.Close();
            Settings.FireQueryPerformedEvent(database, pSql, queryResult.Count, QueryType.Select, pStart, pEnd, (Exception)null, pIsolationLevel, (IResult)queryResult, transaction != null ? new ulong?(transaction.Id) : new ulong?());
            return (IResult)queryResult;
          }
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(database, pSql, 0, QueryType.Select, pStart, pEnd, ex, pIsolationLevel, (IResult)null, transaction != null ? new ulong?(transaction.Id) : new ulong?());
        throw new CooqDataException.DataAccessException("Error while executing." + ex.Message, ex);
      }
    }

    public IDistinct Union(ISelectableColumns pField, params ISelectableColumns[] pFields)
    {
      if (pField == null)
        throw new NullReferenceException("pField cannot be null");
      List<ISelectable> list = new List<ISelectable>();
      list.AddRange((IEnumerable<ISelectable>)pField.SelectableColumns);
      foreach (ISelectableColumns selectableColumns in pFields)
        list.AddRange((IEnumerable<ISelectable>)selectableColumns.SelectableColumns);
      return (IDistinct)new QueryBuilderBase(list.ToArray())
      {
        UnionQuery = this,
        UnionType = UnionType.UNION
      };
    }

    public IDistinct UnionAll(ISelectableColumns pField, params ISelectableColumns[] pFields)
    {
      if (pField == null)
        throw new NullReferenceException("pField cannot be null");
      List<ISelectable> list = new List<ISelectable>();
      list.AddRange((IEnumerable<ISelectable>)pField.SelectableColumns);
      foreach (ISelectableColumns selectableColumns in pFields)
        list.AddRange((IEnumerable<ISelectable>)selectableColumns.SelectableColumns);
      return (IDistinct)new QueryBuilderBase(list.ToArray())
      {
        UnionQuery = this,
        UnionType = UnionType.UNION_ALL
      };
    }

    public IDistinct Intersect(ISelectableColumns pField, params ISelectableColumns[] pFields)
    {
      if (pField == null)
        throw new NullReferenceException("pField cannot be null");
      List<ISelectable> list = new List<ISelectable>();
      list.AddRange((IEnumerable<ISelectable>)pField.SelectableColumns);
      foreach (ISelectableColumns selectableColumns in pFields)
        list.AddRange((IEnumerable<ISelectable>)selectableColumns.SelectableColumns);
      return (IDistinct)new QueryBuilderBase(list.ToArray())
      {
        UnionQuery = this,
        UnionType = UnionType.INTERSECT
      };
    }

    public IDistinct Except(ISelectableColumns pField, params ISelectableColumns[] pFields)
    {
      if (pField == null)
        throw new NullReferenceException("pField cannot be null");
      List<ISelectable> list = new List<ISelectable>();
      list.AddRange((IEnumerable<ISelectable>)pField.SelectableColumns);
      foreach (ISelectableColumns selectableColumns in pFields)
        list.AddRange((IEnumerable<ISelectable>)selectableColumns.SelectableColumns);
      return (IDistinct)new QueryBuilderBase(list.ToArray())
      {
        UnionQuery = this,
        UnionType = UnionType.EXCEPT
      };
    }
  }
}
