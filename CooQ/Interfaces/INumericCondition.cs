using CooQ.Types;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface INumericCondition
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    object Left { get; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    NumericOperator Operator { get; }

    [EditorBrowsable(EditorBrowsableState.Never)]
    object Right { get; }
  }
}
