using CooQ.Interfaces;
using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class IsNullCondition : Condition
  {
    public IsNullCondition(ISelectable pSelectable)
      : base(pSelectable, Operator.IS_NULL, null)
    {
      if (pSelectable == null)
        throw new NullReferenceException("pSelectable cannot be null");
    }
  }
}
