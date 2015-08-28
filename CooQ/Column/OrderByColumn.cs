using CooQ.Interfaces;
using CooQ.Types;
using System;

namespace CooQ.Column
{
  public sealed class OrderByColumn : IOrderByColumn
  {
    private readonly ISelectable column;
    private readonly OrderByType mOrderBy;

    public ISelectable Column
    {
      get
      {
        return this.column;
      }
    }

    internal OrderByType OrderBy
    {
      get
      {
        return this.mOrderBy;
      }
    }

    public OrderByColumn GetOrderByColumn
    {
      get
      {
        return this;
      }
    }

    internal OrderByColumn(ISelectable column, OrderByType pOrderBy)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.column = column;
      this.mOrderBy = pOrderBy;
    }
  }
}
