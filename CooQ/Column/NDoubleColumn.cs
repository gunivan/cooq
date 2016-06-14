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
  public class NDoubleColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Double;
      }
    }

    public NDoubleColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NDoubleColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NDoubleColumn columnA, double value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NDoubleColumn columnA, double value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NDoubleColumn columnA, double value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NDoubleColumn columnA, double value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NDoubleColumn columnA, double value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NDoubleColumn columnA, double value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator +(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator +(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator +(NDoubleColumn columnA, double value)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator -(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator -(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator -(NDoubleColumn columnA, double value)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator /(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator /(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator /(NDoubleColumn columnA, double value)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator *(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator *(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator *(NDoubleColumn columnA, double value)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator %(NDoubleColumn columnA, NDoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator %(NDoubleColumn columnA, DoubleColumn columnB)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<DoubleColumn, NDoubleColumn, double> operator %(NDoubleColumn columnA, double value)
    {
      return new NumericCondition<DoubleColumn, NDoubleColumn, double>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<double> list)
    {
      return (Condition)new InCondition<double>(this, list);
    }

    public Condition NotIn(IList<double> list)
    {
      return (Condition)new NotInCondition<double>(this, list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params double[] values)
    {
      return (Condition)new InCondition<double>(this, values);
    }

    public Condition NotIn(params double[] values)
    {
      return (Condition)new NotInCondition<double>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new double?(dataReader.GetDouble(columnIndex));
    }

    public double ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return null == obj ? double.MinValue : (double)obj;
    }

    public void SetValue(Record record, double? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, double value)
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
