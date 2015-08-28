// Decompiled with JetBrains decompiler
// Type: Sql.Interfaces.IUpdateWhere
// Assembly: TypedQuery, Version=1.0.4999.24676, Culture=neutral, PublicKeyToken=null
// MVID: 025C9535-2E94-487D-94AA-524728E5196C
// Assembly location: E:\hava\Typed Query v0.9.6\TypedQuery.dll

using CooQ;
using CooQ.Conditions;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IUpdateWhere
  {
    IUpdateUseParams NoWhereCondition();

    IUpdateUseParams Where(Condition condition);
  }
}
