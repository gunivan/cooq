using CooQ.CooqDataException;
using CooQ.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CooQ.Core;

namespace CooQ.Database.Mssql
{
  internal class MssqlExecutor : QueryExecutorBase<MssqlExecutor>
  {
    private static readonly string FORMAT_AUTH_WINDOW_MODE = "Server={0};DataBase={1};Integrated Security=true;MultipleActiveResultSets=True";
    private static readonly string FORMAT_AUTH_SQL_MODE = "Server={0};DataBase={1};User Id={2};Pwd={3};MultipleActiveResultSets=True";
    public MssqlExecutor(String connectionString)
      : base(connectionString)
    {
    }
    public MssqlExecutor(ConnectionSetting setting)
    {
      Init(setting);
    }
    public override String Init(ConnectionSetting setting)
    {
      String database = String.IsNullOrEmpty(setting.Database) ? "master" : setting.Database;
      if (!String.IsNullOrEmpty(setting.Username))
      {
        this.ConnectionString = String.Format(FORMAT_AUTH_SQL_MODE, setting.Server, database, setting.Username, setting.Password);
      }
      else
      {
        this.ConnectionString = String.Format(FORMAT_AUTH_WINDOW_MODE, setting.Server, database);
      }
      return this.ConnectionString;
    }

    public void AddParam(SqlCommand oCmd, Pair param)
    {
      if ((oCmd == null) || (null == param)) return;

      foreach (var col in param)
      {
        oCmd.Parameters.AddWithValue(col.Key,
          (col.Value == null) ? DBNull.Value : col.Value);
      }
    }

    #region Execute
    public override void ExecClosure(String query, CommandType cmdType, Pair param, Action<DbConnection, DbCommand> action)
    {
      var sw = new Stopwatch();
      sw.Start();
      Settings.FireQueryExecutingEvent(query, cmdType);
      try
      {
        using (var conn = new SqlConnection(ConnectionString))
        {
          using (var cmd = new SqlCommand(query, conn))
          {
            cmd.CommandType = cmdType;
            if (param != null)
              AddParam(cmd, param);
            if (conn.State != ConnectionState.Open)
              conn.Open();
            action(conn, cmd);
          }
        }
      }
      catch (SqlException ex)
      {                  
        throw new DataAccessException("Error while executing: " + ex.Message);
      }
      finally
      {
        sw.Stop();
        Settings.FireQueryExecutedEvent(String.Format("ExeClosure:End execute. {0} (s)", sw.ElapsedMilliseconds / 1000));
      }
    }

    #endregion

    public override void FillClosure(String query, Pair param, CommandType cmdType, Action<DbConnection, DbCommand, DbDataAdapter> action)
    {
      var sw = new Stopwatch();
      sw.Start();
      Settings.FireQueryExecutingEvent(query, cmdType);
      try
      {
        using (var oConn = new SqlConnection(ConnectionString))
        {
          using (var oCmd = new SqlCommand(query, oConn))
          {
            oCmd.CommandType = cmdType;
            using (var oAdapter = new SqlDataAdapter(oCmd))
            {
              if (param != null)
                AddParam(oCmd as SqlCommand, param);
              action(oConn, oCmd, oAdapter);
            }
          }
        }
      }
      catch (SqlException ex)
      {                  
        throw new DataAccessException("Error while fill data: " + ex.Message);
      }
      finally
      {
        sw.Stop();
        Settings.FireQueryExecutedEvent(String.Format("ClosureGetTry:End. {0} (s)", sw.ElapsedMilliseconds / 1000));
      }
    }
    #region Update

    /// <summary>
    /// //call it as below
    /// <para></para>
    /// <![CDATA[UpdateClosure(query, param, (oConn, oCmd, oAdapter, oCmdBuilder) => ]]>
    /// <para></para>
    /// <![CDATA[ {]]>
    /// <para>//...</para>
    /// <![CDATA[   nRes = oAdapter.Update(mDt);]]>
    /// <para></para>
    /// <![CDATA[   mDt.AcceptChanges();]]>
    /// <para></para>
    /// <![CDATA[ });]]>
    /// <para></para>   
    /// </summary>
    /// <param name="query"></param>
    /// <param name="param"></param>
    /// <param name="action"></param>
    public override void UpdateClosure(String query, Pair param, Action<DbConnection, DbCommand, DbDataAdapter, DbCommandBuilder> action)
    {
      var sw = new Stopwatch();
      sw.Start();
      Settings.FireQueryExecutingEvent(query, CommandType.Text);
      try
      {
        using (var oConn = new SqlConnection(ConnectionString))
        {
          using (var oCmd = new SqlCommand(query, oConn))
          {
            if (param != null)
              AddParam(oCmd, param);
            using (var oAdapter = new SqlDataAdapter(oCmd))
            {

              oAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
              using (var oCmdBuilder = new SqlCommandBuilder(oAdapter))
              {
                oAdapter.InsertCommand = oCmdBuilder.GetInsertCommand();
                if (null != oAdapter.InsertCommand)
                  oAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
                oCmdBuilder.GetUpdateCommand();
                action(oConn, oCmd, oAdapter, oCmdBuilder);
              }
            }
          }
        }
      }
      catch (SqlException ex)
      {                        
        throw new DataAccessException(ex.Message, ex);
      }
      finally
      {
        sw.Stop();
        Settings.FireQueryExecutedEvent(String.Format("UpdateClosure:End. {0} (s)", sw.ElapsedMilliseconds / 1000));
      }
    }
    #endregion
  }
}
