using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface ITimeout : IExecute
  {
    /// <summary>
    /// Set query timeout. Overrides the default in Settings.DefaultTimeout
    /// 
    /// </summary>
    /// <param name="seconds"/>
    /// <returns/>
    IExecute Timeout(int seconds);
  }
}
