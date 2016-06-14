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
  public class NSmallIntegerKeyColumn<TABLE> : NumericColumnBase where TABLE : TableBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int16;
      }
    }

    public NSmallIntegerKeyColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NSmallIntegerKeyColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator +(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator +(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator +(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator -(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator -(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator -(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator /(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator /(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator /(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator *(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator *(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator *(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator %(NSmallIntegerKeyColumn<TABLE> columnA, NSmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator %(NSmallIntegerKeyColumn<TABLE> columnA, SmallIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short> operator %(NSmallIntegerKeyColumn<TABLE> columnA, short value)
    {
      return new NumericCondition<SmallIntegerKeyColumn<TABLE>, NSmallIntegerKeyColumn<TABLE>, short>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<short> integerList)
    {
      return (Condition) new InCondition<short>(this, integerList);
    }

    public Condition NotIn(IList<short> integerList)
    {
      return (Condition) new NotInCondition<short>(this, integerList);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params short[] values)
    {
      return (Condition) new InCondition<short>(this, values);
    }

    public Condition NotIn(params short[] values)
    {
      return (Condition) new NotInCondition<short>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return dataReader.GetInt16(columnIndex);
    }

    public short ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return obj == null ? short.MinValue : (short)obj;
    }

    public void SetValue(Record record, short? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, short value)
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
