using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IUpdateTimeout : IUpdateReturning, IUpdateExecute
  {
    /// <summary>
    /// Set query timeout. Overrides the default in Settings.DefaultTimeout
    /// 
    /// </summary>
    /// <param name="seconds"/>
    /// <returns/>
    IUpdateExecute Timeout(int seconds);
  }
}
