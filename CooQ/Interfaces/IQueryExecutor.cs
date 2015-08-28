using CooQ.Builder;
using CooQ.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CooQ.Interfaces
{
  public interface IQueryExecutor
  {
    String Init(ConnectionSetting setting);
    String GetConnectionString();

    void ExecClosure(string query, CommandType cmdType, Pair param, Action<DbConnection, DbCommand> action);
    bool ExecNonQuery(string query, Pair param);
    void ExecReader(string query, Action<DbDataReader> action);
    void ExecReader(string query, CommandType cmdType, Pair param, Action<DbDataReader> action);
    object ExecScalar(string query, Pair param = null);

    /// <summary>
    ///   Fill datatable
    ///   <para>//Declare</para>
    ///   <para> var query = "SELECT ...";</para>
    ///   <para>var mDt = new DataTable();     </para>
    ///   <para>//Call it</para>
    ///   <para>Sql.Fill(query, mDt); </para>         
    ///   <para>//Call it</para>
    ///   <para>Sql.Fill(query, mDt, new Pair{{"ColName", Value}});</para>
    ///   <para> //or </para>
    ///   <para> Sql.Fill(query, mDt,new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="query">query</param>
    /// <param name="mDt">mDt</param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool Fill(string query, DataTable mDt, Pair param = null);

    void FillClosure(string query, Pair param, CommandType cmdType, Action<DbConnection, DbCommand, DbDataAdapter> action);
    /// <summary>
    ///   Fill dataset with params
    ///   <para>//Declare</para>
    ///   <para> var query = "SELECT ...";</para>
    ///   <para> var mDs = new DataSet(); </para>
    ///   <para> var sErr = String.Empty;</para>
    ///   <para> var nErrCode = -1;</para>
    ///   <para>//Call it</para>
    ///   <para> Sql.FillDataset(query, mDs); </para>
    ///   <para>//Call it</para>
    ///   <para> Sql.FillDataset(query, mDs, new Pair{{"ColName", Value}}); </para>
    ///   <para> //or </para>
    ///   <para> Sql.FillDataset(query, mDs, new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="mDs"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool FillDataset(string query, DataSet mDs, Pair param = null);

    void FillSchema(string sSql, DataTable mDt, SchemaType scheType = SchemaType.Source);
    void FillSchemaWithTable(string table, DataTable mDt);
    bool GetTable(System.Data.DataTable mDt, string sTable, Pair param, params string[] cols);
    bool GetTable(System.Data.DataTable mDt, string sTable, string sColList = "*", Pair param = null);
    bool GetTable(System.Data.DataTable mDt, string sTable, string sColList, string sOrderby, Pair param = null);


    /// <summary>
    ///   Fill datatable with params
    /// </summary>
    /// <param name="query"></param>
    /// <param name="mDt"></param>
    /// <param name="param"></param>
    /// <returns></returns> 
    bool PagingGetPage(string query, DataTable mDt, int page, int pageSize, Pair param);
                                                                                    
    /// <summary>
    ///   Fill datatable by storedprocedure with params
    /// </summary>
    /// <param name="storedProcName"></param>
    /// <param name="mDt"></param>
    /// <param name="param"></param>
    /// <returns></returns> 
    bool PagingSpGetPage(string storedProcName, DataTable mDt, int page, int pageSize, Pair param);    
    
    bool SpExecNonQuery(string storedProcName, Pair param = null);
    void SpExecReader(string storedProcName, Pair param, Action<DbDataReader> action);
    object SpExecScalar(string storedProcName, Pair param = null);

    /// <summary>
    ///   Fill datatable by storedprocedure with params
    ///   <para>//Declare</para>
    ///   <para> var query = "StoredProcName";</para>
    ///   <para> var mDt = new DataTable(); </para>
    ///   <para>//Call it</para>
    ///   <para> Sql.StoredProcFill(query, mDt);  </para>
    ///   <para>//Call it</para>
    ///   <para> Sql.StoredProcFill(query, mDt, new Pair{{"ColName", Value}}); </para>
    ///   <para> //or </para>
    ///   <para>Sql.StoredProcFill(query, mDt, new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="sStoredProcName"></param>
    /// <param name="mDt"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool SpFill(string sStoredProcName, DataTable mDt, Pair param = null);

    /// <summary>
    ///   Fill dataset by storedprocedure with params
    ///   <para>//Declare</para>
    ///   <para> var query = "SELECT ...";</para>
    ///   <para> var mDs = new DataSet(); </para>
    ///   <para>//Call it</para>
    ///   <para> Sql.StoredProcFillDs(query, mDs); </para>
    ///   <para> //or </para>
    ///   <para> Sql.StoredProcFillDs(query, mDs); </para>
    ///   <para>//Call it</para>
    ///   <para> Sql.StoredProcFillDs(query, mDs, new Pair{{"ColName", Value}}); </para>
    ///   <para> //or </para>
    ///   <para> Sql.StoredProcFillDs(query, mDs, new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="sStoredProcName"></param>
    /// <param name="mDs"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool StoredProcFillDs(string sStoredProcName, DataSet mDs, Pair param = null);

    /// <summary>
    ///   <para>//Declare</para>
    ///   <para> var query = "SELECT ...";</para>
    ///   <para>//Call it</para>
    ///   <para> Sql.Update(query, vRow);</para>
    ///   <para>//Call it</para>
    ///   <para> Sql.Update(query, vRow, new Pair{{"ColName", Value}}); </para>
    ///   <para> //or </para>
    ///   <para> Sql.Update(query, vRow, new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="vRow">an exists DataRow</param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool Update(string query, DataRow vRow, Pair param = null);

    /// <summary>
    ///   <para>//Declare</para>
    ///   <para>var query= "SELECT...";</para>
    ///   <para>//Call it</para>
    ///   <para>Sql.Update(query, mDt);</para>
    ///   <para>//Call it</para>
    ///   <para> Sql.Update(query, mDt, new Pair{{"ColName", Value}}); </para>
    ///   <para> //or </para>
    ///   <para> Sql.Update(query, mDt, new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="mDt">an exists DataTable</param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool Update(string query, DataTable mDt, Pair param = null);
    void UpdateClosure(string query, Pair param, Action<DbConnection, DbCommand, DbDataAdapter, DbCommandBuilder> action);

    /// <summary>
    ///   <para>//Declare</para>
    ///   <para> var query = "SELECT ...";</para>
    ///   <para>//Call it</para>
    ///   <para> Sql.UpdateDataset(query, mDt ); </para>
    ///   <para>//Call it</para>
    ///   <para> Sql.UpdateDataset(query, mDt, new Pair{{"ColName", Value}}); </para>
    ///   <para> //or </para>
    ///   <para> Sql.UpdateDataset(query, mDt, new Pair{{"ColName", Value}, {"ColName2", Value2}}); </para>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="mDs"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool UpdateDataset(string query, DataSet mDs, Pair param = null);
    /// <summary>
    /// Update an array of <code>DataRow</code>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="mArrRow"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    bool UpdateRows(string query, DataRow[] mArrRow, Pair param = null);
  }
}
