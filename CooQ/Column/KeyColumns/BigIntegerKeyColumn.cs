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
  /// <summary>
  /// Big Integer Column
  ///             This column maps to 8 byte integer fields, Int64, Long, Int8
  /// 
  /// </summary>
  public class BigIntegerKeyColumn<TABLE> : NumericColumnBase where TABLE : TableBase
  {
    public override DbType DbType
    {
      get
      {
        return DbType.Int64;
      }
    }

    public BigIntegerKeyColumn(TableBase table, string columnName)
      : base(table, columnName, false)
    {
    }

    public BigIntegerKeyColumn(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }

    public BigIntegerKeyColumn(TableBase table, string columnName, bool isPrimaryKey, bool isAutoId)
      : base(table, columnName, isPrimaryKey)
    {
      this.IsAutoId = isAutoId;
    }

    public static Condition operator ==(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.EQUALS, (ColumnBase) columnB);
    }

    public static Condition operator ==(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.EQUALS, (ColumnBase) columnB);
    }

    public static Condition operator ==(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.EQUALS, value);
    }

    public static Condition operator !=(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.NOT_EQUALS, (ColumnBase) columnB);
    }

    public static Condition operator !=(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.NOT_EQUALS, (ColumnBase) columnB);
    }

    public static Condition operator !=(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator >(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.GREATER_THAN, (ColumnBase) columnB);
    }

    public static Condition operator >(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.GREATER_THAN, (ColumnBase) columnB);
    }

    public static Condition operator >(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >=(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.GREATER_THAN_OR_EQUAL, (ColumnBase) columnB);
    }

    public static Condition operator >=(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.GREATER_THAN_OR_EQUAL, (ColumnBase) columnB);
    }

    public static Condition operator >=(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator <(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.LESS_THAN, (ColumnBase) columnB);
    }

    public static Condition operator <(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.LESS_THAN, (ColumnBase) columnB);
    }

    public static Condition operator <(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <=(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.LESS_THAN_OR_EQUAL, (ColumnBase) columnB);
    }

    public static Condition operator <=(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.LESS_THAN_OR_EQUAL, (ColumnBase) columnB);
    }

    public static Condition operator <=(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return (Condition) new ColumnCondition((ColumnBase) columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator +(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator +(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.ADD, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator +(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.ADD, value);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator -(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator -(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.SUBTRACT, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator -(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.SUBTRACT, value);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator /(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator /(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.DIVIDE, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator /(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.DIVIDE, value);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator *(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator *(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.MULTIPLY, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator *(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.MULTIPLY, value);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator %(BigIntegerKeyColumn<TABLE> columnA, BigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator %(BigIntegerKeyColumn<TABLE> columnA, NBigIntegerKeyColumn<TABLE> columnB)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.MODULO, columnB);
    }

    public static NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long> operator %(BigIntegerKeyColumn<TABLE> columnA, long value)
    {
      return new NumericCondition<BigIntegerKeyColumn<TABLE>, NBigIntegerKeyColumn<TABLE>, long>(columnA, NumericOperator.MODULO, value);
    }

    public Condition In(IList<long> pIntegerList)
    {
      return (Condition) new InCondition<long>((ColumnBase) this, pIntegerList);
    }

    public Condition NotIn(IList<long> pIntegerList)
    {
      return (Condition) new NotInCondition<long>((ColumnBase) this, pIntegerList);
    }

    public Condition In(IExecute pNestedQuery)
    {
      return (Condition) new NestedQueryCondition((ColumnBase) this, Operator.IN, pNestedQuery);
    }

    public Condition NotIn(IExecute pNestedQuery)
    {
      return (Condition) new NestedQueryCondition((ColumnBase) this, Operator.NOT_IN, pNestedQuery);
    }

    public Condition In(params long[] values)
    {
      return (Condition) new InCondition<long>((ColumnBase) this, values);
    }

    public Condition NotIn(params long[] values)
    {
      return (Condition) new NotInCondition<long>((ColumnBase) this, values);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override object GetValue(DatabaseBase database, DbDataReader pReader, int columnIndex)
    {
      long num;
      if (this.IsAutoId)
      {
        object obj = pReader.GetValue(columnIndex);
        num = !(obj is Decimal) ? (long) obj : (long) ((Decimal) obj);
      }
      else
        num = pReader.GetInt64(columnIndex);
      return num;
    }

    public long ValueOf(Record pRow)
    {
      return (long) pRow.GetValue((ColumnBase) this);
    }

    public void SetValue(Record pRow, long value)
    {
      pRow.SetValue((ColumnBase) this, value);
    }
                           
    public override object GetDefaultType()
    {
      return 0;
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
    public override string ToString()
    {
      return base.ToString();
    }
  }
}
