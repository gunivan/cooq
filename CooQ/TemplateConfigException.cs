using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooQGenerate
{
  class TemplateConfigException : Exception
  {
    public TemplateConfigException(String msg)
      :base(msg)
    {

    }
    public TemplateConfigException(String msg, Exception e)
      :base(msg, e)
    {

    }
  }
}
