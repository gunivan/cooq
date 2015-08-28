using CooQ;
using CooQ.Function;
using CooQ.Interfaces;

namespace CooQ.Interfaces
{
  public interface IWindowFunction
  {
    NumericFunctionBase OverPartitionBy(params ColumnBase[] columns);

    NumericFunctionBase OrderBy(params IOrderByColumn[] orderByColumns);
  }
}
