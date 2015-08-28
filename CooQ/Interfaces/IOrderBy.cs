using CooQ;

namespace CooQ.Interfaces
{
  public interface IOrderBy : IAppend, IUseParams, ITimeout, IExecute
  {
    /// <summary>
    /// Query order by clause
    /// 
    /// </summary>
    IAppend OrderBy(params IOrderByColumn[] orderByColumns);

    /// <summary>
    /// Union query
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IDistinct Union(ISelectableColumns pField, params ISelectableColumns[] pFields);

    /// <summary>
    /// Union All query
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IDistinct UnionAll(ISelectableColumns pField, params ISelectableColumns[] pFields);

    /// <summary>
    /// Intersect query
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IDistinct Intersect(ISelectableColumns pField, params ISelectableColumns[] pFields);

    /// <summary>
    /// Except query
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IDistinct Except(ISelectableColumns pField, params ISelectableColumns[] pFields);
  }
}
