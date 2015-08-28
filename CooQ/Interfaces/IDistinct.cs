namespace CooQ.Interfaces
{
  public interface IDistinct : ITop, IFromInto, IFrom
  {
    /// <summary>
    /// Select rows with distinct values
    /// 
    /// </summary>
    ITop Distinct { get; }
  }
}
