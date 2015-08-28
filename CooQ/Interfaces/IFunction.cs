using CooQ;
using CooQ.Interfaces;

namespace CooQ.Interfaces
{
  public interface IFunction : ISelectable, ISelectableColumns, IOrderByColumn
  {
    string GetFunctionSql(DatabaseBase database, bool useAlias);
  }
}
