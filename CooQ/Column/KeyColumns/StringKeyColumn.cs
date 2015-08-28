using CooQ;
using CooQ.Conditions;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  public class StringKeyColumn<TABLE> : ColumnBase where TABLE : TableBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.String;
      }
    }

    public StringKeyColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public StringKeyColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(StringKeyColumn<TABLE> columnA, StringKeyColumn<TABLE> columnB)
    {
      if (object.Equals(null, columnB))
        throw new NullReferenceException("columnB cannot be null");
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator !=(StringKeyColumn<TABLE> columnA, StringKeyColumn<TABLE> columnB)
    {
      if (object.Equals(null, columnB))
        throw new NullReferenceException("columnB cannot be null");
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator ==(StringKeyColumn<TABLE> columnA, string value)
    {
      if (value == null)
        throw new NullReferenceException("value cannot be null when using the == operator. Use .IsNull() method if a null condition is required. 'StringKeyColumn = null' is an undefined condition in sql so this library disallows it.");
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(StringKeyColumn<TABLE> columnA, string value)
    {
      if (value == null)
        throw new NullReferenceException("value cannot be null when using the != operator. Use .IsNull() method if a null condition is required. 'StringKeyColumn != null' is an undefined condition in sql so this library disallows it.");
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public Condition Like(string value)
    {
      if (value == null)
        throw new NullReferenceException("value cannot be null when using the 'like' operator. 'StringKeyColumn like null' is an undefined condition in sql so this library disallows it.");
      return (Condition)new ColumnCondition(this, Operator.LIKE, value);
    }

    public Condition NotLike(string value)
    {
      if (value == null)
        throw new NullReferenceException("value cannot be null when using the 'not like' operator. 'StringKeyColumn not like null' is an undefined condition in sql so this library disallows it.");
      return (Condition)new ColumnCondition(this, Operator.NOT_LIKE, value);
    }

    public Condition In(List<string> list)
    {
      foreach (string str in list)
      {
        if (str == null)
          throw new NullReferenceException("A value in list is null. 'StringKeyColumn IN (null)' is an undefined condition in sql so this library disallows it.");
      }
      return (Condition)new InCondition<string>(this, (IList<string>)list);
    }

    public Condition NotIn(List<string> list)
    {
      foreach (string str in list)
      {
        if (str == null)
          throw new NullReferenceException("A value in list is null. 'StringKeyColumn NOT IN (null)' is an undefined condition in sql so this library disallows it.");
      }
      return (Condition)new NotInCondition<string>(this, (IList<string>)list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params string[] values)
    {
      if (values == null)
        throw new NullReferenceException("values cannot be null");
      foreach (string str in values)
      {
        if (str == null)
          throw new NullReferenceException("A value in values is null. 'StringKeyColumn IN (null)' is an undefined condition in sql so this library disallows it.");
      }
      return (Condition)new InCondition<string>(this, values);
    }

    public Condition NotIn(params string[] values)
    {
      if (values == null)
        throw new NullReferenceException("values cannot be null");
      foreach (string str in values)
      {
        if (str == null)
          throw new NullReferenceException("A value in values is null. 'StringKeyColumn NOT IN (null)' is an undefined condition in sql so this library disallows it.");
      }
      return (Condition)new NotInCondition<string>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return dataReader.GetString(columnIndex);
    }

    public string ValueOf(Record record)
    {
      return (string)record.GetValue(this);
    }

    public void SetValue(Record record, string value)
    {
      record.SetValue(this, value);
    }

    public override object GetDefaultType()
    {
      return null;
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString()
    {
      return base.ToString();
    }
  }
}
