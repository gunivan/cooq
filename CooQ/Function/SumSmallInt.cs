using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class SumSmallInt : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public short? this[int pIndex, IResult pResult]
    {
      get
      {
        return (short?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public SumSmallInt(SmallIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public SumSmallInt(NSmallIntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "SUM(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.Name + ")" + this.GetWindowFunctionSql(useAlias);
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new short?(dataReader.GetInt16(columnIndex));
    }
  }
}
