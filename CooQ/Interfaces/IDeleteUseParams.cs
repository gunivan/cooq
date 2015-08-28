using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IDeleteUseParams : IDeleteTimeout, IDeleteReturning, IDeleteExecute
  {
    /// <summary>
    /// Force the query to use parameters or not. If not set then the default is used from Sql.Settings.UseParameters
    /// 
    /// </summary>
    /// <param name="useParameters"/>
    /// <returns/>
    IDeleteTimeout UseParameters(bool useParameters);
  }
}
