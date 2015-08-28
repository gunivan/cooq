using CooQ;
using CooQ.Interfaces;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class Count : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;
    private readonly bool mDistinct;

    public int? this[int pIndex, IResult pResult]
    {
      get
      {
        return (int?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    /// <summary>
    /// Count(*)
    /// 
    /// </summary>
    public Count()
    {
      this.mColumn = null;
      this.mDistinct = false;
    }

    /// <summary>
    /// Count(column)
    /// 
    /// </summary>
    /// <param name="column"/>
    public Count(ColumnBase column)
      : this(column, false)
    {
    }

    /// <summary>
    /// Count(distinct column)
    /// 
    /// </summary>
    /// <param name="column"/><param name="pDistinct"/>
    public Count(ColumnBase column, bool pDistinct)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDistinct = pDistinct;
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
      string str;
      if (this.mColumn == null)
        str = "COUNT(*)" + this.GetWindowFunctionSql(useAlias);
      else
        str = "COUNT(" + (this.mDistinct ? " DISTINCT " : string.Empty) + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")" + this.GetWindowFunctionSql(useAlias);
      return str;
    }
  }
}
