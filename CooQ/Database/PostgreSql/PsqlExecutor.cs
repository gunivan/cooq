using CooQ.CooqDataException;
using CooQ.Builder;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CooQ.Core;

namespace CooQ.Database.PostgreSql
{
  internal class PsqlExecutor : QueryExecutorBase<PsqlExecutor>
  {
    private static readonly String FORMAT_AUTH_SQL_MODE = "Server={0};Port={1};User Id={2};Password={3};Database={4};";

    public PsqlExecutor(String connectionString)
      : base(connectionString)
    {
    }
    public PsqlExecutor(ConnectionSetting setting)
    {
      Init(setting);
    }

    public override String Init(ConnectionSetting setting)
    {
      this.ConnectionString = String.Format(FORMAT_AUTH_SQL_MODE, setting.Server, setting.Port, setting.Username, setting.Password, setting.Database);
      return this.ConnectionString;
    }
    
    public void AddParam(NpgsqlCommand oCmd, Pair param)
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
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
          using (var cmd = new NpgsqlCommand(query, conn))
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
      catch (NpgsqlException ex)
      {
        throw new DataAccessException("Error while executing: " + ex.Message);
      }
      finally
      {
        sw.Stop();
        Settings.FireQueryExecutedEvent(string.Format("ExeClosure:End execute. {0} (s)", sw.ElapsedMilliseconds / 1000));
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
        using (var oConn = new NpgsqlConnection(ConnectionString))
        {
          using (var oCmd = new NpgsqlCommand(query, oConn))
          {
            oCmd.CommandType = cmdType;
            using (var oAdapter = new NpgsqlDataAdapter(oCmd))
            {
              if (oConn.State != ConnectionState.Open)
                oConn.Open();
              if (param != null)
                AddParam(oCmd as NpgsqlCommand, param);
              action(oConn, oCmd, oAdapter);
            }
          }
        }
      }
      catch (NpgsqlException ex)
      {
        throw new DataAccessException("Error while fill data: " + ex.Message);
      }
      finally
      {
        sw.Stop();
        Settings.FireQueryExecutedEvent(string.Format("FillClosure:End execute. {0} (s)", sw.ElapsedMilliseconds / 1000));
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
    public override void UpdateClosure(String query, Pair param,
      Action<DbConnection, DbCommand, DbDataAdapter, DbCommandBuilder> action)
    {
      var sw = new Stopwatch();
      sw.Start();
      Settings.FireQueryExecutingEvent(query, CommandType.Text);
      try
      {
        using (var oConn = new NpgsqlConnection(ConnectionString))
        {
          using (var oCmd = new NpgsqlCommand(query, oConn))
          {
            if (param != null)
              AddParam(oCmd, param);
            using (var oAdapter = new NpgsqlDataAdapter(oCmd))
            {
              oAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
              using (var oCmdBuilder = new NpgsqlCommandBuilder(oAdapter))
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
      catch (NpgsqlException ex)
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
