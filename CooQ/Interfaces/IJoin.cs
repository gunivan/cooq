using CooQ;
using CooQ.Conditions;

namespace CooQ.Interfaces
{
  public interface IJoin : IWhere, IGroupBy, IOrderBy, IAppend, IUseParams, ITimeout, IExecute
  {
    /// <summary>
    /// Joins table using condition condition
    /// 
    /// </summary>
    IJoin Join(TableBase table, Condition condition, params string[] hints);

    /// <summary>
    /// Joins table using condition condition if includeJoin is true
    /// 
    /// </summary>
    IJoin JoinIf(bool includeJoin, TableBase table, Condition condition, params string[] hints);

    /// <summary>
    /// Left joins table using condition condition
    /// 
    /// </summary>
    IJoin LeftJoin(TableBase table, Condition condition, params string[] hints);

    /// <summary>
    /// Left joins table using condition condition if includeJoin is true
    /// 
    /// </summary>
    IJoin LeftJoinIf(bool includeJoin, TableBase table, Condition condition, params string[] hints);

    /// <summary>
    /// Right joins table using condition condition
    /// 
    /// </summary>
    IJoin RightJoin(TableBase table, Condition condition, params string[] hints);

    /// <summary>
    /// Right joins table using condition condition if includeJoin is true
    /// 
    /// </summary>
    IJoin RightJoinIf(bool includeJoin, TableBase table, Condition condition, params string[] hints);
  }
}
