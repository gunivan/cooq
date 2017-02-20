using System;
using System.Data;
using System.Text.RegularExpressions;

namespace CooQGenerate.Utils
{
    public class FieldUtils
    {
        /// <summary>
        /// Get Guid from DataRow
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <returns></returns>
        public static Guid AsGuid(DataRow vRow, String sField)
        {
            try
            {

                if (null == vRow)
                    return Guid.Empty;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return Guid.Empty;
                return vRow.Field<Guid>(sField);
            }
            catch
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Get text from DataRow with default value
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static String AsText(DataRow vRow, String sField, String defValue = "")
        {
            try
            {

                if (null == vRow)
                    return defValue;
                if (vRow[sField] == DBNull.Value)
                    return defValue;
                return Convert.ToString(vRow[sField]).Trim();
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert object to string
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static String AsText(Object obj, String defValue = "")
        {
            try
            {
                if (null == obj)
                    return defValue;
                return obj.ToString().Trim();
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert guid to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String AsString(Guid obj)
        {
            if (obj == null)
                return null;
            if (obj != Guid.Empty)
                return obj.ToString();
            return null;
        }

        /// <summary>
        /// check string is number value or no
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {
            return Regex.Match(value, @"^\d+$").Success;
        }

        /// <summary>
        /// Get double value 
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Double AsDouble(DataRow vRow, String sField, Double defValue = 0)
        {
            try
            {
                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                return Convert.ToDouble(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert object to double value
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Double AsDouble(Object obj, Double defValue = 0)
        {
            try
            {
                if (null == obj)
                    return defValue;
                return Convert.ToDouble(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert object to long value
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Int64 AsLong(Object obj, Int64 defValue = 0)
        {
            try
            {
                if (null == obj)
                    return defValue;
                return Convert.ToInt64(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Get long value from DataRow with default value is 0
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Int64 AsLong(DataRow vRow, String sField, Int64 defValue = 0)
        {
            try
            {
                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                return vRow.Field<Int64>(sField);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Get decimal value from DataRow with default value is 0
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Decimal AsDecimal(DataRow vRow, String sField, Decimal defValue = 0)
        {
            try
            {
                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert object to decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Decimal AsDecimal(Object obj, Decimal defValue = 0)
        {
            try
            {
                if (obj == null)
                    return defValue;
                return Convert.ToDecimal(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Get datetime from DataRow
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <returns></returns>
        public static DateTime AsDate(DataRow vRow, String sField)
        {
            try
            {
                if (null == vRow)
                    return DateTime.MinValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return DateTime.MinValue;
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Get int value from DataRow
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Int32 AsInt(DataRow vRow, String sField, Int32 defValue = 0)
        {
            try
            {

                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                return (int)obj;
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Get byte value from DataRow
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Byte AsByte(DataRow vRow, String sField, Byte defValue = 0)
        {
            try
            {

                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                return vRow.Field<Byte>(sField);
            }
            catch
            {
                return defValue;
            }
        }
        /// <summary>
        /// Get int from DataRow
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Int16 AsInt16(DataRow vRow, String sField, Int16 defValue = 0)
        {
            try
            {

                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                return vRow.Field<Int16>(sField);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert object to int
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Int32 AsInt(Object obj, Int32 defValue = 0)
        {
            try
            {
                if (obj == null)
                    return defValue;
                return Convert.ToInt32(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// convert object to int
        /// if is 0 then return with defvalue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Int32 AsIntZero(Object obj, Int32 defValue = 0)
        {
            try
            {
                if (null == obj)
                    return defValue;
                var result = Convert.ToInt32(obj);
                if (result == 0)
                    return defValue;
                return result;
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Get bool from DataRow
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Boolean AsBool(DataRow vRow, String sField, Boolean defValue = false)
        {
            try
            {
                if (null == vRow)
                    return defValue;
                var obj = vRow[sField];
                if (obj == DBNull.Value)
                    return defValue;
                if ("YES" == obj.ToString())
                    return true;
                else if ("NO" == obj.ToString())
                    return false;
                return Boolean.Parse(obj.ToString());
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Convert object to bool
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Boolean AsBool(Object obj, Boolean defValue = false)
        {
            try
            {
                if (null == obj)
                    return defValue;
                return Convert.ToBoolean(obj);
            }
            catch
            {
                return defValue;
            }
        }

        /// <summary>
        /// Check a value is not null
        /// </summary>
        /// <param name="vRow"></param>
        /// <param name="sField"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static Boolean IsNotNull(DataRow vRow, String sField, Boolean defValue = false)
        {
            return vRow != null ? vRow[sField] != DBNull.Value : defValue;
        }

        public static Boolean LongIsNullOrZero(Object obj)
        {
            try
            {
                if (null == obj) return true;
                return 0 == long.Parse(obj.ToString());
            }
            catch
            {
                return true;
            }
        }
        //Nullable
        public static Double? NullDouble(DataRow vRow, String sField)
        {
            try
            {
                return vRow.Field<Double>(sField);
            }
            catch
            {
                return null;
            }
        }

        public static Decimal? NullDecimal(DataRow vRow, String sField)
        {
            try
            {
                return vRow.Field<Decimal>(sField);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime? NullDate(DataRow vRow, String sField)
        {
            try
            {
                return vRow.Field<DateTime>(sField);
            }
            catch
            {
                return null;
            }
        }

        public static Int32? NullInt(DataRow vRow, String sField)
        {
            try
            {
                return vRow.Field<Int32>(sField);
            }
            catch
            {
                return null;
            }
        }

        //////////////////////////////////////////////////////////////////
        /// <summary>
        /// Find all in field by value
        /// </summary>
        /// <param name="mDt"></param>
        /// <param name="sField"></param>
        /// <param name="sVal"></param>
        /// <returns></returns>
        public static DataRow[] Find(DataTable mDt, String sField, String sVal)
        {
            try
            {
                return mDt.Select(sField + " = '" + sVal + "'");
            }
            catch
            {
                return default(DataRow[]);
            }
        }

        /// <summary>
        /// Find all by a filter
        /// </summary>
        /// <param name="mDt"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static DataRow[] Find(DataTable mDt, String filter)
        {
            try
            {
                return mDt.Select(filter);
            }
            catch
            {
                return default(DataRow[]);
            }
        }

        /// <summary>
        /// Find a row in column with value
        /// </summary>
        /// <param name="mDt"></param>
        /// <param name="field"></param>
        /// <param name="textToFind"></param>
        /// <returns></returns>
        public static DataRow FindId(DataTable mDt, String field, String textToFind)
        {
            try
            {
                var arr = mDt.Select(String.Format("{0} = '{1}'", field, textToFind));
                if (arr.Length > 0)
                    return arr[0];
                return default(DataRow);
            }
            catch
            {
                return default(DataRow);
            }
        }

        /// <summary>
        /// Set value to column for DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        public static void Set<T>(DataRow row, String field, T value)
        {
            if (null == row)
                return;
            if (row.Table.Columns.Contains(field))
            {
                if (row.RowState == DataRowState.Deleted)
                {

                }
                else
                {
                    row.SetField<T>(field, value);
                }
            }
        }
    }
}