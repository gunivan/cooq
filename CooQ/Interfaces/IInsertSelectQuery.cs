using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IInsertSelectQuery
  {
    IInsertSelectExecute Query(IExecute selectQuery);
  }
}
