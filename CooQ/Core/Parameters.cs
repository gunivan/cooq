using System;
using System.Data;
using System.Data.Common;

namespace CooQ.Core
{
  internal class Parameters
  {
    private int mParamCounter = 1;
    private readonly DbCommand mCommand;

    public Parameters(DbCommand pCommand)
    {
      if (pCommand == null)
        throw new NullReferenceException("pCommand cannot be null");
      this.mCommand = pCommand;
    }

    public string AddParameter(DbType dbType, object value)
    {
      if (this.mCommand.Parameters.Count < 15)
      {
        foreach (DbParameter dbParameter in this.mCommand.Parameters)
        {
          if (dbParameter.Value.Equals(value) && dbParameter.DbType == dbType)
            return dbParameter.ParameterName;
        }
      }
      DbParameter parameter = this.mCommand.CreateParameter();
      parameter.ParameterName = "@" + this.mParamCounter;
      parameter.DbType = dbType;
      parameter.Value = value != null ? value : DBNull.Value;
      this.mCommand.Parameters.Add(parameter);
      checked { ++this.mParamCounter; }
      return parameter.ParameterName;
    }
  }
}
