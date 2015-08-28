using System;

namespace CooQ.Attributes
{
  [AttributeUsage(AttributeTargets.Field)]
  public class ColumnAttribute : Attribute
  {
    public string Description { get; set; }

    public ColumnAttribute(string desc)
    {
      this.Description = desc ?? string.Empty;
    }
  }
}
