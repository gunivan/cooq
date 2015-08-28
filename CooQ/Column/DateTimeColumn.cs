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
  /// <summary>
  /// Datetime column
  /// 
  /// </summary>
  public class DateTimeColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.DateTime;
      }
    }

    public DateTimeColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public DateTimeColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(DateTimeColumn columnA, DateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(DateTimeColumn columnA, NDateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(DateTimeColumn columnA, DateTime value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(DateTimeColumn columnA, DateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(DateTimeColumn columnA, NDateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(DateTimeColumn columnA, DateTime value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(DateTimeColumn columnA, DateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(DateTimeColumn columnA, NDateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(DateTimeColumn columnA, DateTime value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(DateTimeColumn columnA, DateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(DateTimeColumn columnA, NDateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(DateTimeColumn columnA, DateTime value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(DateTimeColumn columnA, DateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(DateTimeColumn columnA, NDateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(DateTimeColumn columnA, DateTime value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(DateTimeColumn columnA, DateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(DateTimeColumn columnA, NDateTimeColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(DateTimeColumn columnA, DateTime value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public Condition In(IList<DateTime> list)
    {
      return (Condition) new InCondition<DateTime>(this, list);
    }

    public Condition NotIn(IList<DateTime> list)
    {
      return (Condition) new NotInCondition<DateTime>(this, list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params DateTime[] values)
    {
      return (Condition) new InCondition<DateTime>(this, values);
    }

    public Condition NotIn(params DateTime[] values)
    {
      return (Condition) new NotInCondition<DateTime>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return dataReader.GetDateTime(columnIndex);
    }

    public DateTime ValueOf(Record record)
    {
      return (DateTime) record.GetValue(this);
    }

    public void SetValue(Record record, DateTime value)
    {
      record.SetValue(this, value);
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

    public override object GetDefaultType()
    {
      return DateTime.MinValue;
    }
  }
}
