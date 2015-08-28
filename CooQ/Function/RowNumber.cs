using CooQ;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public class RowNumber : NumericFunctionBase
  {
    public int? this[int pIndex, IResult pResult]
    {
      get
      {
        return (int?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      if (dataReader.GetFieldType(columnIndex) == typeof (long))
        return new int?(Convert.ToInt32(dataReader.GetInt64(columnIndex)));
      return new int?(dataReader.GetInt32(columnIndex));
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      return "ROW_NUMBER()" + this.GetWindowFunctionSql(useAlias);
    }
  }
}
