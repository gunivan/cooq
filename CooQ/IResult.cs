using CooQ.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
namespace CooQ
{
  public interface IResult
  {
    /// <summary>
    /// Number of rows in query result
    /// 
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Number of rows effected by an insert, update or delete
    /// 
    /// </summary>
    int RowsEffected { get; }

    /// <summary>
    /// Query used to populate query result
    /// 
    /// </summary>
    string SqlQuery { get; }

    /// <summary>
    /// Returns row for table and pIndex
    /// 
    /// </summary>
    /// <param name="table"/><param name="pIndex"/>
    /// <returns/>
    Record GetRow(TableBase table, int pIndex);

    /// <summary>
    /// Returns collections record for table in result
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>                                  
    IQueryable<Record> GetRows(TableBase table);

    /// <summary>
    /// Return first table in result 
    /// </summary>
    /// <returns></returns>
    IQueryable<Record> GetRows();

    /// <summary>
    /// Gets function value
    /// 
    /// </summary>
    /// <param name="pFunction"/><param name="pIndex"/>
    /// <returns/>
    object GetValue(ISelectable pFunction, int pIndex);

    /// <summary>
    /// Gets result size in bytes. This is an aprox value.
    /// 
    /// </summary>
    /// 
    /// <returns/>
    int GetDataSetSizeInBytes();
  }
}
