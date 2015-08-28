using CooQ;
using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface IExecute
  {
    /// <summary>
    /// Rerurns query sql
    /// 
    /// </summary>
    /// 
    /// <returns/>                       
    string GetSql(DatabaseBase database);

    string GetSql();

    /// <summary>
    /// Executes query using default Isolation level
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IResult Execute(DatabaseBase database);

    /// <summary>
    /// Executes query using default Isolation level and the default database (Set on the queries 'FROM' table).
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IResult Execute();

    /// <summary>
    /// Executes query using read uncommited Isolation level
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IResult ExecuteUncommitted(DatabaseBase database);

    /// <summary>
    /// Executes query using read uncommited Isolation level and the default database (Set in the Settings class).
    /// 
    /// </summary>
    /// 
    /// <returns/>
    IResult ExecuteUncommitted();

    /// <summary>
    /// Executes query using transaction provided
    /// 
    /// </summary>
    /// <param name="transaction"/>
    /// <returns/>
    IResult Execute(Transaction transaction);                                                                        
  }
}
