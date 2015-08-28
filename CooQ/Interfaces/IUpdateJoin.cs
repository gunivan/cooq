using CooQ;
using CooQ.Conditions;

namespace CooQ.Interfaces
{
  public interface IUpdateJoin : IUpdateWhere
  {
    IUpdateJoin Join(TableBase table, Condition condition);
  }
}
