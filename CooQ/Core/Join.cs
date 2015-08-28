using CooQ;
using CooQ.Conditions;
using CooQ.Types;

namespace CooQ.Core
{
  internal class Join
  {
    private readonly JoinType mJoinType;
    private readonly TableBase mTable;
    private readonly Condition mCondition;
    private readonly string[] mHints;

    internal JoinType JoinType
    {
      get
      {
        return this.mJoinType;
      }
    }

    internal TableBase Table
    {
      get
      {
        return this.mTable;
      }
    }

    internal Condition Condition
    {
      get
      {
        return this.mCondition;
      }
    }

    internal string[] Hints
    {
      get
      {
        return this.mHints;
      }
    }

    internal Join(JoinType pJoinType, TableBase table, Condition condition, string[] hints)
    {
      this.mJoinType = pJoinType;
      this.mTable = table;
      this.mCondition = condition;
      this.mHints = hints != null ? hints : new string[0];
    }
  }
}
