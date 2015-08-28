using CooQ.Types;
using System;

namespace CooQ.Conditions
{
  public class BetweenAndCondition : Condition
  {
    public object From { get; set; }
    public object To { get; set; }
    public BetweenAndCondition(ColumnBase column, object from, object to)   
      :base(column, Operator.BETWEEN, from)
    {
      if (column == null)
        throw new CooqDataException.CooqPreconditionException("column cannot be null");
      if (from == null || to == null)
        throw new CooqDataException.CooqPreconditionException("from or to cannot be null");
      this.From = from;
      this.To = to;
    }
  }
}
