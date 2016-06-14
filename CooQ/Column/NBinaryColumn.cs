using CooQ;
using CooQ.Conditions;
using CooQ.Types;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  /// <summary>
  /// Nullable Binary column
  ///             This column maps to nullable binary fields like binary and bytea
  /// 
  /// </summary>
  public class NBinaryColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Binary;
      }
    }

    public NBinaryColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NBinaryColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NBinaryColumn columnA, BinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NBinaryColumn columnA, NBinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NBinaryColumn columnA, byte[] value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(NBinaryColumn columnA, BinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NBinaryColumn columnA, NBinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NBinaryColumn columnA, byte[] value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return (byte[]) dataReader.GetValue(columnIndex);
    }

    public byte[] ValueOf(Record record)
    {
      return (byte[]) record.GetValue(this);
    }

    public void SetValue(Record record, byte[] value)
    {
      record.SetValue(this, value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString()
    {
      return base.ToString();
    }

    public override object GetDefaultType()
    {
      return null;
    }
    public override bool Nullable()
    {
      return true;
    }
  }
}
