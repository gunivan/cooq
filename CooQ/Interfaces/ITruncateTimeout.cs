namespace CooQ.Interfaces
{
  public interface ITruncateTimeout : ITrucateExecute
  {
    ITrucateExecute Timeout(int pTimeout);
  }
}
