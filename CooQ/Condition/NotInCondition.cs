using CooQ.Interfaces;
using CooQ.Types;
using System;
using System.Collections.Generic;

namespace CooQ.Conditions
{
  public class NotInCondition<T> : Condition
  {
    internal NotInCondition(ColumnBase pLeft, IList<T> list)
      : base(pLeft, Operator.NOT_IN, list)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (list == null)
        throw new NullReferenceException("list cannot be null");
      if (list.Count == 0)
        throw new Exception("list cannot be empty");
      foreach (T obj in (IEnumerable<T>) list)
      {
        if (obj == null)
          throw new NullReferenceException("A value in list is null. This is not allowed.");
      }
    }

    internal NotInCondition(ColumnBase pLeft, T[] list)
      : base(pLeft, Operator.NOT_IN, list)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (list == null)
        throw new NullReferenceException("list cannot be null");
      if (list.Length == 0)
        throw new Exception("list cannot be empty");
      foreach (T obj in list)
      {
        if (obj == null)
          throw new NullReferenceException("A value in list is null. This is not allowed.");
      }
    }

    internal NotInCondition(IFunction pLeft, IList<T> list)
      : base(pLeft, Operator.NOT_IN, list)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (list == null)
        throw new NullReferenceException("list cannot be null");
      if (list.Count == 0)
        throw new Exception("list cannot be empty");
      foreach (T obj in (IEnumerable<T>) list)
      {
        if (obj == null)
          throw new NullReferenceException("A value in list is null. This is not allowed.");
      }
    }

    internal NotInCondition(IFunction pLeft, T[] list)
      : base(pLeft, Operator.NOT_IN, list)
    {
      if (pLeft == null)
        throw new NullReferenceException("pLeft cannot be null");
      if (list == null)
        throw new NullReferenceException("list cannot be null");
      if (list.Length == 0)
        throw new Exception("list cannot be empty");
      foreach (T obj in list)
      {
        if (obj == null)
          throw new NullReferenceException("A value in list is null. This is not allowed.");
      }
    }
  }
}
