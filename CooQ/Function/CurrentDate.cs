using CooQ;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class CurrentDateTime : DateTimeFunctionBase
  {
    private readonly DatabaseType mDatabaseType;

    public DateTime this[int pIndex, IResult pResult]
    {
      get
      {
        return (DateTime)pResult.GetValue((ISelectable)this, pIndex);
      }
    }

    public CurrentDateTime(DatabaseType databaseType)
    {
      if (DatabaseType.NONE.Equals(databaseType))
        throw new Exception("Unsupported database type.");
      this.mDatabaseType = databaseType;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      if (this.mDatabaseType == DatabaseType.MSSQL)
        return "GETDATE()";
      if (this.mDatabaseType == DatabaseType.POSTGRESQL)
        return "current_timestamp";
      throw new Exception("Unknown database type: " + this.mDatabaseType.ToString());
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return dataReader.GetDateTime(columnIndex);
    }
  }
}
