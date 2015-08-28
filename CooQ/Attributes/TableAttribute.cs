using System;

namespace CooQ.Attributes
{
  [AttributeUsage(AttributeTargets.Class)]
  public class TableAttribute : Attribute
  {
    public string Description { get; set; }

    public TableAttribute(string desc)
    {
      this.Description = desc ?? string.Empty;
    }
  }
}
