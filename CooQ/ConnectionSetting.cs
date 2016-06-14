using CooQ.Types;
using System;

namespace CooQ
{
  public class ConnectionSetting
  {
    public DatabaseType Type { get; set; }
    public String Server { get; set; }
    public String Database { get; set; }
    public String Username { get; set; }
    public String Password { get; set; }
    public String Port { get; set; }
    public override bool Equals(object obj)
    {
      if (null != obj && this.GetType() == obj.GetType())
      {
        var cs = obj as ConnectionSetting;
        return Type == cs.Type &&
          Server == cs.Server &&
          Port == cs.Port &&
          Database == cs.Database;
      }
      return base.Equals(obj);
    }
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
