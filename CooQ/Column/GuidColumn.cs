using CooQ;
using CooQ.Conditions;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  public class GuidColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Guid;
      }
    }

    public GuidColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public GuidColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(GuidColumn columnA, GuidColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(GuidColumn columnA, NGuidColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(GuidColumn columnA, Guid value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(GuidColumn columnA, GuidColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(GuidColumn columnA, NGuidColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(GuidColumn columnA, Guid value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, value);
    }

    public Condition In(List<Guid> list)
    {
      return (Condition) new InCondition<Guid>(this, (IList<Guid>) list);
    }

    public Condition NotIn(List<Guid> list)
    {
      return (Condition) new NotInCondition<Guid>(this, (IList<Guid>) list);
    }

    public Condition In(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.IN, nestedQuery);
    }

    public Condition NotIn(IExecute nestedQuery)
    {
      return (Condition) new NestedQueryCondition(this, Operator.NOT_IN, nestedQuery);
    }

    public Condition In(params Guid[] values)
    {
      return (Condition) new InCondition<Guid>(this, values);
    }

    public Condition NotIn(params Guid[] values)
    {
      return (Condition) new NotInCondition<Guid>(this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return dataReader.GetGuid(columnIndex);
    }

    public Guid ValueOf(Record record)
    {
      return (Guid) record.GetValue(this);
    }

    public void SetValue(Record record, Guid value)
    {
      record.SetValue(this, value);
    }

    public Guid GetValue(DataRow row)
    {
      return base.As<Guid>(row);
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
      return Guid.Empty;
    }
  }
}
