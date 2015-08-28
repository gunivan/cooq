using CooQ;
using CooQ.Column;
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
  internal class InsertBuilder : IInsert, IInsertSet, IInsertUseParams, IInsertTimeout, IReturning, IInsertExecute
  {
    private readonly IList<SetValue> mSetValueList = new List<SetValue>();
    private bool? mUseParameters = new bool?();
    private int? mTimeout = new int?();
    private readonly TableBase mTable;

    internal bool? UseParams
    {
      get
      {
        return this.mUseParameters;
      }
    }

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

    public ColumnBase[] ReturnColumns { get; private set; }

    public InsertBuilder(TableBase table)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      this.mTable = table;
    }

    internal IInsertSet SetInternal(ColumnBase column, object value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(SmallIntegerColumn column, short value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NSmallIntegerColumn column, short? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(IntegerColumn column, int value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NIntegerColumn column, int? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(BigIntegerColumn column, long value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NBigIntegerColumn column, long? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(StringColumn column, string value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DecimalColumn column, Decimal value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDecimalColumn column, Decimal? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DoubleColumn column, Double value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDoubleColumn column, Double? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DateTimeColumn column, DateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DateTimeColumn column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDateTimeColumn column, DateTime? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDateTimeColumn column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DateTime2Column column, DateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DateTime2Column column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDateTime2Column column, DateTime? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDateTime2Column column, CurrentDateTime value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DateTimeOffsetColumn column, DateTimeOffset value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(DateTimeOffsetColumn column, CurrentDateTimeOffset value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDateTimeOffsetColumn column, DateTimeOffset? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NDateTimeOffsetColumn column, CurrentDateTimeOffset value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(BoolColumn column, bool value)
    {
      this.mSetValueList.Add(new SetValue(column, (value ? true : false)));
      return this;
    }

    public IInsertSet Set(NBoolColumn column, bool? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(GuidColumn column, Guid value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NGuidColumn column, Guid? value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(BinaryColumn column, byte[] value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(NBinaryColumn column, byte[] value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<ENUM>(EnumColumn<ENUM> column, ENUM value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set(ColumnBase column, CustomSql value)
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(GuidKeyColumn<TABLE> column, Guid value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(NGuidKeyColumn<TABLE> column, Guid? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(SmallIntegerKeyColumn<TABLE> column, short value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(NSmallIntegerKeyColumn<TABLE> column, short? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(IntegerKeyColumn<TABLE> column, int value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(NIntegerKeyColumn<TABLE> column, int? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(BigIntegerKeyColumn<TABLE> column, long value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(NBigIntegerKeyColumn<TABLE> column, long? value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertSet Set<TABLE>(StringKeyColumn<TABLE> column, string value) where TABLE : TableBase
    {
      this.mSetValueList.Add(new SetValue(column, value));
      return this;
    }

    public IInsertTimeout UseParameters(bool useParameters)
    {
      this.mUseParameters = new bool?(useParameters);
      return (IInsertTimeout)this;
    }

    public IInsertExecute Timeout(int seconds)
    {
      if (seconds < 0)
        throw new Exception("seconds must be >=. Current value = " + seconds.ToString());
      this.mTimeout = new int?(seconds);
      return (IInsertExecute)this;
    }

    public IInsertExecute Returning(params ColumnBase[] columns)
    {
      if (columns == null)
        throw new NullReferenceException("columns cannot be null");
      if (columns.Length == 0)
        throw new Exception("columns cannot be empty");
      this.ReturnColumns = columns;
      return (IInsertExecute)this;
    }

    public string GetSql()
    {    
      return QueryBuilderFactory.GetInsertQuery(DatabaseProvider.INSTANCE, this, (Parameters)null);
    }

    public string GetSql(DatabaseBase database)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      return QueryBuilderFactory.GetInsertQuery(database, this, (Parameters)null);
    }

    private string GetSql(DatabaseBase database, Parameters parameters)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      return QueryBuilderFactory.GetInsertQuery(database, this, parameters);
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
          Settings.FireQueryExecutingEvent(transaction.Database, str, QueryType.Insert, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          QueryResult queryResult;
          if (this.ReturnColumns == null || this.ReturnColumns.Length == 0)
          {
            int num = command.ExecuteNonQuery();
            pEnd = new DateTime?(DateTime.Now);
            queryResult = new QueryResult(num, str);
            Settings.FireQueryPerformedEvent(transaction.Database, str, num, QueryType.Insert, pStart, pEnd, (Exception)null, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
          }
          else
          {
            using (DbDataReader dataReader = command.ExecuteReader())
            {
              pEnd = new DateTime?(DateTime.Now);
              queryResult = new QueryResult(transaction.Database, (IList<ISelectable>)this.ReturnColumns, dataReader, command.CommandText);
              Settings.FireQueryPerformedEvent(transaction.Database, str, queryResult.Count, QueryType.Insert, pStart, pEnd, (Exception)null, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
            }
          }
          return (IResult)queryResult;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, str, 0, QueryType.Insert, pStart, pEnd, ex, transaction.IsolationLevel, (IResult)null, new ulong?(transaction.Id));
        throw;
      }
    }
  }
}
