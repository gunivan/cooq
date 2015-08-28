using CooQ;
using CooQ.Column;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Data.Common;

namespace CooQ.Function
{
  public sealed class DateFunction : NumericFunctionBase
  {
    private readonly ColumnBase mColumn;
    private readonly DatePart mDatePart;

    public int? this[int pIndex, IResult pResult]
    {
      get
      {
        return (int?) pResult.GetValue((ISelectable) this, pIndex);
      }
    }

    public DateFunction(DateTimeColumn column, DatePart pDatePart)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDatePart = pDatePart;
    }

    public DateFunction(NDateTimeColumn column, DatePart pDatePart)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDatePart = pDatePart;
    }

    public DateFunction(DateTime2Column column, DatePart pDatePart)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDatePart = pDatePart;
    }

    public DateFunction(NDateTime2Column column, DatePart pDatePart)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDatePart = pDatePart;
    }

    public DateFunction(DateTimeOffsetColumn column, DatePart pDatePart)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDatePart = pDatePart;
    }

    public DateFunction(NDateTimeOffsetColumn column, DatePart pDatePart)
    {
      if (object.Equals(null, column))
        throw new NullReferenceException("column cannot be null");
      this.mColumn = column;
      this.mDatePart = pDatePart;
    }

    public override string GetFunctionSql(DatabaseBase database, bool useAlias)
    {
      string str;
      if (database.DatabaseType == DatabaseType.MSSQL)
      {
        switch (this.mDatePart)
        {
          case DatePart.Year:
            str = "YEAR(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Month:
            str = "MONTH(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.DayOfMonth:
            str = "DAY(" + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Hour:
            str = "DATEPART(HOUR," + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Minute:
            str = "DATEPART(MINUTE," + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Second:
            str = "DATEPART(SECOND," + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          default:
            throw new Exception("Unknown date part value: '" + this.mDatePart.ToString() + "'");
        }
      }
      else
      {
        if (database.DatabaseType != DatabaseType.POSTGRESQL)
          throw new Exception("Unsupportted database type: '" + database.DatabaseType.ToString() + "'");
        switch (this.mDatePart)
        {
          case DatePart.Year:
            str = "EXTRACT(YEAR FROM " + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Month:
            str = "EXTRACT(MONTH FROM " + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.DayOfMonth:
            str = "EXTRACT(DAY FROM " + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Hour:
            str = "EXTRACT(HOUR FROM " + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Minute:
            str = "EXTRACT(MINUTE FROM " + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          case DatePart.Second:
            str = "EXTRACT(SECOND FROM " + (useAlias ? this.mColumn.Table.Alias + "." : string.Empty) + this.mColumn.ColumnName + ")";
            break;
          default:
            throw new Exception("Unknown date part value: '" + this.mDatePart.ToString() + "'");
        }
      }
      return str;
    }

    public override object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex)
    {
      if (dataReader.IsDBNull(columnIndex))
        return null;
      Type fieldType = dataReader.GetFieldType(columnIndex);
      if (fieldType == typeof (long))
        return new int?(Convert.ToInt32(dataReader.GetInt64(columnIndex)));
      if (fieldType == typeof (double))
        return new int?(checked ((int) dataReader.GetDouble(columnIndex)));
      return new int?(dataReader.GetInt32(columnIndex));
    }
  }
}
