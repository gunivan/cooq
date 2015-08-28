using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IInsertUseParams : IInsertTimeout, IReturning, IInsertExecute
  {
    /// <summary>
    /// Force the query to use parameters or not. If not set then the default is used from Sql.Settings.UseParameters
    /// 
    /// </summary>
    /// <param name="useParameters"/>
    /// <returns/>
    IInsertTimeout UseParameters(bool useParameters);
  }
}
