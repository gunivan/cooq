using CooQ.Types;
using System;
using System.Data.Common;

namespace CooQ
{
  /// <summary>
  /// Abstract database. Represents a database. Provides methods to create connections.
  /// 
  /// </summary>
  public abstract class DatabaseBase
  {
    private DatabaseType databaseType;

    /// <summary>
    /// Returns database connection string
    /// 
    /// </summary>
    public string ConnectionString { get; protected set; }


    /// <summary>
    /// Database type
    /// 
    /// </summary>
    public DatabaseType DatabaseType
    {
      get
      {
        return this.databaseType;
      }
      set
      {
        this.databaseType = value;
      }
    }

    protected DatabaseBase(string databaseName, DatabaseType databaseType)
    {
      if (!Enum.IsDefined(typeof(DatabaseType), (object)databaseType))
        throw new Exception("Unknown databaseType. Value = " + databaseType.ToString());
      this.databaseType = databaseType;
    }

    /// <summary>
    /// Returns connection to database.
    /// 
    ///             The parameter canBeReadonly indicates that the connection is allowed to be readonly. This is can be used as a security feature.
    /// 
    /// </summary>
    /// <param name="canBeReadonly">If true then the returned connection is allowed to be readonly</param>
    /// <returns/>
    public abstract DbConnection GetConnection(bool canBeReadonly);
  }
}
