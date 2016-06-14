using CooQ.Column;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CooQ.Utils
{
  internal class DbColumnFactory
  {
    private static IDictionary<DbType, Type> COLUMN_TYPES = new Dictionary<DbType, Type>() { 
    {DbType.Boolean,typeof(BoolColumn)},
    {DbType.DateTime, typeof(DateTimeColumn)},
    {DbType.DateTime2,typeof(DateTime2Column)},
    {DbType.DateTimeOffset,typeof(DateTimeOffsetColumn)},
    {DbType.Decimal, typeof(DecimalColumn)},
    {DbType.Guid, typeof(GuidColumn)},
    {DbType.Int16 ,typeof(SmallIntegerColumn)},
    {DbType.Int32 ,typeof(IntegerColumn)},
    {DbType.Int64,typeof(BigIntegerColumn)},
    {DbType.String,typeof(StringColumn)},
    {DbType.Binary,typeof(BinaryColumn)},
    {DbType.Byte,typeof(ByteColumn)},
    {DbType.Single,typeof(FloatColumn)},
    {DbType.Double ,typeof(DoubleColumn)}};


    private static IDictionary<DbType, String> RETURN_TYPES = new Dictionary<DbType, String>(){  
    {DbType.Boolean, "Boolean"},{DbType.DateTime,"DateTime"},
    {DbType.DateTime2, "DateTime"},{DbType.DateTimeOffset,"DateTimeOffset"},
    {DbType.Decimal, "Decimal"},{DbType.Guid,"Guid"},
    {DbType.Int16, "Int16"},{DbType.Int32,"Int32"},  
    {DbType.Int64, "long"},{DbType.String,"String"},
    {DbType.Binary, "Byte[]"},{DbType.Byte,"Byte"},
    {DbType.Single, "Float"},{DbType.Double,"Double"}};

    private static IDictionary<DbType, SqlDbType> SQL_TYPES = new Dictionary<DbType, SqlDbType>(){  
    {DbType.Int16,SqlDbType.SmallInt},
    {DbType.Int32,SqlDbType.Int},
    {DbType.Int64,SqlDbType.BigInt},
    {DbType.String,SqlDbType.VarChar},
    {DbType.Decimal,SqlDbType.Decimal},
    {DbType.DateTime, SqlDbType.DateTime},
    {DbType.DateTime2,SqlDbType.DateTime2},
    {DbType.DateTimeOffset,SqlDbType.DateTimeOffset},
    {DbType.Byte,SqlDbType.TinyInt},
    {DbType.Double, SqlDbType.Float},
    {DbType.Single ,SqlDbType.Real }};

    static DbColumnFactory()
    {
    }

    internal static String GetColumnTypeName(DbType type, String tableName, Boolean isPrimary = false, Boolean isNullable = false)
    {
      var columnType = COLUMN_TYPES.ContainsKey(type) ? COLUMN_TYPES[type] : null;
      if (null == columnType)
        return type.ToString();
      var values = columnType.ToString().Split('.').ToList();
      var className = values[values.Count - 1];
      values.RemoveAt(values.Count - 1);
      var isCanNull = isNullable && !className.Contains("String");
      return String.Format("{0}.{1}{2}",
        String.Join(".", values),
        (isCanNull ? "N" : ""),
        (isPrimary ? (className.Replace("Column", "KeyColumn") + "<" + tableName + ">") : className));
    }

    internal static String GetReturnType(DbType dbType, bool nullable)
    {
      if (RETURN_TYPES.ContainsKey(dbType))
      {
        var retType = RETURN_TYPES[dbType];
        //if (retType.Contains("[]") || retType.Contains("String"))
        //{
        //  return retType;
        //}
        return retType;//nullable ? retType + "?" : retType;
      }
      return "String";
    }

    internal static SqlDbType GetSqlType(DbType dbType)
    {
      if (SQL_TYPES.ContainsKey(dbType))
      {
        return SQL_TYPES[dbType];
      }
      return SqlDbType.BigInt;
    }

    private static String Capitalize(String s)
    {
      if (String.IsNullOrEmpty(s))
        return "";
      return s.Substring(0, 1).ToUpper() + s.Substring(1);
    }
  }
}
