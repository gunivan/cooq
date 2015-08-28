using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class AvgBigInteger : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public Decimal? this[int pIndex, IResult pResult]
    {
      get
      {
        return (Decimal?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public AvgBigInteger(BigIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public AvgBigInteger(NBigIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "AVG(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return this.GetValueAsDecimal(dataReader, columnIndex);
    }
  }
}
