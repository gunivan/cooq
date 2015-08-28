
namespace CooQ.Interfaces
{
  public interface IAppend : IUseParams, ITimeout, IExecute
  {
    /// <summary>
    /// Allows options to be appended to the end of the query.
    ///             Example: Sql Server - .OPTION("OPTION(MAXDOP 1)").Execute();
    ///             Or
    ///             Example: PostgreSql - .OPTION("FOR UPDATE").Execute();
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IUseParams Append(string pCustomSql);
  }
}
