using CooQ.Types;
using System;
using System.ComponentModel;
using System.Data;

namespace CooQ.Conditions
{
  /// <summary>
  /// Condition. Used to create query conditions. e.g. fieldA &gt; 0 and fieldB &gt; 0
  /// 
  /// </summary>
  public abstract class Condition
  {
    private readonly object left;
    private readonly Operator op;
    private readonly object right;
    private readonly DbType rightDbType;

    internal object Left
    {
      get
      {
        return this.left;
      }
    }

    internal Operator Operator
    {
      get
      {
        return this.op;
      }
    }

    internal object Right
    {
      get
      {
        return this.right;
      }
    }

    internal DbType RightDbType
    {
      get
      {
        return this.rightDbType;
      }
    }

    internal Condition(object pLeft, Operator dbOperator, object pRight)
    {
      this.left = pLeft;
      this.op = dbOperator;
      this.right = pRight;
      if (!(pLeft is ColumnBase) || (pRight is ColumnBase || pRight is Condition))
        return;
      this.rightDbType = ((ColumnBase)this.left).DbType;
    }

    /// <summary>
    /// AND condition operator
    /// 
    /// </summary>
    /// <param name="conditionA"/><param name="conditionB"/>
    /// <returns/>
    public static Condition operator &(Condition conditionA, Condition conditionB)
    {
      return (Condition) new AndCondition(conditionA, conditionB);
    }

    /// <summary>
    /// OR condition operator
    /// 
    /// </summary>
    /// <param name="conditionA"/><param name="conditionB"/>
    /// <returns/>
    public static Condition operator |(Condition conditionA, Condition conditionB)
    {
      return (Condition) new OrCondition(conditionA, conditionB);
    }

    /// <summary>
    /// AND condition operator. Can also use the C# operator &amp;
    /// 
    /// </summary>
    /// <param name="conditionB"/>
    /// <returns/>
    public Condition And(Condition conditionB)
    {
      return (Condition) new AndCondition(this, conditionB);
    }

    /// <summary>
    /// AND condition operator.
    /// 
    /// </summary>
    /// <param name="conditionB"/>
    /// <returns/>
    public static Condition And(Condition conditionA, Condition conditionB)
    {
      if (conditionA != null)
        return (Condition) new AndCondition(conditionA, conditionB);
      return conditionB;
    }

    /// <summary>
    /// OR condition operator. Can also use the C# operator '|'.
    /// 
    /// </summary>
    /// <param name="conditionB"/>
    /// <returns/>
    public Condition Or(Condition conditionB)
    {
      return (Condition) new OrCondition(this, conditionB);
    }

    /// <summary>
    /// OR condition operator.
    /// 
    /// </summary>
    /// <param name="conditionB"/>
    /// <returns/>
    public static Condition Or(Condition conditionA, Condition conditionB)
    {
      if (conditionA != null)
        return (Condition) new OrCondition(conditionA, conditionB);
      return conditionB;
    }

    /// <summary>
    /// AND condition operator. The parameter pIncludeCondition determines if this condition is actually used.
    ///             This method if useful for creating dynamic conditions without the need of an 'if' statement.
    /// 
    /// </summary>
    /// <param name="pIncludeCondition">AND condition is only used if true.</param><param name="conditionB"/>
    /// <returns/>
    public Condition AndIf(bool pIncludeCondition, Condition conditionB)
    {
      return pIncludeCondition ? (Condition) new AndCondition(this, conditionB) : this;
    }

    /// <summary>
    /// OR condition operator. The parameter pIncludeCondition determines if this condition is actually used.
    ///             This method if useful for creating dynamic conditions without the need of an 'if' statement.
    /// 
    /// </summary>
    /// <param name="pIncludeCondition">AND condition is only used if true.</param><param name="conditionB"/>
    /// <returns/>
    public Condition OrIf(bool pIncludeCondition, Condition conditionB)
    {
      return pIncludeCondition ? (Condition) new OrCondition(this, conditionB) : this;
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

    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Type GetType()
    {
      return base.GetType();
    }
  }
}
