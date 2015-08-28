using CooQ;
using CooQ.Column;
using CooQ.Conditions;
using CooQ.Core;
using CooQ.Database;
using CooQ.Function;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CooQ.Builder
{
  internal class UpdateBuilder : IUpdate, IUpdateSet, IUpdateJoin, IUpdateWhere, IUpdateUseParams,
    IUpdateTimeout, IUpdateReturning, IUpdateExecute
  {
    private readonly IList<SetValue> mSetValueList = new List<SetValue>();
    private readonly List<Join> mJoinList = new List<Join>();
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

    public IList<SetValue> SetValueList
    {
      get
      {
        return this.mSetValueList;
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

    public ColumnBase[] ReturnColumns { get; private set; }

    public UpdateBuilder(TableBase table)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      this.mTable = table;
    }

    internal IUpdateSet SetInternal(ColumnBase column, object value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<COLUMN>(COLUMN columnA, COLUMN columnB) where COLUMN : ColumnBase
    {
      if (object.Equals(null, columnB))
        throw new NullReferenceException("columnB cannot be null");
      this.mSetValueList.Add(new SetValue(columnA, columnB));
      return this;
    }

    public IUpdateSet Set(SmallIntegerColumn column, short value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NSmallIntegerColumn column, short? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(IntegerColumn column, int value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NIntegerColumn column, int? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(BigIntegerColumn column, long value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NBigIntegerColumn column, long? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(StringColumn column, string value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DecimalColumn column, Decimal value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDecimalColumn column, Decimal? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DateTimeColumn column, DateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DateTimeColumn column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDateTimeColumn column, DateTime? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDateTimeColumn column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DateTime2Column column, DateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DateTime2Column column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDateTime2Column column, DateTime? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDateTime2Column column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DateTimeOffsetColumn column, DateTimeOffset value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(DateTimeOffsetColumn column, CurrentDateTimeOffset value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDateTimeOffsetColumn column, DateTimeOffset? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDateTimeOffsetColumn column, CurrentDateTimeOffset value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(BoolColumn column, bool value)
    {
      this.mSetValueList.Add(new SetValue(column, (value ? true : false)));
      return this;
    }

    public IUpdateSet Set(NBoolColumn column, bool? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(GuidColumn column, Guid value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NGuidColumn column, Guid? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(BinaryColumn column, byte[] value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NBinaryColumn column, byte[] value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(GuidKeyColumn<TABLE> column, Guid value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(NGuidKeyColumn<TABLE> column, Guid? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(SmallIntegerKeyColumn<TABLE> column, short value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(NSmallIntegerKeyColumn<TABLE> column, short? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(IntegerKeyColumn<TABLE> column, int value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(NIntegerKeyColumn<TABLE> column, int? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(BigIntegerKeyColumn<TABLE> column, long value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(NBigIntegerKeyColumn<TABLE> column, long? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set<TABLE>(StringKeyColumn<TABLE> column, string value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateJoin Join(TableBase table, Condition condition)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (condition == null)
        throw new NullReferenceException("condition cannot be null");
      this.mJoinList.Add(new Join(JoinType.JOIN, table, condition, (string[])null));
      return this;
    }

    public IUpdateUseParams NoWhereCondition()
    {
      return this;
    }

    public IUpdateUseParams Where(Condition condition)
    {
      if (condition == null)
        throw new NullReferenceException("condition cannot be null");
      this.mWhereCondition = condition;
      return this;
    }

    public IUpdateTimeout UseParameters(bool useParameters)
    {
      this.mUseParameters = new bool?(useParameters);
      return this;
    }

    public IUpdateExecute Timeout(int seconds)
    {
      if (seconds < 0)
        throw new Exception("seconds must be >= 0. Current value = " + seconds.ToString());
      this.mTimeout = new int?(seconds);
      return this;
    }

    public IUpdateExecute Returning(params ColumnBase[] columns)
    {
      if (columns == null)
        throw new NullReferenceException("columns cannot be null");
      if (columns.Length == 0)
        throw new Exception("columns cannot be empty");
      this.ReturnColumns = columns;
      return this;
    }

    public string GetSql()
    {    
      return QueryBuilderFactory.GetUpdateQuery(DatabaseProvider.INSTANCE, this, (Parameters)null);
    }

    public string GetSql(DatabaseBase database)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      return QueryBuilderFactory.GetUpdateQuery(database, this, (Parameters)null);
    }

    private string GetSql(DatabaseBase database, Parameters parameters)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      return QueryBuilderFactory.GetUpdateQuery(database, this, parameters);
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
        throw new NullReferenceException("transaction cannot be null");
      DbConnection dbConnection = (DbConnection)null;
      string str = string.Empty;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      try
      {
        dbConnection = transaction.GetOrSetConnection(transaction.Database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          Parameters parameters = !this.mUseParameters.HasValue ? (!Settings.UseParameters ? (Parameters)null : new Parameters(command)) : (this.mUseParameters.Value ? new Parameters(command) : (Parameters)null);
          str = this.GetSql(transaction.Database, parameters);
          command.CommandText = str;
          command.CommandType = CommandType.Text;
          command.CommandTimeout = this.mTimeout.HasValue ? this.mTimeout.Value : Settings.DefaultTimeout;
          command.Transaction = transaction.GetOrSetDbTransaction(transaction.Database);
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(transaction.Database, str, QueryType.Update, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          QueryResult queryResult;
          if (this.ReturnColumns == null || this.ReturnColumns.Length == 0)
          {
            int num = command.ExecuteNonQuery();
            pEnd = new DateTime?(DateTime.Now);
            queryResult = new QueryResult(num, str);
            Settings.FireQueryPerformedEvent(transaction.Database, str, num, QueryType.Update, pStart, pEnd, (Exception)null, transaction.IsolationLevel, null, new ulong?(transaction.Id));
          }
          else
          {
            using (DbDataReader dataReader = command.ExecuteReader())
            {
              pEnd = new DateTime?(DateTime.Now);
              queryResult = new QueryResult(transaction.Database, (IList<ISelectable>)this.ReturnColumns, dataReader, command.CommandText);
              Settings.FireQueryPerformedEvent(transaction.Database, str, queryResult.Count, QueryType.Update, pStart, pEnd, (Exception)null, transaction.IsolationLevel, null, new ulong?(transaction.Id));
            }
          }
          return queryResult;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, str, 0, QueryType.Update, pStart, pEnd, ex, transaction.IsolationLevel, null, new ulong?(transaction.Id));
        throw;
      }
    }

    public IUpdateSet Set(DoubleColumn column, double value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IUpdateSet Set(NDoubleColumn column, double? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }
  }
}
