using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IFrom
  {
    /// <summary>
    /// From table
    /// 
    /// </summary>
    IJoin From(TableBase table, params string[] hints);
  }
}
