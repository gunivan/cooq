using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MinBigInteger : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public long? this[int pIndex, IResult pResult]
    {
      get
      {
        return (long?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MinBigInteger(BigIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MinBigInteger(NBigIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "MIN(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")" + this.GetWindowFunctionSql(useAlias);
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new long?(dataReader.GetInt64(columnIndex));
    }
  }
}
