using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IUpdateReturning : IUpdateExecute
  {
    IUpdateExecute Returning(params ColumnBase[] columns);     
  }
}
