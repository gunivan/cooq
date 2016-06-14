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
  public class NFloatColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Single;
      }
    }

    public NFloatColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NFloatColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NFloatColumn columnA, NFloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NFloatColumn columnA, FloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NFloatColumn columnA, float value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NFloatColumn columnA, NFloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NFloatColumn columnA, FloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NFloatColumn columnA, float value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NFloatColumn columnA, NFloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NFloatColumn columnA, FloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NFloatColumn columnA, float value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NFloatColumn columnA, NFloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NFloatColumn columnA, FloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NFloatColumn columnA, float value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NFloatColumn columnA, NFloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NFloatColumn columnA, FloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NFloatColumn columnA, float value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NFloatColumn columnA, NFloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NFloatColumn columnA, FloatColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NFloatColumn columnA, float value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator +(NFloatColumn columnA, NFloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator +(NFloatColumn columnA, FloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator +(NFloatColumn columnA, float value)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator -(NFloatColumn columnA, NFloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator -(NFloatColumn columnA, FloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator -(NFloatColumn columnA, float value)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator /(NFloatColumn columnA, NFloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator /(NFloatColumn columnA, FloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator /(NFloatColumn columnA, float value)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator *(NFloatColumn columnA, NFloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator *(NFloatColumn columnA, FloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator *(NFloatColumn columnA, float value)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator %(NFloatColumn columnA, NFloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator %(NFloatColumn columnA, FloatColumn columnB)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<FloatColumn, NFloatColumn, float> operator %(NFloatColumn columnA, float value)
    {
      return new NumericCondition<FloatColumn, NFloatColumn, float>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<float> list)
    {
      return (Condition)new InCondition<float>(this, list);
    }

    public Condition NotIn(IList<float> list)
    {
      return (Condition)new NotInCondition<float>(this, list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition)new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params float[] values)
    {
      return (Condition)new InCondition<float>(this, values);
    }

    public Condition NotIn(params float[] values)
    {
      return (Condition)new NotInCondition<float>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new float?(dataReader.GetFloat(columnIndex));
    }

    public float ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return obj == null ? float.MinValue : (float)obj;
    }

    public void SetValue(Record record, float? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, float value)
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
