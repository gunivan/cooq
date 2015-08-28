using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class OrCondition : Condition
  {
    public OrCondition(Condition conditionA, Condition conditionB)
      : base(conditionA, Operator.OR, conditionB)
    {
      if (conditionA == null)
        throw new NullReferenceException("conditionA cannot be null");
      if (conditionB == null)
        throw new NullReferenceException("conditionB cannot be null");
    }
  }
}
