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
  public class IntegerKeyColumn<TABLE> : NumericColumnBase where TABLE : TableBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int32;
      }
    }

    public IntegerKeyColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public IntegerKeyColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public IntegerKeyColumn(TableBase table, string columnName, bool isPrimaryKey, bool isAutoId)
      : base(table, columnName, isPrimaryKey)
    {
      this.IsAutoId = isAutoId;
    }

    public static Condition operator ==(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator +(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator +(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator +(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator -(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator -(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator -(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator /(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator /(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator /(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator *(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator *(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator *(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator %(IntegerKeyColumn<TABLE> columnA, IntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator %(IntegerKeyColumn<TABLE> columnA, NIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int> operator %(IntegerKeyColumn<TABLE> columnA, int value)
    {
      return new NumericCondition<IntegerKeyColumn<TABLE>, NIntegerKeyColumn<TABLE>, int>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<int> integerList)
    {
      return (Condition) new InCondition<int>(this, integerList);
    }

    public Condition NotIn(IList<int> integerList)
    {
      return (Condition) new NotInCondition<int>(this, integerList);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params int[] values)
    {
      return (Condition) new InCondition<int>(this, values);
    }

    public Condition NotIn(params int[] values)
    {
      return (Condition) new NotInCondition<int>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      int num;
      if (this.IsAutoId)
      {
        object obj = dataReader.GetValue(columnIndex);
        num = !(obj is Decimal) ? (int) obj : (int) ((Decimal) obj);
      }
      else
        num = dataReader.GetInt32(columnIndex);
      return num;
    }

    public int ValueOf(Record record)
    {
      return (int) record.GetValue(this);
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
      return 0;
    }
  }
}
