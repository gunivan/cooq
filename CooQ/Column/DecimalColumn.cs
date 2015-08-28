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
  public class DecimalColumn : NumericColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Decimal;
      }
    }

    public DecimalColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public DecimalColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(DecimalColumn columnA, DecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(DecimalColumn columnA, Decimal value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(DecimalColumn columnA, DecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(DecimalColumn columnA, Decimal value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(DecimalColumn columnA, DecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(DecimalColumn columnA, Decimal value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(DecimalColumn columnA, DecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(DecimalColumn columnA, Decimal value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(DecimalColumn columnA, DecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(DecimalColumn columnA, Decimal value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(DecimalColumn columnA, DecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(DecimalColumn columnA, Decimal value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator +(DecimalColumn columnA, DecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator +(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator +(DecimalColumn columnA, Decimal value)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator -(DecimalColumn columnA, DecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator -(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator -(DecimalColumn columnA, Decimal value)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator /(DecimalColumn columnA, DecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator /(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator /(DecimalColumn columnA, Decimal value)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator *(DecimalColumn columnA, DecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator *(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator *(DecimalColumn columnA, Decimal value)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator %(DecimalColumn columnA, DecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator %(DecimalColumn columnA, NDecimalColumn columnB)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<DecimalColumn, NDecimalColumn, Decimal> operator %(DecimalColumn columnA, Decimal value)
    {
      return new NumericCondition<DecimalColumn, NDecimalColumn, Decimal>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<Decimal> list)
    {
      return (Condition) new InCondition<Decimal>(this, list);
    }

    public Condition NotIn(IList<Decimal> list)
    {
      return (Condition) new NotInCondition<Decimal>(this, list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params Decimal[] values)
    {
      return (Condition) new InCondition<Decimal>(this, values);
    }

    public Condition NotIn(params Decimal[] values)
    {
      return (Condition) new NotInCondition<Decimal>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return dataReader.GetDecimal(columnIndex);
    }

    public Decimal ValueOf(Record record)
    {
      return (Decimal) record.GetValue(this);
    }

    public void SetValue(Record record, Decimal value)
    {
      record.SetValue(this, value);
    }

    public decimal GetValue(DataRow row)
    {
      return base.As<decimal>(row);
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
      return new Decimal(0);
    }
  }
}
