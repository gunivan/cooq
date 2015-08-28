using CooQ;
using CooQ.Conditions;
using CooQ.Types;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace CooQ.Column
{
  /// <summary>
  /// Boolean column
  /// 
  /// </summary>
  public class BoolColumn : ColumnBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Boolean;
      }
    }

    public BoolColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public BoolColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public static Condition operator ==(BoolColumn columnA, BoolColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(BoolColumn columnA, NBoolColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator ==(BoolColumn columnA, bool value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.EQUALS, (value ? true : false));
    }

    public static Condition operator !=(BoolColumn columnA, BoolColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(BoolColumn columnA, NBoolColumn columnB)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator !=(BoolColumn columnA, bool value)
    {
      return (Condition) new ColumnCondition(columnA, Operator.NOT_EQUALS, (value ? true : false));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      return (dataReader.GetBoolean(columnIndex) ? true : false);
    }

    public bool ValueOf(Record record)
    {
      return (bool) record.GetValue(this);
    }

    public void SetValue(Record record, bool value)
    {
      record.SetValue(this, (value ? true : false));
    }

    public bool GetValue(DataRow row)
    {
      return base.As<bool>(row);
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
      return false;
    }
  }
}
