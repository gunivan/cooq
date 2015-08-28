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
  public class EnumColumn<ENUM> : ColumnBase, IEnumColumn
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int16;
      }
    }

    public EnumColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public EnumColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(EnumColumn<ENUM> columnA, EnumColumn<ENUM> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(EnumColumn<ENUM> columnA, ENUM value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(EnumColumn<ENUM> columnA, EnumColumn<ENUM> columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(EnumColumn<ENUM> columnA, ENUM value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public Condition In(List<ENUM> list)
    {
      return (Condition) new InCondition<ENUM>(this, (IList<ENUM>) list);
    }

    public Condition NotIn(List<ENUM> list)
    {
      return (Condition) new NotInCondition<ENUM>(this, (IList<ENUM>) list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params ENUM[] values)
    {
      return (Condition) new InCondition<ENUM>(this, values);
    }

    public Condition NotIn(params ENUM[] values)
    {
      return (Condition) new NotInCondition<ENUM>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      object obj = dataReader.GetValue(columnIndex);
      if (obj is byte)
        return (int) (byte) obj;
      if (obj is short)
        return (int) (short) obj;
      return (int) obj;
    }

    public ENUM ValueOf(Record record)
    {
      return (ENUM) record.GetValue(this);
    }

    public void SetValue(Record record, ENUM value)
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
