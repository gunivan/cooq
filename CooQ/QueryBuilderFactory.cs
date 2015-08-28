using CooQ;
using CooQ.Builder;
using CooQ.Database;
using CooQ.Database.PostgreSql;
using CooQ.Database.Mssql;
using CooQ.Types;
using System;
using System.Collections.Generic;
using CooQ.Core;

namespace CooQ
{
  internal static class QueryBuilderFactory
  {
    private static IDictionary<DatabaseType, IQueryBuilder> QUERY_BUILDERS_PROVIDERS;

    static QueryBuilderFactory()
    {
      QUERY_BUILDERS_PROVIDERS = new Dictionary<DatabaseType, IQueryBuilder>();
      QUERY_BUILDERS_PROVIDERS.Add(DatabaseType.MSSQL, new MssqlQueryBuilder());
      QUERY_BUILDERS_PROVIDERS.Add(DatabaseType.POSTGRESQL, new PostgresQueryBuilder());
    }
    private static IQueryBuilder GetBuilder(DatabaseType type)
    {
      if (QUERY_BUILDERS_PROVIDERS.ContainsKey(type))
        return QUERY_BUILDERS_PROVIDERS[type];
      throw new Exception("Unsupported database type.");
    }

    internal static string GetSelectQuery(DatabaseBase database, QueryBuilderBase queryBuilder, Parameters parameters)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetSelectQuery(database, queryBuilder, parameters);
    }

    internal static string GetInsertQuery(DatabaseBase database, InsertBuilder insertBuilder, Parameters parameters)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetInsertQuery(database, insertBuilder, parameters);
    }

    internal static string GetInsertSelectQuery(DatabaseBase database, InsertSelectBuilder insertBuilder, Parameters parameters)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetInsertSelectQuery(database, insertBuilder, parameters);
    }

    internal static string GetUpdateQuery(DatabaseBase database, UpdateBuilder pUpdateBuilder, Parameters parameters)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetUpdateQuery(database, pUpdateBuilder, parameters);
    }

    internal static string GetDeleteQuery(DatabaseBase database, DeleteBuilder deleteBuilder, Parameters parameters)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetDeleteQuery(database, deleteBuilder, parameters);
    }

    internal static string GetTruncateQuery(DatabaseBase database, TableBase table)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetTruncateQuery(table);
    }

    internal static string GetStoreProcedureQuery(DatabaseBase database, TableBase table, Parameters parameters, object[] objectParams)
    {
      var builder = GetBuilder(database.DatabaseType);
      return builder.GetStoreProcedureQuery(database, table, parameters, objectParams);
    }

    internal static string CreateTableComment(string tableName, string desc, DatabaseBase database)
    {
      if (string.IsNullOrWhiteSpace(tableName))
        throw new ArgumentException("tableName cannot be null or empty");
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      var builder = GetBuilder(database.DatabaseType);
      return builder.CreateTableComment("", tableName, desc);
    }

    internal static string CreateColumnComment(string tableName, string columnName, string desc, DatabaseBase database)
    {
      if (string.IsNullOrWhiteSpace(tableName))
        throw new ArgumentException("tableName cannot be null or empty");
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      var builder = GetBuilder(database.DatabaseType);
      return builder.CreateColumnComment("", tableName, columnName, desc);
    }
  }
}
