using CooQ.Builder;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CooQ
{
  public abstract class StoredProcBase : TableBase
  {
    public StoredProcBase(DatabaseBase db, string pProcName, Type recordType)
      : base(db, pProcName, recordType)
    {
    }

    protected IResult ExecuteProcedure(Transaction transaction, params SqlParameter[] pSqlParams)
    {
      return this.ExecuteProcedure(transaction, new int?(), pSqlParams);
    }

    protected IResult ExecuteProcedure(Transaction transaction, int? pTimeout, params SqlParameter[] pSqlParams)
    {
      if (transaction == null)
        throw new NullReferenceException("transaction cannot be null");
      DbConnection dbConnection = (DbConnection) null;
      string str = string.Empty;
      DateTime? pStart = new DateTime?();
      DateTime? pEnd = new DateTime?();
      try
      {
        dbConnection = transaction.GetOrSetConnection(transaction.Database);
        using (DbCommand command = Transaction.CreateCommand(dbConnection, transaction))
        {
          command.CommandText = this.TableName;
          command.CommandType = CommandType.StoredProcedure;
          command.CommandTimeout = pTimeout.HasValue ? pTimeout.Value : Settings.DefaultTimeout;
          command.Transaction = transaction.GetOrSetDbTransaction(transaction.Database);
          command.Parameters.AddRange((Array) pSqlParams);
          str = command.CommandText;
          pStart = new DateTime?(DateTime.Now);
          Settings.FireQueryExecutingEvent(transaction.Database, str, QueryType.StoredProc, pStart, transaction.IsolationLevel, new ulong?(transaction.Id));
          int num = 0;
          IResult result;
          if (this.RowType != (Type) null)
          {
            using (DbDataReader dataReader = command.ExecuteReader())
            {
              result = new QueryResult(transaction.Database, (IList<ISelectable>) this.SelectableColumns, dataReader, command.CommandText);
              num = result.Count;
            }
          }
          else
          {
            num = command.ExecuteNonQuery();
            result = new QueryResult(num, str);
          }
          pEnd = new DateTime?(DateTime.Now);
          Settings.FireQueryPerformedEvent(transaction.Database, str, num, QueryType.StoredProc,
            pStart, pEnd, (Exception) null, transaction.IsolationLevel, null, new ulong?(transaction.Id));
          return result;
        }
      }
      catch (Exception ex)
      {
        if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
          dbConnection.Close();
        Settings.FireQueryPerformedEvent(transaction.Database, str, 0, QueryType.StoredProc, 
          pStart, pEnd, ex, transaction.IsolationLevel, null, new ulong?(transaction.Id));
        throw;
      }
    }
  }
}
