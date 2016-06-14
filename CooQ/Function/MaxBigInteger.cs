using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MaxBigInteger<T> : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public long? this[int pIndex, IResult pResult]
    {
      get
      {
        return (long?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MaxBigInteger(BigIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MaxBigInteger(NBigIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "MAX(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.Name + ")" + this.GetWindowFunctionSql(useAlias);
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new long?(dataReader.GetInt64(columnIndex));
    }
  }
}
