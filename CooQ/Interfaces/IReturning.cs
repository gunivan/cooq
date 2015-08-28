using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IReturning : IInsertExecute
  {
    IInsertExecute Returning(params ColumnBase[] columns);  
  }
}
