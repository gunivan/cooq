using CooQ.Column;
using CooQ.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooQ
{
  internal static class SqlHelper
  {
    private static List<string> list1 = new List<string>()
      {
        "select",
        "from",
        "left join",
        "right join",
        "cross join",
        "join",
        "where",
        "group by",
        "order by",
        "having",
        "limit",
        "union",
        "union all",
        "except",
        "insert",
        "update",
        "delete"
      };
    /// <summary>
    /// Returns list of distinct Guids
    /// 
    /// </summary>
    /// <param name="pResult"/><param name="column"/>
    /// <returns/>
    public static IList<Guid> ToList(IResult pResult, GuidColumn column)
    {
      List<Guid> list = new List<Guid>();
      int pIndex = 0;
      while (pIndex < pResult.Count)
      {
        Guid guid = (Guid)pResult.GetRow(column.Table, pIndex).GetValue(column);
        if (!list.Contains(guid))
          list.Add(guid);
        checked { ++pIndex; }
      }
      return (IList<Guid>)list;
    }

    /// <summary>
    /// Returns list of distinct Guid?'s
    /// 
    /// </summary>
    /// <param name="pResult"/><param name="column"/>
    /// <returns/>
    public static IList<Guid?> ToList(IResult pResult, NGuidColumn column)
    {
      List<Guid?> list = new List<Guid?>();
      int pIndex = 0;
      while (pIndex < pResult.Count)
      {
        Guid? nullable = (Guid?)pResult.GetRow(column.Table, pIndex).GetValue(column);
        if (!list.Contains(nullable))
          list.Add(nullable);
        checked { ++pIndex; }
      }
      return (IList<Guid?>)list;
    }

    /// <summary>
    /// Returns dictionary. Throws an exception if the key column does not contains unique values.
    /// 
    /// </summary>
    /// <param name="pResult"/><param name="pKeyColumn"/><param name="valueColumn"/>
    /// <returns/>
    public static IDictionary<Guid, string> ToDictionary(IResult pResult, GuidColumn pKeyColumn, StringColumn valueColumn)
    {
      Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
      int pIndex = 0;
      while (pIndex < pResult.Count)
      {
        Guid key = (Guid)pResult.GetRow(pKeyColumn.Table, pIndex).GetValue(pKeyColumn);
        string str = (string)pResult.GetRow(valueColumn.Table, pIndex).GetValue(valueColumn);
        dictionary.Add(key, str);
        checked { ++pIndex; }
      }
      return (IDictionary<Guid, string>)dictionary;
    }

    /// <summary>
    /// Returns the byte size of object as it would most likely be stored in database.
    ///             e.g. string = 2 bytes per character (assumes uni code)
    /// 
    /// </summary>
    /// <param name="pObject"/>
    /// <returns/>
    public static int GetAproxByteSizeOf(object pObject)
    {
      int num;
      if (pObject == null)
        num = 0;
      else if (pObject is string)
        num = checked(((string)pObject).Length * 2);
      else if (pObject is int || pObject is int?)
        num = 4;
      else if (pObject is short || pObject is short?)
        num = 2;
      else if (pObject is long || pObject is long? || pObject is long)
        num = 8;
      else if (pObject is Decimal || pObject is Decimal?)
        num = 9;
      else if (pObject is DateTime || pObject is DateTime?)
        num = 8;
      else if (pObject is DateTimeOffset || pObject is DateTimeOffset?)
        num = 9;
      else if (pObject is bool || pObject is bool?)
        num = 1;
      else if (pObject is Guid || pObject is Guid?)
        num = 16;
      else if (pObject is byte[])
        num = ((byte[])pObject).Length;
      else if (pObject is byte || pObject is byte?)
        num = 1;
      else if (pObject is double || pObject is double?)
        num = 8;
      else if (pObject is float || pObject is float?)
      {
        num = 32;
      }
      else
      {
        if (!(pObject is DateTime) && !(pObject is DateTime?))
          throw new Exception("Unknown data type: '" + pObject.GetType().ToString() + "'");
        num = 8;
      }
      return num;
    }

    /// <summary>
    /// Formats sql query into a more readable format
    /// 
    /// </summary>
    /// <param name="pSql"/>
    /// <returns/>
    public static string FormatSql(string pSql)
    {
      if (string.IsNullOrEmpty(pSql))
        return string.Empty;
      List<string> list2 = SqlHelper.SplitIntoTokens(pSql);
      StringBuilder stringBuilder = new StringBuilder();
      int index = 0;
      while (index < list2.Count)
      {
        char c = stringBuilder.Length > 0 ? stringBuilder[checked(stringBuilder.Length - 1)] : ' ';
        string str1 = list2[index];
        if (!char.IsWhiteSpace(c) && (int)c != 40 && ((int)c != 41 && str1 != "(") && str1 != ")")
          stringBuilder.Append(' ');
        string str2 = (index > 0 ? list2[checked(index - 1)] : string.Empty).ToLower();
        string str3 = str1.ToLower();
        string str4 = (checked(index + 1) < list2.Count ? list2[checked(index + 1)] : string.Empty).ToLower();
        if (list1.Contains(str3) && (string.IsNullOrEmpty(str2) || !list1.Contains(str2 + ' ' + str3)) || list1.Contains(str3 + ' ' + str4))
          stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append(str1);
        checked { ++index; }
      }
      return stringBuilder.ToString().Trim();
    }

    private static List<string> SplitIntoTokens(string pSql)
    {
      List<string> list = new List<string>();
      StringBuilder stringBuilder = new StringBuilder();
      int index = 0;
      while (index < pSql.Length)
      {
        char c = pSql[index];
        if (char.IsWhiteSpace(c) || (int)c == 40 || (int)c == 41)
        {
          list.Add(stringBuilder.ToString());
          if (!char.IsWhiteSpace(c))
            list.Add(string.Concat(c));
          stringBuilder.Clear();
        }
        else
          stringBuilder.Append(c);
        checked { ++index; }
      }
      if (stringBuilder.Length > 0)
        list.Add(stringBuilder.ToString());
      return list;
    }
  }
}
