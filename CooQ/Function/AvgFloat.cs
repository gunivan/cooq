using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class AvgFloat<T> : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public double? this[int pIndex, IResult pResult]
    {
      get
      {
        return (double?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public AvgFloat(FloatColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public AvgFloat(NFloatColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "AVG(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.Name + ")";
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return this.GetValueAsDouble(dataReader, columnIndex);
    }
  }
}
