using CooQ.Interfaces;
using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class ColumnCondition : Condition
  {
    internal ColumnCondition(ColumnBase pLeft, Operator dbOperator, ColumnBase pRight)
      : base(pLeft, dbOperator, pRight)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft column cannot be null");
      if (pRight == null)
        throw new NullReferenceException("pRight column cannot be null");
    }

    internal ColumnCondition(ColumnBase pLeft, Operator dbOperator, object pRight)
      : base(pLeft, dbOperator, pRight)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft column cannot be null");
      if (pRight == null)
        throw new NullReferenceException("pRight value cannot be null");
    }

    internal ColumnCondition(IFunction pLeft, Operator dbOperator, object pRight)
      : base(pLeft, dbOperator, pRight)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (pRight == null)
        throw new NullReferenceException("pRight cannot be null");
    }

    internal ColumnCondition(INumericCondition pLeft, Operator dbOperator, object pRight)
      : base(pLeft, dbOperator, pRight)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (pRight == null)
        throw new NullReferenceException("pRight cannot be null");
    }
  }
}
