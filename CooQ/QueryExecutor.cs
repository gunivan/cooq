using CooQ.Core;
using CooQ.Interfaces;
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
  public static class QueryExecutor
  {

    public static Boolean IsLogQuery = true;
    public static Boolean IsLogParam = true;
    private static IQueryExecutor EXECUTOR;

    public static IQueryExecutor Init(ConnectionSetting setting)
    {
      EXECUTOR = GetExecutor(setting);
      EXECUTOR.Init(setting);
      return EXECUTOR;
    }

    /// <summary>
    /// Get QueryExecutor
    /// </summary>
    /// <param name="setting"></param>
    /// <returns></returns>
    public static IQueryExecutor GetExecutor(ConnectionSetting setting)
    {
      switch (setting.Type)
      {
        case DatabaseType.POSTGRESQL:
          return new CooQ.Database.PostgreSql.PsqlExecutor(setting);
        case DatabaseType.MSSQL:
          return new CooQ.Database.Mssql.MssqlExecutor(setting);
        default:
          return null;
      }
    }
    #region Static Func

    public static void FillCLosure(String query, Pair param, CommandType cmdType, Action<DbConnection, DbCommand, DbDataAdapter> action)
    {
      EXECUTOR.FillClosure(query, param, cmdType, action);
    }

    public static void ExecClosure(String query, CommandType type, Pair param, Action<DbConnection, DbCommand> action)
    {
      EXECUTOR.ExecClosure(query, type, param, action);
    }

    public static Boolean ExecNonQuery(String query, Pair param = null)
    {
      return EXECUTOR.ExecNonQuery(query, param);
    }
    public static Boolean SpExecNonQuery(String storedProcName, Pair param = null)
    {
      return EXECUTOR.SpExecNonQuery(storedProcName, param);
    }
    public static void ExecReader(String query, CommandType cmdType, Pair param, Action<IDataReader> action)
    {
      EXECUTOR.ExecReader(query, cmdType, param, action);
    }

    public static void ExecReader(String query, Action<IDataReader> action)
    {
      EXECUTOR.ExecReader(query, action);
    }

    public static void SpExecReader(String storedProcName, Pair param, Action<IDataReader> action)
    {
      EXECUTOR.SpExecReader(storedProcName, param, action);
    }

    public static object ExecScalar(String query, Pair param = null)
    {
      return EXECUTOR.ExecScalar(query, param);
    }

    public static object StoredProcExecScalar(String storedProcName, Pair param = null)
    {
      return EXECUTOR.SpExecScalar(storedProcName, param);
    }
    #endregion

    public static Boolean Fill(String query, DataTable table, Pair param = null)
    {
      return EXECUTOR.Fill(query, table, param);
    }

    public static Boolean SpFill(String sStoredProcName, DataTable mDt, Pair param = null)
    {
      return EXECUTOR.SpFill(sStoredProcName, mDt, param);
    }
    public static Boolean FillDataset(String query, DataSet mDs, Pair param = null)
    {
      return EXECUTOR.FillDataset(query, mDs, param);
    }
    public static Boolean SpFillDs(String sStoredProcName, DataSet mDs, Pair param = null)
    {
      return EXECUTOR.StoredProcFillDs(sStoredProcName, mDs, param);
    }
    public static Boolean PagingGetPage(String query, DataTable mDt, Int32 page, Int32 pageSize, Pair param)
    {
      return EXECUTOR.PagingGetPage(query, mDt, page, pageSize, param);
    }

    public static Boolean PagingSpGetPage(String storedProcName, DataTable mDt, Int32 page, Int32 pageSize, Pair param)
    {
      return EXECUTOR.PagingSpGetPage(storedProcName, mDt, page, pageSize, param);
    }
    public static void FillSchema(String query, DataTable table)
    {
      EXECUTOR.FillSchema(query, table);
    }
    public static void FillSchemaWithTable(String tableName, DataTable table)
    {
      EXECUTOR.FillSchemaWithTable(tableName, table);
    }
    public static void FillSchema(String query, DataTable table, SchemaType scheType)
    {
      EXECUTOR.FillSchema(query, table, scheType);
    }
    public static void UpdateClosure(String query, Pair param,
      Action<DbConnection, DbCommand, IDataAdapter, DbCommandBuilder> action)
    {
      EXECUTOR.UpdateClosure(query, param, action);
    }

    /// <summary>
    /// @<see cref="MssqlExecutor"/>
    /// @<seealso cref="MssqlExecutor"/>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="table"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static Boolean Update(String query, DataTable table, Pair param = null)
    {
      return EXECUTOR.Update(query, table, param);
    }
    public static Boolean UpdateRows(String query, DataRow[] mArrRow, Pair param = null)
    {
      return EXECUTOR.UpdateRows(query, mArrRow, param);
    }
    public static Boolean UpdateDataset(String query, DataSet mDs, Pair param = null)
    {
      return EXECUTOR.UpdateDataset(query, mDs, param);
    }
    public static Boolean Update(String query, DataRow vRow, Pair param = null)
    {
      return EXECUTOR.Update(query, vRow, param);
    }

    /// <summary>
    /// Get data source with table and display, value column
    /// </summary>
    /// <param name="table"></param>
    /// <param name="valueColumn"></param>
    /// <param name="displayColumn"></param>
    /// <param name="others"></param>
    /// <returns></returns>
    public static DataTable GetDatatable(TableBase table, ColumnBase valueColumn, ColumnBase displayColumn, List<ColumnBase> others, 
      Conditions.Condition condition)
    {
      var query = "";
      if (others != null && others.Count> 0)
      {
        var cols = new List<ColumnBase>(others);
        cols.Insert(0, displayColumn);
        if (null == condition)
        {
          query = Query.Select(valueColumn, others.ToArray())
               .From(table)
               .GetSql();
        }
        else
        {
          query = Query.Select(valueColumn, others.ToArray())
               .From(table)
               .Where(condition)
               .GetSql();
        }
      }
      else
      {
        if (null != condition)
        {
          query = Query.Select(valueColumn, displayColumn)
               .From(table)
               .GetSql();
        }
        else
        {
          query = Query.Select(valueColumn, displayColumn)
               .From(table)
               .Where(condition)
               .GetSql();
        }
      }
      var mDt = new DataTable();
      CooQ.QueryExecutor.Fill(query, mDt);
      return mDt;
    }

    /// <summary>
    /// Get datasource by table and display, column
    /// </summary>
    /// <param name="table"></param>
    /// <param name="valueColumn"></param>
    /// <param name="displayColumn"></param>
    /// <param name="others"></param>
    /// <returns></returns>
    public static DataTable GetDatatable(String table, String valueColumn, String displayColumn, params String[] others)
    {
      var query = "";
      if (others != null && others.Length > 0)
      {
        var cols = new List<String>(others);
        cols.Insert(0, displayColumn);
        cols.Insert(0, valueColumn);
        query = QueryBuilder.Select(table, new Pair { }, others);
      }
      else
      {
        query = QueryBuilder.Select(table, new Pair { }, valueColumn, displayColumn);
      }
      var mDt = new DataTable();
      CooQ.QueryExecutor.Fill(query, mDt);
      return mDt;
    }
  }
}
