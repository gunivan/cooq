using CooQ;

namespace CooQ.Interfaces
{
  public interface IGroupBy : IOrderBy, IAppend, IUseParams, ITimeout, IExecute
  {
    /// <summary>
    /// Group query by columns columns
    /// 
    /// </summary>
    IHaving GroupBy(params ISelectable[] columns);
  }
}
