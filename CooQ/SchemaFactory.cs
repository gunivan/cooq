using CooQ.Database;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQ
{
  public class SchemaFactory
  {
    public static IList<DbTable> GetTables(DbConnection connection, DatabaseType type)
    {
      if (Query.SCHEMA_PROVIDERS.ContainsKey(type))
      {
        return Query.SCHEMA_PROVIDERS[type].GetTables(connection);
      }
      return null;
    }

    public static DbTable GetTable(DatabaseBase database, TableBase table, DatabaseType type)
    {
      if (Query.SCHEMA_PROVIDERS.ContainsKey(type))
      {
        return Query.SCHEMA_PROVIDERS[type].GetTable(database, table);
      }
      return null;
    }
    public static string GetColumnTypeName(DbType type, String tableName, Boolean isPrimary = false, Boolean isNullable = false)
    {
      return CooQ.Utils.DbColumnFactory.GetColumnTypeName(type, tableName, isPrimary, isNullable);
    }
  }
}
