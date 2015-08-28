using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IUpdateUseParams : IUpdateTimeout, IUpdateReturning, IUpdateExecute
  {
    /// <summary>
    /// Force the query to use parameters or not. If not set then the default is used from Sql.Settings.UseParameters
    /// 
    /// </summary>
    /// <param name="useParameters"/>
    /// <returns/>
    IUpdateTimeout UseParameters(bool useParameters);
  }
}
