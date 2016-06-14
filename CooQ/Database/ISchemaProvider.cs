using System.Collections.Generic;
using System.Data.Common;

namespace CooQ.Database
{
  /// <summary>
  /// 
  /// </summary>
  interface ISchemaProvider
  {
    DbTable GetTable(DatabaseBase database, TableBase table);

    IList<DbTable> GetTables(DbConnection dbConnection);
  }
}
