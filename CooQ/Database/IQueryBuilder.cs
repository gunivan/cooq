using CooQ.Builder;
using CooQ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQ.Database
{
  /// <summary>
  /// 
  /// </summary>
  internal interface IQueryBuilder
  {
    string GetSelectQuery(DatabaseBase database, QueryBuilderBase queryBuilder, Parameters parameters);

    string GetInsertQuery(DatabaseBase database, InsertBuilder insertBuilder, Parameters parameters);

    string GetInsertSelectQuery(DatabaseBase database, InsertSelectBuilder insertBuilder, Parameters parameters);

    string GetUpdateQuery(DatabaseBase database, UpdateBuilder updateBuilder, Parameters parameters);

    string GetDeleteQuery(DatabaseBase database, DeleteBuilder deleteBuilder, Parameters parameters);

    string GetTruncateQuery(TableBase table);

    string GetStoreProcedureQuery(DatabaseBase database, TableBase table, Parameters parameters, object[] objectParams);

    string CreateTableComment(string schemaName, string tableName, string desc);

    string CreateColumnComment(string schemaName, string tableName, string columnName, string desc);
  }
}
