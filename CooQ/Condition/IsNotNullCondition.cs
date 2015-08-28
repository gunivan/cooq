using CooQ.Interfaces;
using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class IsNotNullCondition : Condition
  {
    public IsNotNullCondition(ISelectable pSelectable)
      : base(pSelectable, Operator.IS_NOT_NULL, null)
    {
      if (pSelectable == null)
        throw new NullReferenceException("pSelectable cannot be null");
    }
  }
}
