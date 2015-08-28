using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.ComponentModel;

namespace CooQ.Conditions
{
  public class NumericCondition<COLUMN, NCOLUMN, TYPE> : INumericCondition
  {
    private readonly object mLeft;
    private readonly NumericOperator mOperator;
    private readonly object mRight;

    public object Left
    {
      get
      {
        return this.mLeft;
      }
    }

    public NumericOperator Operator
    {
      get
      {
        return this.mOperator;
      }
    }

    public object Right
    {
      get
      {
        return this.mRight;
      }
    }

    internal NumericCondition(object pLeft, NumericOperator dbOperator, object pRight)
    {
      this.mLeft = pLeft;
      this.mOperator = dbOperator;
      this.mRight = pRight;
    }

    public static Condition operator ==(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return (Condition) new ColumnCondition((INumericCondition) columnA, CooQ.Types.Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.EQUALS, value);
    }

    public static Condition operator !=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.LESS_THAN, value);
    }

    public static Condition operator <=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return (Condition)new ColumnCondition((INumericCondition)columnA, CooQ.Types.Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator +(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator +(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator +(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator -(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator -(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator -(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator /(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator /(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator /(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator *(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, COLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator *(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, NCOLUMN columnB)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator *(NumericCondition<COLUMN, NCOLUMN, TYPE> columnA, TYPE value)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<COLUMN, NCOLUMN, TYPE> operator *(TYPE value, NumericCondition<COLUMN, NCOLUMN, TYPE> columnA)
    {
      return new NumericCondition<COLUMN, NCOLUMN, TYPE>(columnA, NumericOperator.MULTIPLY, value);
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

    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Type GetType()
    {
      return base.GetType();
    }
  }
}
