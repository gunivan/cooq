using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQ.CooqDataException
{
  /// <summary>
  /// Exception for precondition check
  /// </summary>
  public class CooqPreconditionException : System.Exception
  {
    public CooqPreconditionException(string message)
      : base(message)
    {
    }
    public CooqPreconditionException(string message, Exception e)
      : base(message, e)
    {
    }

  }
}
