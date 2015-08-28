using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IInsertExecute
  {
    string GetSql();

    string GetSql(DatabaseBase database);

    IResult Execute();

    IResult Execute(Transaction transaction);
  }
}
