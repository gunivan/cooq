using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class MinDateTime<T> : DateTimeFunctionBase
  {
    private readonly ColumnBase mColumn;

    public DateTime? this[int pIndex, IResult pResult]
    {
      get
      {
        return (DateTime?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public MinDateTime(DateTimeColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public MinDateTime(NDateTimeColumn column)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "MIN(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.Name + ")";
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new DateTime?(dataReader.GetDateTime(columnIndex));
    }
  }
}
