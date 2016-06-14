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
  public class NIntegerColumn : NumericColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int32;
      }
    }

    public NIntegerColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NIntegerColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NIntegerColumn columnA, int value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NIntegerColumn columnA, int value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NIntegerColumn columnA, int value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NIntegerColumn columnA, int value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NIntegerColumn columnA, int value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NIntegerColumn columnA, int value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator +(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator +(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator +(NIntegerColumn columnA, int value)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator -(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator -(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator -(NIntegerColumn columnA, int value)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator /(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator /(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator /(NIntegerColumn columnA, int value)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator *(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator *(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator *(NIntegerColumn columnA, int value)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator %(NIntegerColumn columnA, NIntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator %(NIntegerColumn columnA, IntegerColumn columnB)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<IntegerColumn, NIntegerColumn, int> operator %(NIntegerColumn columnA, int value)
    {
      return new NumericCondition<IntegerColumn, NIntegerColumn, int>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<int> integerList)
    {
      return (Condition)new InCondition<int>(this, integerList);
    }

    public Condition NotIn(IList<int> integerList)
    {
      return (Condition)new NotInCondition<int>(this, integerList);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params int[] values)
    {
      return (Condition)new InCondition<int>(this, values);
    }

    public Condition NotIn(params int[] values)
    {
      return (Condition)new NotInCondition<int>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (Convert.IsDBNull(dataReader[columnIndex]))
        return 0;
      return dataReader.GetInt32(columnIndex);
    }

    public int ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return null == obj ? int.MinValue : (int)obj;
    }

    public void SetValue(Record record, int? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, int value)
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
