using CooQ;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Text;

namespace CooQ.Function
{
  internal class WindowFunction
  {
    private ColumnBase[] mColumns;
    private IOrderByColumn[] mOrderByColumns;

    public void SetOverPartitionBy(params ColumnBase[] columns)
    {
      if (this.mColumns != null)
        throw new Exception("Cannot call OverPartitionBy(...) more than once");
      this.mColumns = columns != null ? columns : new ColumnBase[0];
    }

    public void SetOrderBy(params IOrderByColumn[] orderByColumns)
    {
      if (orderByColumns == null)
        throw new NullReferenceException("orderByColumns cannot be null");
      if (orderByColumns.Length == 0)
        throw new Exception("orderByColumns cannot be empty");
      if (this.mOrderByColumns != null)
        throw new Exception("Cannot call OrderBy(...) more than once");
      this.mOrderByColumns = orderByColumns;
      int index = 0;
      while (index < this.mOrderByColumns.Length)
      {
        if (!(this.mOrderByColumns[index] is ColumnBase))
          throw new Exception("All values in orderByColumns must be or type ColumnBase");
        checked { ++index; }
      }
    }

    public string GetSql(bool useAlias)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" OVER(");
      if (this.mColumns != null && this.mColumns.Length > 0)
      {
        stringBuilder.Append("PARTITION BY ");
        int index = 0;
        while (index < this.mColumns.Length)
        {
          ColumnBase ColumnBase = this.mColumns[index];
          if (index > 0)
            stringBuilder.Append(",");
          if (useAlias)
            stringBuilder.Append(ColumnBase.Table.Alias).Append(".");
          stringBuilder.Append(ColumnBase.ColumnName);
          checked { ++index; }
        }
      }
      if (this.mOrderByColumns != null && this.mOrderByColumns.Length > 0)
      {
        stringBuilder.Append(" ORDER BY ");
        int index = 0;
        while (index < this.mOrderByColumns.Length)
        {
          IOrderByColumn orderByColumn = this.mOrderByColumns[index];
          ColumnBase ColumnBase = (ColumnBase)orderByColumn;
          if (index > 0)
            stringBuilder.Append(",");
          if (useAlias)
            stringBuilder.Append(ColumnBase.Table.Alias).Append(".");
          stringBuilder.Append(ColumnBase.ColumnName);
          if (orderByColumn.GetOrderByColumn.OrderBy == OrderByType.ASC)
            stringBuilder.Append(" ASC");
          if (orderByColumn.GetOrderByColumn.OrderBy == OrderByType.DESC)
            stringBuilder.Append(" DESC");
          checked { ++index; }
        }
      }
      stringBuilder.Append(")");
      return stringBuilder.ToString();
    }
  }
}
