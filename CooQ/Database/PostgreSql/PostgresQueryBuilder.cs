using CooQ;
using CooQ.Conditions;
using CooQ.Builder;
using CooQ.Function;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections;
using System.Data;
using System.Text;
using CooQ.Core;

namespace CooQ.Database.PostgreSql
{
  internal class PostgresQueryBuilder : IQueryBuilder
  {
    public string GetSelectQuery(DatabaseBase database, QueryBuilderBase queryBuilder, Parameters parameters)
    {
      var stringBuilder = new StringBuilder();
      if (queryBuilder.UnionQuery != null)
      {
        stringBuilder.Append(GetSelectQuery(database, queryBuilder.UnionQuery, parameters));
        if (queryBuilder.UnionType == UnionType.UNION)
          stringBuilder.Append(" UNION ");
        else if (queryBuilder.UnionType == UnionType.UNION_ALL)
          stringBuilder.Append(" UNION ALL ");
        else if (queryBuilder.UnionType == UnionType.INTERSECT)
        {
          stringBuilder.Append(" INTERSECT ");
        }
        else
        {
          if (queryBuilder.UnionType != UnionType.EXCEPT)
            throw new Exception("Unknown union type: " + queryBuilder.UnionType.ToString());
          stringBuilder.Append(" EXCEPT ");
        }
      }
      stringBuilder.Append("SELECT ");
      if (queryBuilder.IsDistinct)
        stringBuilder.Append("DISTINCT ");
      bool useAlias = queryBuilder.JoinList.Count > 0 && !queryBuilder.FromTable.IsTemporaryTable;
      int index1 = 0;
      while (index1 < queryBuilder.SelectColumns.Length)
      {
        ISelectable selectable = queryBuilder.SelectColumns[index1];
        if (index1 > 0)
          stringBuilder.Append(',');
        if (selectable is ColumnBase)
        {
          stringBuilder.Append(GetColumnSql((ColumnBase)selectable));
        }
        else
        {
          if (!(selectable is IFunction))
            throw new Exception("Field type not supported yet");
          stringBuilder.Append(((IFunction)selectable).GetFunctionSql(database, useAlias));
        }
        checked { ++index1; }
      }
      if (queryBuilder.IntoTable != null)
      {
        stringBuilder.Append(" INTO ");
        if (queryBuilder.IntoTable.IsTemporaryTable)
          stringBuilder.Append("TEMP ");
        stringBuilder.Append(queryBuilder.IntoTable.Name);
      }
      stringBuilder.Append(" FROM ").Append(queryBuilder.FromTable.Name).Append(" AS ").Append(queryBuilder.FromTable.Alias);
      if (queryBuilder.FromHints != null && queryBuilder.FromHints.Length > 0)
        throw new Exception("From table hints not supported in postgresql sql generator");
      if (queryBuilder.JoinList.Count > 0)
      {
        stringBuilder.Append(" ");
        int index2 = 0;
        while (index2 < queryBuilder.JoinList.Count)
        {
          Join join = queryBuilder.JoinList[index2];
          if (join.JoinType == JoinType.JOIN)
            stringBuilder.Append("JOIN ");
          else if (join.JoinType == JoinType.LEFT)
          {
            stringBuilder.Append("LEFT JOIN ");
          }
          else
          {
            if (join.JoinType != JoinType.RIGHT)
              throw new Exception("Unknown join type: " + join.JoinType.ToString());
            stringBuilder.Append("RIGHT JOIN ");
          }
          stringBuilder.Append(join.Table.Name).Append(" AS ").Append(join.Table.Alias).Append(" ON ").Append(GetConditionSql(database, join.Condition, parameters));
          if (join.Hints != null && join.Hints.Length > 0)
            throw new Exception("Join hints not supported in postgresql sql generator");
          checked { ++index2; }
        }
      }
      if (queryBuilder.WhereCondition != null)
        stringBuilder.Append(" WHERE ").Append(GetConditionSql(database, queryBuilder.WhereCondition, parameters));
      if (queryBuilder.GroupByColumns != null && queryBuilder.GroupByColumns.Length > 0)
      {
        stringBuilder.Append(" GROUP BY ");
        int index2 = 0;
        while (index2 < queryBuilder.GroupByColumns.Length)
        {
          ISelectable selectable = queryBuilder.GroupByColumns[index2];
          if (index2 > 0)
            stringBuilder.Append(',');
          if (selectable is ColumnBase)
          {
            ColumnBase ColumnBase = (ColumnBase)selectable;
            stringBuilder.Append(ColumnBase.Table.Alias).Append('.').Append(ColumnBase.Name);
          }
          else
          {
            if (!(selectable is IFunction))
              throw new Exception("column type not supported yet");
            stringBuilder.Append(((IFunction)selectable).GetFunctionSql(database, useAlias));
          }
          checked { ++index2; }
        }
      }
      if (queryBuilder.HavingCondition != null)
        stringBuilder.Append(" HAVING ").Append(GetConditionSql(database, queryBuilder.HavingCondition, parameters));
      if (queryBuilder.OrderByColumns != null && queryBuilder.OrderByColumns.Length > 0)
      {
        stringBuilder.Append(" ORDER BY ");
        int index2 = 0;
        while (index2 < queryBuilder.OrderByColumns.Length)
        {
          IOrderByColumn orderByColumn = queryBuilder.OrderByColumns[index2];
          if (index2 > 0)
            stringBuilder.Append(',');
          bool flag = false;
          if (queryBuilder.UnionQuery != null)
          {
            int index3 = 0;
            while (index3 < queryBuilder.SelectColumns.Length)
            {
              if (queryBuilder.SelectColumns[index3].Equals(orderByColumn))
              {
                stringBuilder.Append(checked(index3 + 1).ToString());
                flag = true;
              }
              checked { ++index3; }
            }
          }
          if (!flag)
          {
            ISelectable column = orderByColumn.GetOrderByColumn.Column;
            if (column is ColumnBase)
            {
              stringBuilder.Append(GetColumnSql((ColumnBase)column));
            }
            else
            {
              if (!(column is IFunction))
                throw new Exception("Field type not supported yet");
              stringBuilder.Append(((IFunction)column).GetFunctionSql(database, useAlias));
            }
          }
          switch (orderByColumn.GetOrderByColumn.OrderBy)
          {
            case OrderByType.ASC:
              stringBuilder.Append(" ASC");
              goto case OrderByType.Default;
            case OrderByType.DESC:
              stringBuilder.Append(" DESC");
              goto case OrderByType.Default;
            case OrderByType.Default:
              checked { ++index2; }
              continue;
            default:
              throw new Exception("Unknown OrderBy type: " + orderByColumn.GetOrderByColumn.OrderBy.ToString());
          }
        }
      }
      if (queryBuilder.TopRows.HasValue)
        stringBuilder.Append(" LIMIT ").Append(queryBuilder.TopRows.Value.ToString());
      if (!string.IsNullOrEmpty(queryBuilder.CustomSql))
        stringBuilder.Append(" ").Append(queryBuilder.CustomSql);
      return stringBuilder.ToString();
    }

    public string GetInsertQuery(DatabaseBase database, InsertBuilder insertBuilder, Parameters parameters)
    {
      StringBuilder stringBuilder = new StringBuilder("INSERT INTO ");
      stringBuilder.Append(insertBuilder.Table.Name);
      stringBuilder.Append("(");
      int index1 = 0;
      while (index1 < insertBuilder.SetValueList.Count)
      {
        SetValue setValue = insertBuilder.SetValueList[index1];
        if (index1 > 0)
          stringBuilder.Append(',');
        stringBuilder.Append(setValue.Column.Name);
        checked { ++index1; }
      }
      stringBuilder.Append(")VALUES(");
      int index2 = 0;
      while (index2 < insertBuilder.SetValueList.Count)
      {
        SetValue setValue = insertBuilder.SetValueList[index2];
        if (index2 > 0)
          stringBuilder.Append(',');
        if (setValue.Value == null)
        {
          if (parameters != null)
          {
            if (setValue.Column.DbType == DbType.DateTime2)
              stringBuilder.Append(parameters.AddParameter(DbType.DateTime, null));
            else
              stringBuilder.Append(parameters.AddParameter(setValue.Column.DbType, null));
          }
          else
            stringBuilder.Append("NULL");
        }
        else
          stringBuilder.Append(GetValue(database, setValue.Value, parameters, new DbType?(setValue.Column.DbType)));
        checked { ++index2; }
      }
      stringBuilder.Append(")");
      if (insertBuilder.ReturnColumns != null && insertBuilder.ReturnColumns.Length > 0)
      {
        stringBuilder.Append(" RETURNING ");
        int index3 = 0;
        while (index3 < insertBuilder.ReturnColumns.Length)
        {
          if (index3 > 0)
            stringBuilder.Append(",");
          stringBuilder.Append(insertBuilder.ReturnColumns[index3].Name);
          checked { ++index3; }
        }
      }
      return stringBuilder.ToString();
    }

    public string GetInsertSelectQuery(DatabaseBase database, InsertSelectBuilder insertBuilder, Parameters parameters)
    {
      StringBuilder stringBuilder = new StringBuilder("INSERT INTO ");
      stringBuilder.Append(insertBuilder.Table.Name);
      stringBuilder.Append("(");
      int index = 0;
      while (index < insertBuilder.InsertColumns.Length)
      {
        ColumnBase ColumnBase = insertBuilder.InsertColumns[index];
        if (index > 0)
          stringBuilder.Append(',');
        stringBuilder.Append(ColumnBase.Name);
        checked { ++index; }
      }
      stringBuilder.Append(")");
      stringBuilder.Append(GetSelectQuery(database, (QueryBuilderBase)insertBuilder.SelectQuery, parameters));
      return stringBuilder.ToString();
    }


    public string GetUpdateQuery(DatabaseBase database, UpdateBuilder updateBuilder, Parameters parameters)
    {
      StringBuilder stringBuilder = new StringBuilder("UPDATE ");
      stringBuilder.Append(updateBuilder.Table.Name).Append(" AS ").Append(updateBuilder.Table.Alias);
      stringBuilder.Append(" SET ");
      int index1 = 0;
      while (index1 < updateBuilder.SetValueList.Count)
      {
        SetValue setValue = updateBuilder.SetValueList[index1];
        if (index1 > 0)
          stringBuilder.Append(',');
        stringBuilder.Append(setValue.Column.Name);
        if (setValue.Value == null)
        {
          if (parameters != null)
            stringBuilder.Append("=").Append(parameters.AddParameter(setValue.Column.DbType, (object)null));
          else
            stringBuilder.Append("=NULL");
        }
        else
          stringBuilder.Append("=").Append(GetValue(database, setValue.Value, parameters, new DbType?(setValue.Column.DbType)));
        checked { ++index1; }
      }
      Condition condition = null;
      if (updateBuilder.JoinList.Count > 0)
      {
        stringBuilder.Append(" FROM ");
        int index2 = 0;
        while (index2 < updateBuilder.JoinList.Count)
        {
          Join join = updateBuilder.JoinList[index2];
          if (index2 > 0)
            stringBuilder.Append(",");
          stringBuilder.Append(join.Table.Name).Append(" AS ").Append(join.Table.Alias);
          if (condition == null)
            condition = join.Condition;
          else
            condition &= join.Condition;
          checked { ++index2; }
        }
      }
      Condition pCondition = null;
      if (condition != null && updateBuilder.WhereCondition != null)
        pCondition = condition & updateBuilder.WhereCondition;
      else if (condition != null)
        pCondition = condition;
      else if (updateBuilder.WhereCondition != null)
        pCondition = updateBuilder.WhereCondition;
      if (pCondition != null)
        stringBuilder.Append(" WHERE ").Append(GetConditionSql(database, pCondition, parameters));
      if (updateBuilder.ReturnColumns != null && updateBuilder.ReturnColumns.Length > 0)
      {
        stringBuilder.Append(" RETURNING ");
        int index2 = 0;
        while (index2 < updateBuilder.ReturnColumns.Length)
        {
          if (index2 > 0)
            stringBuilder.Append(",");
          ColumnBase acolumn = updateBuilder.ReturnColumns[index2];
          stringBuilder.Append(acolumn.Table.Alias).Append(".");
          stringBuilder.Append(acolumn.Name);
          checked { ++index2; }
        }
      }
      return stringBuilder.ToString();
    }

    public string GetDeleteQuery(DatabaseBase database, DeleteBuilder deleteBuilder, Parameters parameters)
    {
      StringBuilder stringBuilder = new StringBuilder("DELETE FROM ");
      stringBuilder.Append(deleteBuilder.Table.Name).Append(" AS ").Append(deleteBuilder.Table.Alias);
      if (deleteBuilder.WhereCondition != null)
        stringBuilder.Append(" WHERE ").Append(GetConditionSql(database, deleteBuilder.WhereCondition, parameters));
      if (deleteBuilder.ReturnColumns != null && deleteBuilder.ReturnColumns.Length > 0)
      {
        stringBuilder.Append(" RETURNING ");
        int index = 0;
        while (index < deleteBuilder.ReturnColumns.Length)
        {
          if (index > 0)
            stringBuilder.Append(",");
          stringBuilder.Append(deleteBuilder.ReturnColumns[index].Name);
          checked { ++index; }
        }
      }
      return stringBuilder.ToString();
    }

    public string GetTruncateQuery(TableBase table)
    {
      return "TRUNCATE TABLE " + table.Name;
    }

    string GetConditionSql(DatabaseBase database, Condition condition, Parameters parameters)
    {
      if (condition.Operator == Operator.IS_NULL)
        return string.Format("({0} IS NULL)", GetSideSql(database, condition.Left, parameters));
      if (condition.Operator == Operator.IS_NOT_NULL)
        return string.Format("({0}IS NOT NULL)", GetSideSql(database, condition.Left, parameters));

      DbType? dbType = new DbType?();
      if (condition.Left is ColumnBase)
        dbType = new DbType?(((ColumnBase)condition.Left).DbType);
      return string.Format("({0}{1}{2})", GetSideSql(database, condition.Left, parameters),
        GetOperator(condition.Operator, condition),
        GetSideSql(database, condition.Right, parameters, dbType));
    }

    string GetSideSql(DatabaseBase database, object cond, Parameters parameters)
    {
      return GetSideSql(database, cond, parameters, new DbType?());
    }

    string GetSideSql(DatabaseBase database, object cond, Parameters parameters, DbType? dbType)
    {
      if (cond is Condition)
        return GetConditionSql(database, (Condition)cond, parameters);
      if (cond is ColumnBase)
        return GetColumnSql((ColumnBase)cond);
      if (cond is QueryBuilderBase)
        return "(" + GetSelectQuery(database, (QueryBuilderBase)cond, parameters) + ")";
      if (!(cond is INumericCondition))
        return GetValue(database, cond, parameters, dbType);
      INumericCondition numericCondition = (INumericCondition)cond;
      string str;
      switch (numericCondition.Operator)
      {
        case NumericOperator.ADD:
          str = "+";
          break;
        case NumericOperator.SUBTRACT:
          str = "-";
          break;
        case NumericOperator.DIVIDE:
          str = "/";
          break;
        case NumericOperator.MULTIPLY:
          str = "*";
          break;
        case NumericOperator.MODULO:
          str = "%";
          break;
        default:
          throw new Exception("Unknown numeric operator : '" + numericCondition.Operator.ToString());
      }
      return string.Format("({0}{1}{2})",
        GetSideSql(database, numericCondition.Left, parameters),
        str,
        GetSideSql(database, numericCondition.Right, parameters));
    }

    public string GetValue(DatabaseBase database, object value, DbType? dbType)
    {
      return GetValue(database, value, (Parameters)null, dbType);
    }

    public string GetValue(DatabaseBase database, object value, Parameters parameters, DbType? dbType)
    {
      if (value is int)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Int32, value);
        return value.ToString();
      }
      if (value is int?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Int32, value);
        return value == null ? "NULL" : value.ToString();
      }
      if (value is string)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.String, value);
        return "'" + ((string)value).Replace("'", "''") + "'";
      }
      if (value is short)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Int16, value);
        return value.ToString();
      }
      if (value is short?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Int16, value);
        return value == null ? "NULL" : value.ToString();
      }
      if (value is long)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Int64, value);
        return value.ToString();
      }
      if (value is long?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Int64, value);
        return value == null ? "NULL" : value.ToString();
      }
      if (value is Decimal)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Decimal, value);
        return value.ToString();
      }
      if (value is Decimal?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Decimal, value);
        return value == null ? "NULL" : value.ToString();
      }
      if (value is DateTime)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.DateTime, value);
        int num;
        if (dbType.HasValue)
        {
          DbType? nullable = dbType;
          num = (nullable.GetValueOrDefault() != DbType.DateTime2 ? 0 : (nullable.HasValue ? 1 : 0)) == 0 ? 1 : 0;
        }
        else
          num = 1;
        if (num == 0)
          return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "'";
        return "'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
      }
      if (value is DateTime?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.DateTime, value);
        int num;
        if (dbType.HasValue)
        {
          DbType? nullable = dbType;
          num = (nullable.GetValueOrDefault() != DbType.DateTime2 ? 0 : (nullable.HasValue ? 1 : 0)) == 0 ? 1 : 0;
        }
        else
          num = 1;
        if (num == 0)
          return value == null ? "NULL" : ((DateTime?)value).Value.ToString("YYYY-MM-dd HH:mm:ss.fffffff");
        return value == null ? "NULL" : ((DateTime?)value).Value.ToString("YYYY-MM-dd HH:mm:ss.fff");
      }
      if (value is DateTimeOffset)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.DateTimeOffset, value);
        return "'" + ((DateTimeOffset)value).ToString("yyyy-MM-dd HH:mm:ss.fffffff zzz") + "'";
      }
      if (value is DateTimeOffset?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.DateTimeOffset, value);
        return value == null ? "NULL" : ((DateTimeOffset?)value).Value.ToString("YYYY-MM-dd HH:mm:ss.fffffff zzz");
      }
      if (value is bool)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Boolean, value);
        return (bool)value ? "TRUE" : "FALSE";
      }
      if (value is bool?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Boolean, value);
        return value == null ? "NULL" : (((bool?)value).Value ? "TRUE" : "FALSE");
      }
      if (value is Guid)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Guid, value);
        return "'" + ((Guid)value).ToString() + "'";
      }
      if (value is Guid?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Guid, value);
        return value == null ? "NULL" : "'" + ((Guid)value).ToString() + "'";
      }
      if (value is byte)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Byte, value);
        return ((byte)value).ToString();
      }
      if (value is byte?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Byte, value);
        return value == null ? "NULL" : ((byte)value).ToString();
      }
      if (value is byte[])
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Binary, value);
        return "'" + ConvertBytes((byte[])value) + "'";
      }
      if (value is float)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Single, value);
        return "'" + ((float)value).ToString() + "'";
      }
      if (value is float?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Single, value);
        return value == null ? "NULL" : "'" + ((float)value).ToString() + "'";
      }
      if (value is double)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Double, value);
        return "'" + ((double)value).ToString() + "'";
      }
      if (value is double?)
      {
        if (parameters != null)
          return parameters.AddParameter(DbType.Double, value);
        return value == null ? "NULL" : "'" + ((double)value).ToString() + "'";
      }
      if (value is IEnumerable)
      {
        StringBuilder stringBuilder = new StringBuilder("(");
        int num = 0;
        foreach (object value1 in (IEnumerable)value)
        {
          if (num > 0)
            stringBuilder.Append(',');
          checked { ++num; }
          if (value1 == null)
            throw new Exception("Null values in an 'IN' or 'NOT IN' clause are not supported");
          stringBuilder.Append(GetValue(database, value1, parameters, dbType));
        }
        stringBuilder.Append(")");
        return stringBuilder.ToString();
      }
      if (value is IFunction)
        return ((IFunction)value).GetFunctionSql(database, true);
      if (value is Enum)
        return ((int)value).ToString();
      if (value is CustomSql)
        return ((CustomSql)value).GetCustomSql();
      if (value is ColumnBase)
        return GetColumnSql((ColumnBase)value);
      throw new Exception("Unknown type: " + value.GetType().ToString());
    }

    private string ConvertBytes(byte[] pBytes)
    {
      if (pBytes == null)
        return "\\000";
      StringBuilder stringBuilder = new StringBuilder();
      int index = 0;
      while (index < pBytes.Length)
      {
        stringBuilder.Append("\\").Append(((int)pBytes[index]).ToString("000"));
        checked { ++index; }
      }
      return stringBuilder.ToString();
    }

    private string GetOperator(Operator dbOperator, Condition condition)
    {
      switch (dbOperator)
      {
        case Operator.EQUALS:
          return "=";
        case Operator.NOT_EQUALS:
          return "!=";
        case Operator.GREATER_THAN:
          return ">";
        case Operator.GREATER_THAN_OR_EQUAL:
          return ">=";
        case Operator.LESS_THAN:
          return "<";
        case Operator.LESS_THAN_OR_EQUAL:
          return "<=";
        case Operator.AND:
          return " AND ";
        case Operator.OR:
          return " OR ";
        case Operator.IN:
          return " IN ";
        case Operator.NOT_IN:
          return " NOT IN ";
        case Operator.LIKE:
          return " ILIKE ";
        case Operator.NOT_LIKE:
          return " NOT ILIKE ";
        case Operator.BETWEEN:
          var between = condition as BetweenAndCondition;
          return " BETWEEN " + between.From + " AND " + between.To;
        default:
          throw new Exception("Unknown operator: " + dbOperator.ToString());
      }
    }

    private string GetColumnSql(ColumnBase column)
    {
      return column.Table.Alias + '.' + column.Name;
    }

    internal string CreateTableComment(string schemaName, string tableName, string desc)
    {
      return "COMMENT ON TABLE " + tableName + " IS " + (!string.IsNullOrWhiteSpace(desc) ? "'" + desc.Replace("'", "''") + "';" : "IS NULL;");
    }

    internal string CreateColumnComment(string schemaName, string tableName, string columnName, string desc)
    {
      return "COMMENT ON COLUMN " + tableName + "." + columnName + " IS " + (!string.IsNullOrWhiteSpace(desc) ? "'" + desc.Replace("'", "''") + "';" : "IS NULL;");
    }


    public string GetStoreProcedureQuery(DatabaseBase database, TableBase table, Parameters parameters, object[] objectParams)
    {
      throw new NotImplementedException();
    }

    string IQueryBuilder.CreateTableComment(string schemaName, string tableName, string desc)
    {
      throw new NotImplementedException();
    }

    string IQueryBuilder.CreateColumnComment(string schemaName, string tableName, string columnName, string desc)
    {
      throw new NotImplementedException();
    }
  }
}
