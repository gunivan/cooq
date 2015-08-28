using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MinInteger : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public int? this[int pIndex, IResult pResult]
    {
      get
      {
        return (int?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MinInteger(IntegerColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MinInteger(NIntegerColumn column)
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
      if (dataReader.GetFieldType(columnIndex) == typeof (long))
        return new int?(Convert.ToInt32(dataReader.GetInt64(columnIndex)));
      return new int?(dataReader.GetInt32(columnIndex));
    }
  }
}
