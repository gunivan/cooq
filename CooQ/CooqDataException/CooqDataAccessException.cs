using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
