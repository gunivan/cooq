using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class AndCondition : Condition
  {
    public AndCondition(Condition conditionA, Condition conditionB)
      : base(conditionA, Operator.AND, conditionB)
    {
      if (conditionA == null)
        throw new CooqDataException.CooqPreconditionException("conditionA cannot be null");
      if (conditionB == null)
        throw new CooqDataException.CooqPreconditionException("conditionB cannot be null");
    }
  }
}
