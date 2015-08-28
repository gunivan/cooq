using CooQ;                               
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IInsertSelect
  {
    IInsertSelectQuery Columns(params ColumnBase[] columns);                                          
  }
}
