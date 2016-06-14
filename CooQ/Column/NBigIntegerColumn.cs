using CooQ;
using CooQ.Conditions;
using CooQ.Interfaces;
using CooQ.Types;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  /// <summary>
  /// Null Big Integer Column
  ///             This column maps to nullable 8 byte integer fields, Int64, Long, Int8
  /// 
  /// </summary>
  public class NBigIntegerColumn : NumericColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int64;
      }
    }

    public NBigIntegerColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NBigIntegerColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NBigIntegerColumn columnA, long value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NBigIntegerColumn columnA, long value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NBigIntegerColumn columnA, long value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NBigIntegerColumn columnA, long value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NBigIntegerColumn columnA, long value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NBigIntegerColumn columnA, long value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator +(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator +(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator +(NBigIntegerColumn columnA, long value)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator -(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator -(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator -(NBigIntegerColumn columnA, long value)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator /(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator /(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator /(NBigIntegerColumn columnA, long value)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator *(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator *(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator *(NBigIntegerColumn columnA, long value)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator %(NBigIntegerColumn columnA, NBigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator %(NBigIntegerColumn columnA, BigIntegerColumn columnB)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<BigIntegerColumn, NBigIntegerColumn, long> operator %(NBigIntegerColumn columnA, long value)
    {
      return new NumericCondition<BigIntegerColumn, NBigIntegerColumn, long>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<long> integerList)
    {
      return (Condition)new InCondition<long>(this, integerList);
    }

    public Condition NotIn(IList<long> integerList)
    {
      return (Condition)new NotInCondition<long>(this, integerList);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params long[] values)
    {
      return (Condition)new InCondition<long>(this, values);
    }

    public Condition NotIn(params long[] values)
    {
      return (Condition)new NotInCondition<long>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return dataReader.GetInt64(columnIndex);
    }

    public long ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return null == obj ? long.MinValue : (long)obj;
    }

    public void SetValue(Record record, long? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, long value)
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
