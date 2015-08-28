using CooQ;
using CooQ.Column;
using CooQ.Database;
using CooQ.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace CooQ.Generate
{
  internal static class GenerateCode
  {                                   
    public static string GenerateStoredProcedureCode(StoredProcedure pProc, string columnPrefix, bool pIncludeSchema)
    {
      string newLine = Environment.NewLine;
      string str = "\t";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("using System;").Append(newLine);
      stringBuilder.Append("using System.Data;");
      stringBuilder.Append("using System.Data.SqlClient;");
      stringBuilder.Append("namespace Tables.").Append(pProc.Name).Append(" {").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append("public sealed class Proc : ").Append(typeof(StoredProcBase).ToString()).Append(" {").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append(str).Append("public static readonly Proc Instance = new Proc();").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append(str).Append("public Proc() : base(DATABASE, \"").Append(!pIncludeSchema || string.IsNullOrEmpty(pProc.Schema) ? string.Empty : pProc.Schema + ".").Append(pProc.Name).Append("\", typeof(Row)) {").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append(str).Append(str).Append("//AddColumns(");
      stringBuilder.Append(");").Append(newLine);
      stringBuilder.Append(str).Append(str).Append("}").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append(str).Append("public Sql.IResult Execute(");
      int index1 = 0;
      while (index1 < pProc.Parameters.Count)
      {
        SpParameter spParameter = pProc.Parameters[index1];
        if (index1 > 0)
          stringBuilder.Append(", ");
        if (spParameter.Direction == ParameterDirection.Output || spParameter.Direction == ParameterDirection.ReturnValue)
          stringBuilder.Append("out ");
        stringBuilder.Append(DbColumnFactory.GetReturnType(spParameter.ParamType, false)).Append(" ").Append(spParameter.Name);
        checked { ++index1; }
      }
      if (pProc.Parameters.Count > 0)
        stringBuilder.Append(", ");
      stringBuilder.Append("Sql.Transaction transaction){").Append(newLine).Append(newLine);
      int index2 = 0;
      while (index2 < pProc.Parameters.Count)
      {
        SpParameter spParameter = pProc.Parameters[index2];
        stringBuilder.Append(str).Append(str).Append(str).Append("SqlParameter p").Append(index2.ToString()).Append(" = new SqlParameter(\"").Append(spParameter.Name).Append("\", SqlDbType.").Append(DbColumnFactory.GetSqlType(spParameter.ParamType).ToString()).Append(");").Append(newLine);
        stringBuilder.Append(str).Append(str).Append(str).Append("p").Append(index2.ToString()).Append(".Direction = ParameterDirection.").Append(spParameter.Direction.ToString()).Append(";").Append(newLine);
        if (spParameter.Direction == ParameterDirection.Input || spParameter.Direction == ParameterDirection.InputOutput)
          stringBuilder.Append(str).Append(str).Append(str).Append("p").Append(index2.ToString()).Append(".Value = ").Append(spParameter.Name).Append(";").Append(newLine);
        stringBuilder.Append(newLine);
        checked { ++index2; }
      }
      stringBuilder.Append(str).Append(str).Append(str).Append("Sql.IResult result = ExecuteProcedure(transaction");
      int num = 0;
      while (num < pProc.Parameters.Count)
      {
        stringBuilder.Append(", p").Append(num.ToString());
        checked { ++num; }
      }
      stringBuilder.Append(");").Append(newLine).Append(newLine);
      int index3 = 0;
      while (index3 < pProc.Parameters.Count)
      {
        SpParameter spParameter = pProc.Parameters[index3];
        if (spParameter.Direction == ParameterDirection.InputOutput || spParameter.Direction == ParameterDirection.Output || spParameter.Direction == ParameterDirection.ReturnValue)
          stringBuilder.Append(str).Append(str).Append(str).Append(spParameter.Name).Append(" = (").Append(DbColumnFactory.GetReturnType(spParameter.ParamType, false)).Append(")").Append("p").Append(index3.ToString()).Append(".Value;").Append(newLine);
        checked { ++index3; }
      }
      stringBuilder.Append(str).Append(str).Append(str).Append("return result;").Append(newLine);
      stringBuilder.Append(str).Append(str).Append("}").Append(newLine).Append(newLine);
      stringBuilder.Append(str).Append(str).Append("public Row this[int pIndex, Sql.IResult pResult]{").Append(newLine);
      stringBuilder.Append(str).Append(str).Append(str).Append("get { return (Row)pResult.GetRow(this, pIndex); }").Append(newLine);
      stringBuilder.Append(str).Append(str).Append("}").Append(newLine);
      stringBuilder.Append(str).Append("}").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append("public sealed class Row : ").Append(typeof(Record).ToString()).Append(" {").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append(str).Append("private new Proc Tbl {").Append(newLine);
      stringBuilder.Append(str).Append(str).Append(str).Append("get { return (Proc)base.Tbl; }").Append(newLine);
      stringBuilder.Append(str).Append(str).Append("}").Append(newLine);
      stringBuilder.Append(newLine);
      stringBuilder.Append(str).Append(str).Append("public Row() : base(Proc.Instance) {").Append(newLine);
      stringBuilder.Append(str).Append(str).Append("}").Append(newLine);
      stringBuilder.Append(str).Append("}").Append(newLine);
      stringBuilder.Append("}");
      return stringBuilder.ToString();
    }                       
  }
}
