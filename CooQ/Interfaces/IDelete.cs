using CooQ;
using CooQ.Conditions;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IDelete
  {
    IDeleteUseParams NoWhereCondition { get; }

    IDeleteUseParams Where(Condition condition);                                                                                   
  }
}
