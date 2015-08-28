using CooQ;
using CooQ.Column;
using CooQ.Conditions;
using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;

namespace CooQ.Function
{
  public abstract class DateTimeFunctionBase : IFunction, ISelectable, ISelectableColumns, IOrderByColumn
  {
    public ISelectable[] SelectableColumns
    {
      get
      {
        return new ISelectable[1]
        {
          (ISelectable) this
        };
      }
    }

    /// <summary>
    /// Order ascending
    /// 
    /// </summary>
    public OrderByColumn ASC
    {
      get
      {
        return new OrderByColumn((ISelectable) this, OrderByType.ASC);
      }
    }

    /// <summary>
    /// Order Descending
    /// 
    /// </summary>
    public OrderByColumn DESC
    {
      get
      {
        return new OrderByColumn((ISelectable) this, OrderByType.DESC);
      }
    }

    /// <summary>
    /// IS NULL sql condition
    /// 
    /// </summary>
    public Condition IsNull
    {
      get
      {
        return (Condition) new IsNullCondition((ISelectable) this);
      }
    }

    /// <summary>
    /// IS NOT NULL sql condition
    /// 
    /// </summary>
    public Condition IsNotNull
    {
      get
      {
        return (Condition) new IsNotNullCondition((ISelectable) this);
      }
    }

    /// <summary>
    /// Default ordering
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public OrderByColumn GetOrderByColumn
    {
      get
      {
        return new OrderByColumn((ISelectable) this, OrderByType.Default);
      }
    }

    public static Condition operator ==(DateTimeFunctionBase columnA, DateTime value)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.EQUALS, value);
    }

    public static Condition operator ==(DateTimeFunctionBase columnA, DateTimeFunctionBase columnB)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.EQUALS, columnB);
    }

    public static Condition operator !=(DateTimeFunctionBase columnA, DateTime value)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.NOT_EQUALS, value);
    }

    public static Condition operator !=(DateTimeFunctionBase columnA, DateTimeFunctionBase columnB)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.NOT_EQUALS, columnB);
    }

    public static Condition operator >(DateTimeFunctionBase columnA, DateTime value)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.GREATER_THAN, value);
    }

    public static Condition operator >(DateTimeFunctionBase columnA, DateTimeFunctionBase columnB)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.GREATER_THAN, columnB);
    }

    public static Condition operator >=(DateTimeFunctionBase columnA, DateTime value)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.GREATER_THAN_OR_EQUAL, value);
    }

    public static Condition operator >=(DateTimeFunctionBase columnA, DateTimeFunctionBase columnB)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.GREATER_THAN_OR_EQUAL, columnB);
    }

    public static Condition operator <(DateTimeFunctionBase columnA, DateTime value)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.LESS_THAN, value);
    }

    public static Condition operator <(DateTimeFunctionBase columnA, DateTimeFunctionBase columnB)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.LESS_THAN, columnB);
    }

    public static Condition operator <=(DateTimeFunctionBase columnA, DateTime value)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.LESS_THAN_OR_EQUAL, value);
    }

    public static Condition operator <=(DateTimeFunctionBase columnA, DateTimeFunctionBase columnB)
    {
      return (Condition) new ColumnCondition((IFunction) columnA, Operator.LESS_THAN_OR_EQUAL, columnB);
    }

    public Condition In(IList<DateTime> list)
    {
      return (Condition) new InCondition<DateTime>((IFunction) this, list);
    }

    public Condition NotIn(IList<DateTime> list)
    {
      return (Condition) new NotInCondition<DateTime>((IFunction) this, list);
    }

    public abstract string GetFunctionSql(DatabaseBase database, bool useAlias);

    public abstract object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex);

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }           
  }
}
