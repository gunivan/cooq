using CooQ;

namespace CooQ.Interfaces
{
  public interface IFromInto : IFrom
  {
    /// <summary>
    /// Into table
    /// 
    /// </summary>
    IFrom Into(TableBase table);
  }
}
