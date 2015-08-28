using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
