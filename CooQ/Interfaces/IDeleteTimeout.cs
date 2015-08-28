using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IDeleteTimeout : IDeleteReturning, IDeleteExecute
  {
    /// <summary>
    /// Set query timeout. Overrides the default in Settings.DefaultTimeout
    /// 
    /// </summary>
    /// <param name="seconds"/>
    /// <returns/>
    IDeleteReturning Timeout(int seconds);
  }
}
