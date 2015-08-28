using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MaxFloat<T> : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public float? this[int pIndex, IResult pResult]
    {
      get
      {
        return (float?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MaxFloat(FloatColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MaxFloat(NFloatColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "MAX(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")" + this.GetWindowFunctionSql(useAlias);
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new float?(dataReader.GetFloat(columnIndex));
    }
  }
}
