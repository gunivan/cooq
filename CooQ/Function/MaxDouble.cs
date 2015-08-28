using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MaxDouble : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;

    public double? this[int pIndex, IResult pResult]
    {
      get
      {
        return (double?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MaxDouble(DoubleColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MaxDouble(NDoubleColumn column)
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
      return new double?(dataReader.GetDouble(columnIndex));
    }
  }
}
