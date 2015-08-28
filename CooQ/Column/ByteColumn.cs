using CooQ;
using CooQ.Conditions;
using CooQ.Interfaces;
using CooQ.Types;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  public class ByteColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int32;
      }
    }

    public ByteColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public ByteColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public ByteColumn(TableBase table, string columnName, bool isPrimaryKey, bool isAutoId)
      : base(table, columnName, isPrimaryKey)
    {
      this.IsAutoId = isAutoId;
    }

    public static Condition operator ==(ByteColumn columnA, ByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(ByteColumn columnA, NByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(ByteColumn columnA, byte value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(ByteColumn columnA, ByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(ByteColumn columnA, NByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(ByteColumn columnA, byte value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(ByteColumn columnA, ByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(ByteColumn columnA, NByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >(ByteColumn columnA, byte value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(ByteColumn columnA, ByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(ByteColumn columnA, NByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator >=(ByteColumn columnA, byte value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(ByteColumn columnA, ByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(ByteColumn columnA, NByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <(ByteColumn columnA, byte value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(ByteColumn columnA, ByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(ByteColumn columnA, NByteColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <=(ByteColumn columnA, byte value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public Condition In(IList<byte> list)
    {
      return (Condition) new InCondition<byte>(this, list);
    }

    public Condition NotIn(IList<byte> list)
    {
      return (Condition) new NotInCondition<byte>(this, list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params byte[] values)
    {
      return (Condition) new InCondition<byte>(this, values);
    }

    public Condition NotIn(params byte[] values)
    {
      return (Condition) new NotInCondition<byte>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return dataReader.GetByte(columnIndex);
    }

    public byte ValueOf(Record record)
    {
      return (byte) record.GetValue(this);
    }

    public void SetValue(Record record, byte value)
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
      return 0;
    }
  }
}
