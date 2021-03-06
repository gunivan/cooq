﻿using CooQ;
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
  /// Nullable datetime column
  /// 
  /// </summary>
  public class NDateTimeOffsetColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.DateTimeOffset;
      }
    }

    public NDateTimeOffsetColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NDateTimeOffsetColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NDateTimeOffsetColumn columnA, DateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NDateTimeOffsetColumn columnA, NDateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NDateTimeOffsetColumn columnA, DateTimeOffset value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NDateTimeOffsetColumn columnA, DateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NDateTimeOffsetColumn columnA, NDateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NDateTimeOffsetColumn columnA, DateTimeOffset value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NDateTimeOffsetColumn columnA, DateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NDateTimeOffsetColumn columnA, NDateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NDateTimeOffsetColumn columnA, DateTimeOffset value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NDateTimeOffsetColumn columnA, DateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NDateTimeOffsetColumn columnA, NDateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NDateTimeOffsetColumn columnA, DateTimeOffset value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NDateTimeOffsetColumn columnA, DateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NDateTimeOffsetColumn columnA, NDateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NDateTimeOffsetColumn columnA, DateTimeOffset value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NDateTimeOffsetColumn columnA, DateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NDateTimeOffsetColumn columnA, NDateTimeOffsetColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NDateTimeOffsetColumn columnA, DateTimeOffset value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public Condition In(IList<DateTimeOffset> list)
    {
      return (Condition)new InCondition<DateTimeOffset>(this, list);
    }

    public Condition NotIn(IList<DateTimeOffset> list)
    {
      return (Condition)new NotInCondition<DateTimeOffset>(this, list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params DateTimeOffset[] values)
    {
      return (Condition)new InCondition<DateTimeOffset>(this, values);
    }

    public Condition NotIn(params DateTimeOffset[] values)
    {
      return (Condition)new NotInCondition<DateTimeOffset>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return (DateTimeOffset?)dataReader.GetValue(columnIndex);
    }

    public DateTimeOffset ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return null == obj ? DateTimeOffset.MinValue : (DateTimeOffset)obj;
    }

    public void SetValue(Record record, DateTimeOffset? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, DateTimeOffset value)
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
      return null;
    }
    public override bool Nullable()
    {
      return true;
    }
  }
}
