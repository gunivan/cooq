using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IInsertTimeout : IReturning, IInsertExecute
  {
    /// <summary>
    /// Set query timeout. Overrides the default in Settings.DefaultTimeout
    /// 
    /// </summary>
    /// <param name="seconds"/>
    /// <returns/>
    IInsertExecute Timeout(int seconds);
  }
}
