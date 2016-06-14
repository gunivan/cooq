using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MinDecimal : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public Decimal? this[int pIndex, IResult pResult]
    {
      get
      {
        return (Decimal?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MinDecimal(DecimalColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MinDecimal(NDecimalColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "MIN(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.Name + ")" + this.GetWindowFunctionSql(useAlias);
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new Decimal?(dataReader.GetDecimal(columnIndex));
    }
  }
}
