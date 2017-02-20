using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooQGenerate
{
  class CoooQGenerateException : Exception
  {
    public CoooQGenerateException(String msg)
      : base(msg)
    {

    }
    public CoooQGenerateException(String msg, Exception e)
      : base(msg, e)
    {

    }
  }
}
