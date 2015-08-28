using CooQ;
using CooQ.Conditions;

namespace CooQ.Interfaces
{
  public interface IHaving : IOrderBy, IAppend, IUseParams, ITimeout, IExecute
  {
    /// <summary>
    /// Query having clause
    /// 
    /// </summary>
    IOrderBy Having(Condition condition);
  }
}
