using CooQ.Interfaces;
using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class NestedQueryCondition : Condition
  {
    internal NestedQueryCondition(ColumnBase pLeft, Operator dbOperator, IExecute pQuery)
      : base(pLeft, dbOperator, pQuery)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (pQuery == null)
        throw new NullReferenceException("pQuery cannot be null");
    }
  }
}
