using CooQ;
using CooQ.Column;
using CooQ.Conditions;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;

namespace CooQ.Function
{
  public abstract class NumericFunctionBase : IFunction, ISelectable, ISelectableColumns, IOrderByColumn, IWindowFunction
  {
    private WindowFunction mWindowFunction;

    public ISelectable[] SelectableColumns
    {
      get
      {
        return new ISelectable[1]
        {
          (ISelectable) this
        };
      }
    }

    /// <summary>
    /// Order ascending
    /// 
    /// </summary>
    public OrderByColumn ASC
    {
      get
      {
        return new OrderByColumn((ISelectable)this, OrderByType.ASC);
      }
    }

    /// <summary>
    /// Order Descending
    /// 
    /// </summary>
    public OrderByColumn DESC
    {
      get
      {
        return new OrderByColumn((ISelectable)this, OrderByType.DESC);
      }
    }

    /// <summary>
    /// IS NULL sql condition
    /// 
    /// </summary>
    public Condition IsNull
    {
      get
      {
        return (Condition)new IsNullCondition((ISelectable)this);
      }
    }

    /// <summary>
    /// IS NOT NULL sql condition
    /// 
    /// </summary>
    public Condition IsNotNull
    {
      get
      {
        return (Condition)new IsNotNullCondition((ISelectable)this);
      }
    }

    /// <summary>
    /// Default ordering
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderByColumn GetOrderByColumn
    {
      get
      {
        return new OrderByColumn((ISelectable)this, OrderByType.Default);
      }
    }

    public static Condition operator ==(NumericFunctionBase columnA, int value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)value);
    }

    public static Condition operator ==(NumericFunctionBase columnA, long value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)value);
    }

    public static Condition operator ==(NumericFunctionBase columnA, Decimal value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)value);
    }

    public static Condition operator ==(NumericFunctionBase columnA, short value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)value);
    }

    public static Condition operator ==(NumericFunctionBase columnA, float value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)value);
    }

    public static Condition operator ==(NumericFunctionBase columnA, double value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)value);
    }

    public static Condition operator ==(NumericFunctionBase columnA, NumericFunctionBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)columnB);
    }

    public static Condition operator ==(NumericFunctionBase columnA, NumericColumnBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.EQUALS, (object)columnB);
    }

    public static Condition operator !=(NumericFunctionBase columnA, int value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)value);
    }

    public static Condition operator !=(NumericFunctionBase columnA, long value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)value);
    }

    public static Condition operator !=(NumericFunctionBase columnA, Decimal value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)value);
    }

    public static Condition operator !=(NumericFunctionBase columnA, short value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)value);
    }

    public static Condition operator !=(NumericFunctionBase columnA, float value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)value);
    }

    public static Condition operator !=(NumericFunctionBase columnA, double value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)value);
    }

    public static Condition operator !=(NumericFunctionBase columnA, NumericFunctionBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)columnB);
    }

    public static Condition operator !=(NumericFunctionBase columnA, NumericColumnBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.NOT_EQUALS, (object)columnB);
    }

    public static Condition operator >(NumericFunctionBase columnA, int value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)value);
    }

    public static Condition operator >(NumericFunctionBase columnA, long value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)value);
    }

    public static Condition operator >(NumericFunctionBase columnA, Decimal value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)value);
    }

    public static Condition operator >(NumericFunctionBase columnA, short value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)value);
    }

    public static Condition operator >(NumericFunctionBase columnA, float value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)value);
    }

    public static Condition operator >(NumericFunctionBase columnA, double value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)value);
    }

    public static Condition operator >(NumericFunctionBase columnA, NumericFunctionBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)columnB);
    }

    public static Condition operator >(NumericFunctionBase columnA, NumericColumnBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN, (object)columnB);
    }

    public static Condition operator >=(NumericFunctionBase columnA, int value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator >=(NumericFunctionBase columnA, long value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator >=(NumericFunctionBase columnA, Decimal value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator >=(NumericFunctionBase columnA, short value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator >=(NumericFunctionBase columnA, float value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator >=(NumericFunctionBase columnA, double value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator >=(NumericFunctionBase columnA, NumericFunctionBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)columnB);
    }

    public static Condition operator >=(NumericFunctionBase columnA, NumericColumnBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.GREATER_THAN_OR_EQUAL, (object)columnB);
    }

    public static Condition operator <(NumericFunctionBase columnA, int value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)value);
    }

    public static Condition operator <(NumericFunctionBase columnA, long value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)value);
    }

    public static Condition operator <(NumericFunctionBase columnA, Decimal value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)value);
    }

    public static Condition operator <(NumericFunctionBase columnA, short value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)value);
    }

    public static Condition operator <(NumericFunctionBase columnA, float value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)value);
    }

    public static Condition operator <(NumericFunctionBase columnA, double value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)value);
    }

    public static Condition operator <(NumericFunctionBase columnA, NumericFunctionBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)columnB);
    }

    public static Condition operator <(NumericFunctionBase columnA, NumericColumnBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN, (object)columnB);
    }

    public static Condition operator <=(NumericFunctionBase columnA, int value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator <=(NumericFunctionBase columnA, long value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator <=(NumericFunctionBase columnA, Decimal value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator <=(NumericFunctionBase columnA, short value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator <=(NumericFunctionBase columnA, float value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator <=(NumericFunctionBase columnA, double value)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)value);
    }

    public static Condition operator <=(NumericFunctionBase columnA, NumericFunctionBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)columnB);
    }

    public static Condition operator <=(NumericFunctionBase columnA, NumericColumnBase columnB)
    {
      return (Condition)new ColumnCondition((IFunction)columnA, Operator.LESS_THAN_OR_EQUAL, (object)columnB);
    }

    public Condition In(IList<int> list)
    {
      return (Condition)new InCondition<int>((IFunction)this, list);
    }

    public Condition NotIn(IList<int> list)
    {
      return (Condition)new NotInCondition<int>((IFunction)this, list);
    }

    public Condition In(IList<Decimal> list)
    {
      return (Condition)new InCondition<Decimal>((IFunction)this, list);
    }

    public Condition NotIn(IList<Decimal> list)
    {
      return (Condition)new NotInCondition<Decimal>((IFunction)this, list);
    }

    public Condition In(IList<short> list)
    {
      return (Condition)new InCondition<short>((IFunction)this, list);
    }

    public Condition NotIn(IList<short> list)
    {
      return (Condition)new NotInCondition<short>((IFunction)this, list);
    }

    public Condition In(IList<float> list)
    {
      return (Condition)new InCondition<float>((IFunction)this, list);
    }

    public Condition NotIn(IList<float> list)
    {
      return (Condition)new NotInCondition<float>((IFunction)this, list);
    }

    public Condition In(IList<double> list)
    {
      return (Condition)new InCondition<double>((IFunction)this, list);
    }

    public Condition NotIn(IList<double> list)
    {
      return (Condition)new NotInCondition<double>((IFunction)this, list);
    }

    public abstract string GetFunctionSql(DatabaseBase database, bool useAlias);

    public abstract object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex);

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    public override string ToString()
    {
      return base.ToString();
    }

    protected Decimal? GetValueAsDecimal(DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return new Decimal?();
      Type fieldType = dataReader.GetFieldType(columnIndex);
      return !(fieldType == typeof(long)) ? (!(fieldType == typeof(Decimal)) ? (!(fieldType == typeof(short)) ? new Decimal?((Decimal)dataReader.GetInt32(columnIndex)) : new Decimal?(Convert.ToDecimal(dataReader.GetInt16(columnIndex)))) : new Decimal?(Convert.ToDecimal(dataReader.GetDecimal(columnIndex)))) : new Decimal?(Convert.ToDecimal(dataReader.GetInt64(columnIndex)));
    }

    protected double? GetValueAsDouble(DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return new double?();
      return !(dataReader.GetFieldType(columnIndex) == typeof(float)) ? new double?(Convert.ToDouble(dataReader.GetInt64(columnIndex))) : new double?(Convert.ToDouble(dataReader.GetFloat(columnIndex)));
    }

    protected string GetWindowFunctionSql(bool useAlias)
    {
      return this.mWindowFunction != null ? this.mWindowFunction.GetSql(useAlias) : string.Empty;
    }

    public NumericFunctionBase Over()
    {
      if (this.mWindowFunction == null)
        this.mWindowFunction = new WindowFunction();
      this.mWindowFunction.SetOverPartitionBy((ColumnBase[])null);
      return this;
    }

    public NumericFunctionBase OverPartitionBy(params ColumnBase[] columns)
    {
      if (this.mWindowFunction == null)
        this.mWindowFunction = new WindowFunction();
      this.mWindowFunction.SetOverPartitionBy(columns);
      return this;
    }

    public NumericFunctionBase OrderBy(params IOrderByColumn[] orderByColumns)
    {
      if (this.mWindowFunction == null)
        this.mWindowFunction = new WindowFunction();
      this.mWindowFunction.SetOrderBy(orderByColumns);
      return this;
    }
  }
}
