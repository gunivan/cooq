using CooQ.Builder;
using CooQ.Core;
using CooQ.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CooQ
{
  /// <summary>
  /// Abstract table
  /// 
  /// </summary>
  public abstract class TableBase : ISelectableColumns
  {
    /// <summary>
    /// Counter used to name table aliases used in queries
    /// 
    /// </summary>
    private static readonly AlaisCounter ALIAS_COUNTER = new AlaisCounter();
    private List<ColumnBase> mColumns = new List<ColumnBase>();
    private readonly DatabaseBase defaultDatabase;
    private readonly string tableName;
    private readonly string alias;
    private readonly Type rowType;
    private readonly bool isTemporaryTable;
    private readonly bool? useConcurrenyChecking;

    public DatabaseBase DefaultDatabase
    {
      get
      {
        return this.defaultDatabase;
      }
    }

    /// <summary>
    /// Name of table in database.
    /// 
    /// </summary>
    public string Name
    {
      get
      {
        return this.tableName;
      }
    }

    /// <summary>
    /// Columns that belong to table
    /// 
    /// </summary>
    public IList<ColumnBase> Columns
    {
      get
      {
        return (IList<ColumnBase>)new List<ColumnBase>((IEnumerable<ColumnBase>)this.mColumns.ToArray());
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ISelectable[] SelectableColumns
    {
      get
      {
        return (ISelectable[])this.mColumns.ToArray();
      }
    }

    internal Type RowType
    {
      get
      {
        return this.rowType;
      }
    }

    /// <summary>
    /// Returns true if table is a temporary table.
    /// 
    /// </summary>
    public bool IsTemporaryTable
    {
      get
      {
        return this.isTemporaryTable;
      }
    }

    /// <summary>
    /// If true row updates use all column values to find row in table. If false only the primary key columns are used to find row.
    ///             If null then the gloabl setting Settings.UseConcurrenyChecking value is used.
    /// 
    /// </summary>
    public bool? UseConcurrenyChecking
    {
      get
      {
        return this.useConcurrenyChecking;
      }
    }

    /// <summary>
    /// Tables alias
    /// 
    /// </summary>
    internal string Alias
    {
      get
      {
        return this.alias;
      }
    }

    protected TableBase(DatabaseBase db, string tableName, Type recordType)
      : this(db, tableName, recordType, false, new bool?())
    {
    }

    protected TableBase(DatabaseBase db, string tableName, bool pUseConcurrenyChecking, Type recordType)
      : this(db, tableName, recordType, false, new bool?(pUseConcurrenyChecking))
    {
    }

    /// <summary>
    /// Creates a temporary table with an auto generated table name
    /// 
    /// </summary>
    /// <param name="recordType"/>
    protected TableBase(Type recordType)
    {
      if (!recordType.IsSubclassOf(typeof(Record)))
        throw new Exception("recordType must be a subclass of Sql.ARow");
      this.rowType = recordType;
      this.isTemporaryTable = true;
      string nextAlias = TableBase.GetNextAlias();
      this.tableName = "Temp_" + nextAlias;
      this.alias = "_" + nextAlias;
      this.useConcurrenyChecking = new bool?();
    }

    private TableBase(DatabaseBase db, string tableName, Type recordType, bool pIsTemporaryTable, bool? pUseConcurrenyChecking)
    {
      if (db == null)
        throw new NullReferenceException("DefaultDatabase cannot be null");
      if (string.IsNullOrWhiteSpace(tableName))
        throw new Exception("tableName cannot be null or empty");
      if (recordType == (Type)null)
        throw new NullReferenceException("recordType cannot be null");
      if (!recordType.IsSubclassOf(typeof(Record)))
        throw new Exception("recordType must be a subclass of Sql.ARow");
      this.defaultDatabase = db;
      this.tableName = tableName;
      this.rowType = recordType;
      this.isTemporaryTable = pIsTemporaryTable;
      this.alias = "_" + TableBase.GetNextAlias();
      this.useConcurrenyChecking = pUseConcurrenyChecking;
    }

    /// <summary>
    /// Sets columns on table
    /// 
    /// </summary>
    /// <param name="columns"/>
    protected void AddColumns(params ColumnBase[] columns)
    {
      if (columns == null || columns.Length == 0)
        throw new Exception("columns cannot be null or empty");
      if (this.mColumns.Count > 0)
        throw new Exception("Columns are already set on table");
      this.mColumns.AddRange((IEnumerable<ColumnBase>)columns);
    }

    /// <summary>
    /// Returns next table alias
    /// 
    /// </summary>
    /// 
    /// <returns/>
    private static string GetNextAlias()
    {
      lock (TableBase.ALIAS_COUNTER)
        return TableBase.ALIAS_COUNTER.GetNextAlias();
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
