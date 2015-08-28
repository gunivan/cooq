using System.Data;

namespace CooQ.Database
{
  public class SpParameter
  {
    public int ParamId { get; private set; }

    public string Name { get; private set; }

    public DbType ParamType { get; private set; }

    public ParameterDirection Direction { get; private set; }

    public SpParameter(int pParamId, string pName, DbType pParamType, ParameterDirection pDirection)
    {
      this.ParamId = pParamId;
      this.Name = pName;
      this.ParamType = pParamType;
      this.Direction = pDirection;
    }
  }
}
