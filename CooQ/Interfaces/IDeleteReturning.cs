using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IDeleteReturning : IDeleteExecute
  {
    IDeleteExecute Returning(params ColumnBase[] columns);
  }
}
