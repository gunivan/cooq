using CooQ;
using CooQ.Conditions;
using CooQ.Types;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  /// <summary>
  /// Binary column
  ///             This column maps to binary fields like binary and bytea
  /// 
  /// </summary>
  public class BinaryColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Binary;
      }
    }

    public BinaryColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public BinaryColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(BinaryColumn columnA, BinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(BinaryColumn columnA, NBinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(BinaryColumn columnA, byte[] value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(BinaryColumn columnA, BinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(BinaryColumn columnA, NBinaryColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(BinaryColumn columnA, byte[] value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
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
      return new byte[0];
    }
  }
}
