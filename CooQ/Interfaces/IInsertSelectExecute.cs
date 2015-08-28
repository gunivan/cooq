using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IInsertSelectExecute
  {
    string GetSql();

    string GetSql(DatabaseBase database);

    int Execute();

    int Execute(Transaction transaction);                                          
  }
}
