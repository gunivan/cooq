using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooQ.Database
{
  public abstract class DbObject
  {
    private string mName;
    protected string originName;

    public string Name
    {
      get
      {
        return mName;
      }
    }

    public string OriginName
    {
      get
      {
        return originName;
      }
      protected set
      {
        mName = GetNormalizeName(value);
        originName = value;
      }
    }
    private String GetNormalizeName(String name)
    {
      if (name == null)
        return "";
      var arr = name.Split('_');
      var l = new List<String>();
      foreach (var item in arr)
      {
        try
        {
          l.Add(item.Substring(0, 1).ToUpper() + item.Substring(1));
        } catch(Exception e)
        {
          l.Add(item);
        }
      }
      return string.Join("", l);
    }
  }
}
