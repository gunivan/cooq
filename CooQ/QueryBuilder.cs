using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CooQ.Builder;
using CooQ.Core;

namespace CooQ
{
  public static class QueryBuilder
  {
    private static String ART_SYMBOY = "@";
    private static String OP_LIKE = "LIKE";
    private static String OP_EQUAL = "=";
    private static String OP_AND = "AND";
    private static String OP_OR = "OR";
    private static readonly string SELECT_FROM_WHERE = "SELECT {0} FROM \"{1}\" {2}";

    /// <summary>
    /// WHERE a like '%@a%'  
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String WhereLike(Pair param)
    {
      if (null == param)
        return String.Empty;
      return WhereLike(param.Keys.ToArray());
    }

    /// <summary>
    /// WHERE a like '%@a%'
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String WhereLike(params string[] param)
    {
      if ((param == null) || (param.Length <= 0)) return string.Empty;

      var sb = new StringBuilder();
      sb.Append(" WHERE ");

      sb.Append(string.Format("\"{0}\" {1} '%@{0}%'", param[0], OP_LIKE));

      if (1 == param.Length)
      {
        return sb.ToString();
      }

      for (var i = 1; i < param.Length; i++)
      {
        sb.Append(string.Format(" {0} \"{1}\" {2} '%@{1}%'", OP_AND, param[i], OP_LIKE));
      }
      return sb.ToString();
    }

    /// <summary>
    /// WHERE a = @a AND b = @b
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String WhereOr(Pair param)
    {
      return Where(param, OP_EQUAL, OP_OR);
    }

    /// <summary>
    /// WHERE a = @a AND b = @b
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String WhereOr(params string[] param)
    {
      return Where(param, OP_EQUAL, OP_OR);
    }

    /// <summary>
    /// WHERE a opCompare @a opName b opCompare @b
    /// </summary>
    /// <param name="param"></param>
    /// <param name="opCompare"></param>
    /// <param name="opName"></param>
    /// <returns></returns>
    public static String Where(Pair param, String opCompare = "=", String opName = "AND")
    {
      return null == param ? string.Empty : Where(param.Keys.ToArray(), opCompare, opName);
    }

    /// <summary>
    /// WHERE a opCompare @a opName b opCompare @b
    /// </summary>
    /// <param name="param"></param>
    /// <param name="opCompare"></param>
    /// <param name="opName"></param>
    /// <returns></returns>
    public static String Where(string[] param, String opCompare = "=", String opName = "AND")
    {
      if ((param == null) || (param.Length <= 0)) return string.Empty;

      var sb = new StringBuilder();
      sb.Append(" WHERE ");

      sb.Append(string.Format("\"{0}\" {1} @{0}", param[0], opCompare));

      if (1 == param.Length)
      {
        return sb.ToString();
      }

      for (var i = 1; i < param.Length; i++)
      {
        sb.Append(string.Format(" {0} \"{1}\" {2} @{1}", opName, param[i], opCompare));
      }
      return sb.ToString();
    }

    /// <summary>
    /// SELECT {from ?? *} FROM {table} WHERE {where}
    /// </summary>
    /// <param name="table"></param>
    /// <param name="selectCol"></param>
    /// <param name="where"></param>
    /// <returns></returns>
    public static String Select(String table, String selectCol, String where)
    {
      if (String.IsNullOrEmpty(selectCol))
        selectCol = "*";
      var sb = new StringBuilder();
      sb.AppendFormat("SELECT {0} FROM \"{1}\" {2}", selectCol, table, String.IsNullOrEmpty(where) ? "" : " " + where.Trim());
      return sb.ToString();
    }

    /// <summary>
    /// SELECT {param ?? *} FROM {table} WHERE {paramWhere}
    /// </summary>
    /// <param name="table"></param>
    /// <param name="paramWhere"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String Select(String table, Pair paramWhere, params String[] param)
    {
      var sb = new StringBuilder();
      var list = new List<String>();
      foreach (var item in param)
      {
        if (item.Contains(","))
        {
          list.AddRange(item.Split(','));
        }
        else
        {
          if ("*".Equals(item))
            list.Add(item);
          else
            list.Add("\"" + item + "\"");
        }
      }
      sb.AppendFormat(SELECT_FROM_WHERE, param.Length <= 0 ? "*" : String.Join(",", list), table, Where(paramWhere));
      return sb.ToString();
    }

    /// <summary>
    /// SELECT {selectCols} FROM {table} WHERE {a opCompare @a opName b opCompare @b in arrWhere}
    /// </summary>
    /// <param name="table"></param>
    /// <param name="opCompare"></param>
    /// <param name="opName"></param>
    /// <param name="arrWhere"></param>
    /// <param name="selectCols"></param>
    /// <returns></returns>
    public static string QueryWith(string table, String opCompare, string opName, string[] arrWhere, params string[] selectCols)
    {
      return Select(table, String.Join(", ", selectCols), Where(arrWhere, opCompare, opName));
    }

    /// <summary>
    /// SELECT {selectCols} FROM {table} WHERE a = @a AND b = @b
    /// </summary>
    /// <param name="table"></param>
    /// <param name="arrWhere"></param>
    /// <param name="selectCols"></param>
    /// <returns></returns>
    public static string QueryWithAnd(string table, string[] arrWhere, params string[] selectCols)
    {
      return Select(table, String.Join(", ", selectCols), Where(arrWhere, OP_EQUAL, OP_AND));
    }

    /// <summary>
    ///  SELECT {selectCols} FROM {table} WHERE a = @a OR b = @b
    /// </summary>
    /// <param name="table"></param>
    /// <param name="arrWhere"></param>
    /// <param name="selectCols"></param>
    /// <returns></returns>
    public static string QueryWithOr(string table, string[] arrWhere, params string[] selectCols)
    {
      return Select(table, String.Join(", ", selectCols), Where(arrWhere, OP_EQUAL, OP_OR));
    }

    /// <summary>
    /// INSERT INTO .... (...) VALUES(...)
    /// </summary>
    /// <param name="table"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String Insert(String table, Pair param)
    {
      var valueNames = new StringBuilder();
      var keys = param.Keys.ToArray();
      if (keys.Length <= 0)
        throw new ArgumentNullException();

      valueNames.Append(ART_SYMBOY + keys[0]);

      if (keys.Length > 1)
      {
        for (int i = 1; i < keys.Length; i++)
        {
          valueNames.Append(", " + ART_SYMBOY + keys[i]);
        }
      }
      String query = String.Format(
        "INSERT INTO \"{0}\"({1}) VALUES({2})",
        table, String.Join(", ", keys), valueNames.ToString());
      return query;
    }

    /// <summary>
    /// UPDATE ... SET ...
    /// </summary>
    /// <param name="table"></param>
    /// <param name="paramSet"></param>
    /// <param name="paramWhere"></param>
    /// <returns></returns>
    public static String Update(String table, Pair paramSet, Pair paramWhere)
    {
      var columns = new StringBuilder();
      var keys = paramSet.Keys.ToArray();
      if (keys.Length <= 0)
        throw new ArgumentNullException();

      columns.AppendFormat("\"{0}\" = @{0}", keys[0]);

      if (keys.Length > 1)
      {
        for (int i = 1; i < keys.Length; i++)
        {
          columns.AppendFormat(", \"{0}\" = @{0}", keys[i]);
        }
      }
      String query = String.Format("UPDATE \"{0}\" SET {1}{2}",
        table, columns.ToString(), Where(paramWhere));
      return query;
    }

    /// <summary>
    /// DELETE FROM ... WHERE ...
    /// </summary>
    /// <param name="table"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static String Delete(String table, Pair param)
    {
      var keys = param.Keys.ToArray();
      if (keys.Length <= 0)
      {
        return String.Format("DELETE FROM \"{0}\"", table);
      }

      return String.Format("DELETE FROM \"{0}\"{1}", table, Where(param));
    }
  }
}
