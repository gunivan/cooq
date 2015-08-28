using System;

namespace CooQ.Function
{
  public class CustomSql
  {
    private readonly string mCustomSql;

    public CustomSql(string pCustomSql)
    {
      if (pCustomSql == null)
        throw new NullReferenceException("pCustomSql cannot be null");
      this.mCustomSql = pCustomSql;
    }

    public string GetCustomSql()
    {
      return this.mCustomSql;
    }
  }
}
