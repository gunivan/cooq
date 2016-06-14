using System;

namespace CooQ.CooqDataException
{
  /// <summary>
  /// Exception for runtime
  /// </summary>
  public class CooqDataAccessException : System.Exception
  {

    public CooqDataAccessException(string message)
      : base(message)
    {
    }
    public CooqDataAccessException(string message, Exception e)
      : base(message, e)
    {
    }
  }
}
