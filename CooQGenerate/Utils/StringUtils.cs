using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQGenerate.Utils
{
  public class StringUtils
  {
    public static String Capitalize(String s)
    {
      if (String.IsNullOrEmpty(s))
        return "";
      return s.Substring(0, 1).ToUpper() + s.Substring(1);
    }

    public static String GetItemByIndex(String[] arr, int index)
    {
      return (index >= 0 && index < arr.Length) ? arr[index].Trim() : "";
    }

    public static String GetPropertyValue(String key, String propertyOperator = "=")
    {
      if (null == key)
        return String.Empty;
      return key.Contains(propertyOperator) ? key.Split(new String[] { propertyOperator }, StringSplitOptions.RemoveEmptyEntries)[1] : "";
    }
  }
}
