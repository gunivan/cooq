using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class SumDecimal<T> : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public Decimal? this[int pIndex, IResult pResult]
    {
      get
      {
        return (Decimal?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public SumDecimal(DecimalColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public SumDecimal(NDecimalColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "SUM(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")" + this.GetWindowFunctionSql(useAlias);
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new Decimal?(dataReader.GetDecimal(columnIndex));
    }
  }
}
