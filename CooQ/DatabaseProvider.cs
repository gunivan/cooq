using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQ
{
  public class DatabaseProvider : CooQ.DatabaseBase
  {
    public static readonly DatabaseProvider INSTANCE = new DatabaseProvider();

    public static void Config(ConnectionSetting setting)
    {
      INSTANCE.Setting = setting;
    }

    private ConnectionSetting setting = new ConnectionSetting();
    public ConnectionSetting Setting
    {
      get
      {
        return setting;
      }
      set
      {
        setting = value;
        this.DatabaseType = setting.Type;
        ConnectionString = QueryExecutor.GetExecutor(setting).GetConnectionString();
      }
    }
    public DatabaseProvider()
      : base("", CooQ.Types.DatabaseType.POSTGRESQL)
    {
    }

    public override System.Data.Common.DbConnection GetConnection(bool canBeReadonly = true)
    {
      DbConnection connection = Query.GetConnection(DatabaseType, ConnectionString);
      if (connection.State != System.Data.ConnectionState.Open)
      {
        connection.Open();                                                                                      
      }                                                                        
      return connection;
    }
  }
}
