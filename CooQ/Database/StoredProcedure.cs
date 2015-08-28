using System.Collections.Generic;

namespace CooQ.Database
{
  public class StoredProcedure
  {
    public string Schema { get; private set; }

    public string Name { get; private set; }

    public List<SpParameter> Parameters { get; private set; }

    public StoredProcedure(string schemaName, string pName)
    {
      this.Schema = schemaName;
      this.Name = pName;
      this.Parameters = new List<SpParameter>();
    }

    public void AddParameter(SpParameter pParameter)
    {
      this.Parameters.Add(pParameter);
    }
  }
}
