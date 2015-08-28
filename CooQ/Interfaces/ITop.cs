namespace CooQ.Interfaces
{
  public interface ITop : IFromInto, IFrom
  {
    /// <summary>
    /// Selects first top number of rows.
    /// 
    /// </summary>
    IFromInto Top(int records);
  }
}
