using CooQ;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class CurrentDateTimeOffset : DateTimeFunctionBase
  {
    private readonly DatabaseType mDatabaseType;

    public DateTimeOffset this[int pIndex, IResult pResult]
    {
      get
      {
        return (DateTimeOffset) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public CurrentDateTimeOffset(DatabaseType databaseType)
    {
      if (DatabaseType.NONE.Equals(databaseType))
        throw new Exception("Unsupported database type.");
      this.mDatabaseType = databaseType;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      if (this.mDatabaseType == DatabaseType.MSSQL)
        return "SYSDATETIMEOFFSET()";
      if (this.mDatabaseType == DatabaseType.POSTGRESQL)
        return "current_timestamp";
      throw new Exception("Unknown database type: " + this.mDatabaseType.ToString());
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return (DateTimeOffset) dataReader.GetValue(columnIndex);
    }
  }
}
