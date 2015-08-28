using CooQ.Conditions;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ
{

  using CooQ.Column;
  using CooQ.Function;
  using CooQ.Interfaces;
  using CooQ.Types;
  using System;
  /// <summary>
  /// Abstract column
  /// 
  /// </summary>
  public abstract class ColumnBase : IOrderByColumn, ISelectable, ISelectableColumns
  {
    private readonly TableBase mTable;
    private readonly string mColumnName;
    private readonly bool mIsPrimaryKey;
    private bool mIsAutoId;

    /// <summary>
    /// Table that column belongs to.
    /// 
    /// </summary>
    public TableBase Table
    {
      get
      {
        return this.mTable;
      }
    }

    /// <summary>
    /// Name of column in table
    /// 
    /// </summary>
    public string ColumnName
    {
      get
      {
        return this.mColumnName;
      }
    }

    /// <summary>
    /// Returns true if column is part of its tables primary key.
    /// 
    /// </summary>
    public bool IsPrimaryKey
    {
      get
      {
        return this.mIsPrimaryKey;
      }
    }

    /// <summary>
    /// Returns true is column is an auto id field
    /// 
    /// </summary>
    public bool IsAutoId
    {
      get
      {
        return this.mIsAutoId;
      }
      protected set
      {
        this.mIsAutoId = value;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ISelectable[] SelectableColumns
    {
      get
      {
        return new ISelectable[1]
        {
          (ISelectable) this
        };
      }
    }

    /// <summary>
    /// System data type this column maps to
    /// 
    /// </summary>
    public abstract DbType DbType { get; }

    /// <summary>
    /// Order ascending
    /// 
    /// </summary>
    public OrderByColumn ASC
    {
      get
      {
        return new OrderByColumn((ISelectable)this, OrderByType.ASC);
      }
    }

    /// <summary>
    /// Order Descending
    /// 
    /// </summary>
    public OrderByColumn DESC
    {
      get
      {
        return new OrderByColumn((ISelectable)this, OrderByType.DESC);
      }
    }

    /// <summary>
    /// Default ordering
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderByColumn GetOrderByColumn
    {
      get
      {
        return new OrderByColumn((ISelectable)this, OrderByType.Default);
      }
    }

    /// <summary>
    /// IS NULL sql condition
    /// 
    /// </summary>
    public Condition IsNull
    {
      get
      {
        return new IsNullCondition((ISelectable)this);
      }
    }

    /// <summary>
    /// IS NOT NULL sql condition
    /// 
    /// </summary>
    public Condition IsNotNull
    {
      get
      {
        return new IsNotNullCondition((ISelectable)this);
      }
    }

    public override string ToString()
    {
      return ColumnName;
    }

    /// <summary>
    /// Abstract column
    /// 
    /// </summary>
    /// <param name="table">Name of table in database</param><param name="columnName">Name of column in table</param><param name="isPrimaryKey">true if column is part of its tables primary key</param>
    protected ColumnBase(TableBase table, string columnName, bool isPrimaryKey)
    {
      if (table == null)
        throw new CooqDataException.CooqPreconditionException("table cannot be null");
      if (string.IsNullOrWhiteSpace(columnName))
        throw new CooqDataException.CooqPreconditionException("columnName cannot be null");
      this.mTable = table;
      this.mColumnName = columnName;
      this.mIsPrimaryKey = isPrimaryKey;
    }

    /// <summary>
    /// Returns the default type. For example an integer column would return 0. Or a boolean column would return false
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public abstract object GetDefaultType();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex);

    public T As<T>(DataRow row)
    {
      return row.Field<T>(ColumnName);
    }
    public void Set<T>(DataRow row, T value)
    {
      row.SetField<T>(ColumnName, value);
    }

    public void Set(DataRow row, short value)
    {
      row.SetField<short>(ColumnName, value);
    }

    public void Set(DataRow row, short? value)
    {
      row.SetField<short?>(ColumnName, value);
    }

    public void Set(DataRow row, int value)
    {
      row.SetField<int>(ColumnName, value);
    }

    public void Set(DataRow row, int? value)
    {
      row.SetField<int?>(ColumnName, value);
    }

    public void Set(DataRow row, long value)
    {
      row.SetField<long>(ColumnName, value);
    }

    public void Set(DataRow row, long? value)
    {
      row.SetField<long?>(ColumnName, value);
    }

    public void Set(DataRow row, string value)
    {
      row.SetField<string>(ColumnName, value);
    }

    public void Set(DataRow row, Decimal value)
    {
      row.SetField<decimal>(ColumnName, value);
    }

    public void Set(DataRow row, Decimal? value)
    {
      row.SetField<decimal?>(ColumnName, value);
    }

    public void Set(DataRow row, DateTime value)
    {
      row.SetField<DateTime>(ColumnName, value);
    }

    public void Set(DataRow row, DateTime? value)
    {
      row.SetField<DateTime?>(ColumnName, value);
    }

    public void Set(DataRow row, DateTimeOffset value)
    {
      row.SetField<DateTimeOffset>(ColumnName, value);
    }

    public void Set(DataRow row, DateTimeOffset? value)
    {
      row.SetField<DateTimeOffset?>(ColumnName, value);
    }

    public void Set(DataRow row, bool value)
    {
      row.SetField<bool>(ColumnName, value);
    }

    public void Set(DataRow row, bool? value)
    {
      row.SetField<bool?>(ColumnName, value);
    }

    public void Set(DataRow row, Guid value)
    {
      row.SetField<Guid>(ColumnName, value);
    }

    public void Set(DataRow row, Guid? value)
    {
      row.SetField<Guid?>(ColumnName, value);
    }

    public void Set(DataRow row, byte[] value)
    {
      row.SetField<byte[]>(ColumnName, value);
    }

    public Condition BetweenAnd(object from, object to)
    {
      return new BetweenAndCondition(this, from, to);
    }
  }
}
