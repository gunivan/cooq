using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Globalization;
using CooQ.Utils;
using CooQ.Interfaces;

namespace CooQ.Database
{
  internal abstract class QueryExecutorBase<T> : IQueryExecutor
  {
    public static readonly string SELECT_ALL_FIELD = "*";
    public readonly string SELECT_FROM_WHERE = "SELECT {0} FROM \"{1}\" {2}";
    public readonly string SELECT_MAX = "SELECT MAX({0}) FROM \"{1}\" ";
    public readonly string SELECT_MAX_WHERE = "SELECT MAX({0}) FROM \"1\" {2}";
    public readonly string SELECT_DISTINCT = "SELECT DISTINCT {0} FROM \"1\" ";
    public readonly string SELECT_DISTINCT_WHERE = "SELECT DISTINCT {0} FROM \"1\" {2}";
    public readonly string SELECT_COUNT = "SELECT COUNT(*) FROM \"0\" ";
    public readonly string ORDERBY = " ORDER BY {0} ";
    public readonly string JOIN_COLUMN = ", ";
    public String ConnectionString { get; set; }

    protected QueryExecutorBase()
    {
    }
    protected QueryExecutorBase(string connectionString)
    {
      this.ConnectionString = connectionString;
    }
    public string GetConnectionString()
    {
      return ConnectionString;
    }

    public abstract string Init(ConnectionSetting setting);
    public abstract void FillClosure(string query, Pair param, CommandType cmdType, Action<DbConnection, DbCommand, DbDataAdapter> action);
    public abstract void ExecClosure(string query, CommandType cmdType, Pair param, Action<DbConnection, DbCommand> action);
    public abstract void UpdateClosure(string query, Pair param, Action<DbConnection, DbCommand, DbDataAdapter, DbCommandBuilder> action);

    public virtual bool Fill(string query, DataTable mDt, Pair param = null)
    {
      int res = -1;
      FillClosure(query, param, CommandType.Text, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill(mDt); });
      return (res >= 0);
    }

    public virtual bool FillDataset(string query, DataSet mDs, Pair param = null)
    {
      int res = -1;
      FillClosure(query, param, CommandType.Text, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill(mDs); });
      return (res >= 0);
    }

    public virtual void FillSchema(string sSql, DataTable mDt, SchemaType schemaType = SchemaType.Source)
    {
      FillClosure(sSql, null, CommandType.Text,
        (oConn, oCmd, oAdapter) =>
        {
          mDt.Locale = CultureInfo.InvariantCulture;
          oAdapter.FillSchema(mDt, schemaType);
        });
    }

    public virtual void FillSchemaWithTable(string table, DataTable mDt)
    {
      var query = string.Format(SELECT_FROM_WHERE, "*", table, "");
      FillSchema(query, mDt);
    }

    public virtual bool GetTable(DataTable mDt, string sTable, string sColList = "*", Pair param = null)
    {
      return GetTable(mDt, sTable, sColList, null, param);
    }
    public virtual bool GetTable(DataTable mDt, string sTable, string sColList, string sOrderby, Pair param = null)
    {
      int res = -1;
      if (String.IsNullOrEmpty(sTable))
        return false;
      var orderBy = "";
      if (!String.IsNullOrEmpty(sOrderby))
        orderBy = String.Format(ORDERBY, sOrderby);
      var sSql = String.Format(SELECT_FROM_WHERE, sColList, sTable, QueryBuilder.Where(param)) + orderBy;

      FillClosure(sSql, param, CommandType.Text, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill(mDt); });
      return (res >= 0);
    }
    public virtual bool GetTable(DataTable mDt, string sTable, Pair param, params string[] cols)
    {
      if (cols.Length < 1)
        return GetTable(mDt, sTable, SELECT_ALL_FIELD, null, param);

      return GetTable(mDt, sTable, String.Join(JOIN_COLUMN, cols), null, param);
    }

    public virtual bool ExecNonQuery(string query, Pair param)
    {
      int res = -1;
      ExecClosure(query, CommandType.Text, param,
        (oConn, oCmd) => { res = oCmd.ExecuteNonQuery(); });
      return (res >= 0);
    }

    public virtual void ExecReader(string query, Action<DbDataReader> action)
    {
      ExecReader(query, CommandType.Text, null, action);
    }
    public virtual void ExecReader(string query, CommandType cmdType, Pair param, Action<DbDataReader> action)
    {
      DbDataReader rd = null;

      ExecClosure(query, cmdType, param,
        (oConn, oCmd) =>
        {
          rd = oCmd.ExecuteReader();
          action(rd);
        });
      if (rd != null)
        rd.Dispose();
    }

    public virtual object ExecScalar(string query, Pair param = null)
    {
      object res = null;
      ExecClosure(query, CommandType.Text, param,
        (oConn, oCmd) =>
        {
          res = oCmd.ExecuteScalar();
        });
      return res;
    }

    public virtual bool PagingGetPage(string query, DataTable mDt, int page, int pageSize, Pair param)
    {
      int res = -1;
      var startRecs = Math.Max(0, page - 1);
      FillClosure(query, param, CommandType.Text, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill(startRecs * pageSize, pageSize, mDt); });
      return (res >= 0);
    }
    public virtual bool PagingSpGetPage(string storedProcName, DataTable mDt, int page, int pageSize, Pair param)
    {
      int res = -1;
      FillClosure(storedProcName, param, CommandType.StoredProcedure, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill((page - 1) * pageSize, pageSize, mDt); });
      return (res >= 0);
    }

    public virtual bool SpExecNonQuery(string storedProcName, Pair param = null)
    {
      int res = -1;
      ExecClosure(storedProcName, CommandType.StoredProcedure, param,
        (oConn, oCmd) => { res = oCmd.ExecuteNonQuery(); });
      return (res >= 0);
    }
    public virtual void SpExecReader(string storedProcName, Pair param, Action<DbDataReader> action)
    {
      ExecReader(storedProcName, CommandType.StoredProcedure, param, action);
    }
    public virtual object SpExecScalar(string storedProcName, Pair param = null)
    {
      object res = null;
      ExecClosure(storedProcName, CommandType.StoredProcedure, param,
        (oConn, oCmd) => { res = oCmd.ExecuteScalar(); });
      return res;
    }

    public virtual bool SpFill(string sStoredProcName, DataTable mDt, Pair param = null)
    {
      int res = -1;
      FillClosure(sStoredProcName, param, CommandType.StoredProcedure, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill(mDt); });
      return (res >= 0);
    }

    public virtual bool StoredProcFillDs(string sStoredProcName, DataSet mDs, Pair param = null)
    {
      int res = -1;
      FillClosure(sStoredProcName, param, CommandType.StoredProcedure, (oConn, oCmd, oAdapter) => { res = oAdapter.Fill(mDs); });
      return (res >= 0);
    }
    public virtual bool Update(string query, DataRow vRow, Pair param = null)
    {
      int nRes = -1;
      UpdateClosure(query, param, (oConn, oCmd, oAdapter, oCmdBuilder) =>
      {
        nRes = oAdapter.Update(new[] { vRow });
      });
      return nRes >= 0;
    }

    public virtual bool Update(string query, DataTable mDt, Pair param = null)
    {
      int nRes = -1;
      UpdateClosure(query, param, (oConn, oCmd, oAdapter, oCmdBuilder) =>
      {
        nRes = oAdapter.Update(mDt);
        mDt.AcceptChanges();
      });
      return (nRes >= 0);
    }
    public virtual bool UpdateDataset(string query, DataSet mDs, Pair param = null)
    {
      int nRes = -1;
      UpdateClosure(query, param, (oConn, oCmd, oAdapter, oCmdBuilder) =>
      {
        nRes = oAdapter.Update(mDs);
        mDs.AcceptChanges();
      });
      return (nRes >= 0);
    }
    public virtual bool UpdateRows(string query, DataRow[] mArrRow, Pair param = null)
    {
      int nRes = -1;
      UpdateClosure(query, param, (oConn, oCmd, oAdapter, oCmdBuilder) =>
      {
        nRes = oAdapter.Update(mArrRow);
      });
      return nRes >= 0;
    }

  }
}
