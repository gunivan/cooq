using CooQ;
using System;

namespace CooQ.Core
{
  public class SetValue
  {
    private readonly ColumnBase mColumn;
    private readonly object mValue;

    public ColumnBase Column
    {
      get
      {
        return this.mColumn;
      }
    }

    public object Value
    {
      get
      {
        return this.mValue;
      }
    }

    public SetValue(ColumnBase column, object value)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mValue = value;
    }
  }
}
