using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// A wrapper class of <![CDATA[Dictionary<String, Object>]]>
/// </summary>
namespace CooQ
{
  public class Pair : Dictionary<String, Object>
  {
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("Items:" + this.Keys.Count.ToString() + " {");
      foreach (var key in this.Keys)
      {
        sb.AppendFormat("{0}:{1},", key, this[key]);
      }
      sb.Append("}");
      return sb.ToString();
    }
    public Pair Copy(Pair that)
    {
      if (this == that)
        return this;
      foreach (var item in that.Keys)
      {
        this.Add(item, that[item]);
      }
      return this;
    }
  }
}
