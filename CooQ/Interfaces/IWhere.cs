using CooQ;
using CooQ.Conditions;

namespace CooQ.Interfaces
{
  public interface IWhere : IGroupBy, IOrderBy, IAppend, IUseParams, ITimeout, IExecute
  {
    /// <summary>
    /// Where condition of query
    /// 
    /// </summary>
    IGroupBy Where(Condition condition);
  }
}
