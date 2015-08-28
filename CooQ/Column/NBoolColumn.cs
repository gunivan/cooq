using CooQ;
using CooQ.Conditions;
using CooQ.Types;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  /// <summary>
  /// Nullable boolean column
  /// 
  /// </summary>
  public class NBoolColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Boolean;
      }
    }

    public NBoolColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public NBoolColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(NBoolColumn columnA, BoolColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NBoolColumn columnA, NBoolColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(NBoolColumn columnA, bool value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.EQUALS, (value ? true : false));
    }

    public static Condition operator !=(NBoolColumn columnA, BoolColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NBoolColumn columnA, NBoolColumn columnB)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(NBoolColumn columnA, bool value)
    {
      return (Condition)new ColumnCondition(columnA, Operator.NOT_EQUALS, (value ? true : false));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      return new bool?(dataReader.GetBoolean(columnIndex));
    }

    public bool ValueOf(Record record)
    {
      var obj = record.GetValue(this);
      return null == obj ? false : (bool)obj;
    }

    public void SetValue(Record record, bool? value)
    {
      record.SetValue(this, value);
    }

    public void SetValue(Record record, bool value)
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
  }
}
