using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Data;

namespace CooQ
{
  public static class Settings
  {
    /// <summary>
    /// Default value to turn query parameters on or off.
    /// 
    /// </summary>
    public static bool UseParameters { get; set; }

    /// <summary>
    /// When updating ARow records an exception is thrown if the original row data has changed on the database. If set to false this feature is turned off.
    /// 
    /// </summary>
    public static bool UseConcurrenyChecking { get; set; }

    /// <summary>
    /// Default query timeout setting in seconds. Default value is 30 seconds.
    /// 
    /// </summary>
    public static int DefaultTimeout { get; set; }

    /// <summary>
    /// When using the QueryPerformed event if true then the result size is passed else it isn't. This setting is here for performance reasons.
    /// 
    /// </summary>
    public static bool ReturnResultSize { get; set; }

    /// <summary>
    /// Event fired when a query begins execution
    /// 
    /// </summary>
    public static event Settings.QueryExecutingDelegate QueryExecuting;

    /// <summary>
    /// Event fired when a query completes execution or throws an exception
    /// 
    /// </summary>
    public static event Settings.QueryPerformedDelegate QueryPerformed;

    /// <summary>
    /// 
    /// </summary>
    public static event Settings.ExecutorExecutingDelegate ExecutorExecuting;

    /// <summary>
    /// 
    /// </summary>
    public static event Settings.ExecutorExecutedDelegate ExecutorExecuted;

    static Settings()
    {
      Settings.UseParameters = true;
      Settings.UseConcurrenyChecking = false;
      Settings.DefaultTimeout = 300;
      Settings.ReturnResultSize = false;
    }

    internal static void FireQueryExecutingEvent(DatabaseBase database, string pSql, QueryType pQueryType, DateTime? pStart, IsolationLevel pIsolationLevel, ulong? transactionId)
    {
      try
      {
        if (Settings.QueryExecuting == null)
          return;
        Settings.QueryExecuting(database, pSql, pQueryType, pStart, pIsolationLevel, transactionId);
      }
      catch
      {
      }
    }

    internal static void FireQueryPerformedEvent(DatabaseBase database, string pSql, int records, QueryType pQueryType, DateTime? pStart, DateTime? pEnd, Exception pException, IsolationLevel pIsolationLevel, IResult pResult, ulong? transactionId)
    {
      try
      {
        if (Settings.QueryPerformed == null)
          return;
        int? pResultSize = !Settings.ReturnResultSize || pResult == null ? new int?() : new int?(pResult.GetDataSetSizeInBytes());
        Settings.QueryPerformed(database, pSql, records, pQueryType, pStart, pEnd, pException, pIsolationLevel, pResultSize, transactionId);
      }
      catch
      {
      }
    }

    internal static void FireQueryExecutingEvent(string query, CommandType type)
    {
      try
      {
        if (Settings.ExecutorExecuting == null)
          return;
        Settings.ExecutorExecuting(query, type);
      }
      catch
      {
      }
    }
    internal static void FireQueryExecutedEvent(string message)
    {
      try
      {
        if (Settings.ExecutorExecuted == null)
          return;
        Settings.ExecutorExecuted(message);
      }
      catch
      {
      }
    }

    public delegate void QueryExecutingDelegate(DatabaseBase database, string pSql, QueryType pQueryType, DateTime? pStart, IsolationLevel pIsolationLevel, ulong? transactionId);

    public delegate void QueryPerformedDelegate(DatabaseBase database, string pSql, int records, QueryType pQueryType, DateTime? pStart, DateTime? pEnd, Exception pException, IsolationLevel pIsolationLevel, int? pResultSize, ulong? transactionId);

    public delegate void ExecutorExecutingDelegate(string query, CommandType type);

    public delegate void ExecutorExecutedDelegate(string message);
  }
}
