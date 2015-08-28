using System;
using System.Collections.Generic;
using System.Linq;
namespace CooQ.Database
{
  public class DbTable : DbObject
  {
    private readonly string mSchemaName;
    private readonly IList<DbColumn> mColumns;                

    public string SchemaName
    {
      get
      {
        return this.mSchemaName;
      }
    }

    public IList<DbColumn> Columns
    {
      get
      {
        return this.mColumns;
      }
    }

    public DbTable(string pName, string pSchemaName, IList<DbColumn> columns)
    {
      if (string.IsNullOrEmpty(pName))
        throw new Exception("pName cannot be null or empty");
      if (columns == null)
        throw new NullReferenceException("columns cannot be null");
      this.OriginName = pName;
      this.mSchemaName = !string.IsNullOrEmpty(pSchemaName) ? pSchemaName : string.Empty;
      this.mColumns = columns;
    }

    public String GetColumnArrayString()
    {
      return String.Join(", ", Columns.Select(c => c.Name));
    }
    public String GetColumnArrayStringToUpper()
    {
      return String.Join(", ", Columns.Select(c => c.Name.ToUpper()));
    }
  }
}
