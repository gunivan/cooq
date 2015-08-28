using CooQ;
using CooQ.Attributes;
using CooQ.Database;
using System;
using System.Reflection;
using System.Text;

namespace CooQ.Generate
{
  internal class GenerateMetaDataSql
  {
    public string GenerateSql<TABLE>(TABLE table) where TABLE : TableBase
    {
      if ((object)table == null)
        throw new NullReferenceException("table cannot be null");
      StringBuilder stringBuilder = new StringBuilder();
      object[] customAttributes1 = table.GetType().GetCustomAttributes(true);
      string str1 = (string)null;
      foreach (object obj in customAttributes1)
      {
        if (obj is TableAttribute)
        {
          str1 = QueryBuilderFactory.CreateTableComment(table.TableName, ((TableAttribute)obj).Description, table.DefaultDatabase);
          break;
        }
      }
      if (str1 == null)
        str1 = QueryBuilderFactory.CreateTableComment(table.TableName, string.Empty, table.DefaultDatabase);
      stringBuilder.Append(str1).Append(Environment.NewLine);
      foreach (FieldInfo fieldInfo in table.GetType().GetFields())
      {
        if (typeof(ColumnBase).IsAssignableFrom(fieldInfo.FieldType))
        {
          ColumnBase ColumnBase = (ColumnBase)fieldInfo.GetValue(table);
          object[] customAttributes2 = fieldInfo.GetCustomAttributes(true);
          string str2 = (string)null;
          foreach (object obj in customAttributes2)
          {
            if (obj is ColumnAttribute)
            {
              str2 = QueryBuilderFactory.CreateColumnComment(table.TableName, ColumnBase.ColumnName, ((ColumnAttribute)obj).Description, table.DefaultDatabase);
              break;
            }
          }
          if (str2 == null)
            str2 = QueryBuilderFactory.CreateColumnComment(table.TableName, ColumnBase.ColumnName, string.Empty, table.DefaultDatabase);
          stringBuilder.Append(str2).Append(Environment.NewLine);
        }
      }
      return stringBuilder.ToString();
    }
  }
}
