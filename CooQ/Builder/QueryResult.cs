using CooQ;
using CooQ.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
namespace CooQ.Builder
{
  internal class QueryResult : IResult
  {
    private readonly IDictionary<TableBase, IList<Record>> mTableRows = new Dictionary<TableBase, IList<Record>>();
    private readonly IDictionary<ISelectable, IList<object>> mFunctionValues = new Dictionary<ISelectable, IList<object>>();
    private readonly int mRows;
    private readonly string mSqlQuery;

    public int RowsEffected { get; private set; }

    public int Count
    {
      get
      {
        return this.mRows;
      }
    }

    public string SqlQuery
    {
      get
      {
        return this.mSqlQuery;
      }
    }

    internal QueryResult(int recordsEffected, string pSqlQuery)
    {
      this.RowsEffected = recordsEffected;
      this.mSqlQuery = !string.IsNullOrEmpty(pSqlQuery) ? pSqlQuery : string.Empty;
    }

    internal QueryResult(DatabaseBase database, IList<ISelectable> pSelectColumns, DbDataReader dataReader, string pSqlQuery)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      this.mSqlQuery = pSqlQuery ?? string.Empty;
      var list1 = new List<TableBase>();
      var list2 = new List<ISelectable>();
      int index1 = 0;
      while (index1 < pSelectColumns.Count)
      {
        ISelectable selectable = pSelectColumns[index1];
        if (selectable is ColumnBase)
        {
          TableBase table = ((ColumnBase)selectable).Table;
          if (!list1.Contains(table))
            list1.Add(table);
        }
        else if (!list2.Contains(selectable))
          list2.Add(selectable);
        checked { ++index1; }
      }
      while (dataReader.Read())
      {
        int index2 = 0;
        while (index2 < list1.Count)
        {
          TableBase index3 = list1[index2];
          IList<Record> list3;
          if (!this.mTableRows.ContainsKey(index3))
          {
            list3 = new List<Record>();
            this.mTableRows.Add(index3, list3);
          }
          else
            list3 = this.mTableRows[index3];
          var arow = (Record)index3.RowType.GetConstructor(new Type[0]).Invoke((object[])null);
          arow.LoadFromQuery(database, index3, pSelectColumns, dataReader);
          list3.Add(arow);
          checked { ++index2; }
        }
        int index4 = 0;
        while (index4 < list2.Count)
        {
          ISelectable key = list2[index4];
          IList<object> list3;
          if (!this.mFunctionValues.ContainsKey(key))
          {
            list3 = (IList<object>)new List<object>();
            this.mFunctionValues.Add(key, list3);
          }
          else
            list3 = this.mFunctionValues[key];
          list3.Add(key.GetValue(database, dataReader, pSelectColumns.IndexOf(key)));
          checked { ++index4; }
        }
        checked { ++this.mRows; }
      }
      this.RowsEffected = this.mRows;
    }

    public Record GetRow(TableBase table, int pIndex)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (pIndex < 0)
        throw new IndexOutOfRangeException("pIndex must >= 0. pIndex == " + pIndex.ToString());
      if (!this.mTableRows.ContainsKey(table))
        throw new Exception("Table instance of type '" + table.GetType() + "' does not exist in result. Check that is was included in select portion of query");
      return this.mTableRows[table][pIndex];
    }

    public object GetValue(ISelectable pFunction, int pIndex)
    {
      if (pFunction == null)
        throw new NullReferenceException("pFunction cannot be null");
      if (pIndex < 0)
        throw new IndexOutOfRangeException("pIndex must >= 0. pIndex == " + pIndex.ToString());
      return this.mFunctionValues[pFunction][pIndex];
    }

    public int GetDataSetSizeInBytes()
    {
      int num = 0;
      foreach (TableBase index in (IEnumerable<TableBase>)this.mTableRows.Keys)
      {
        foreach (Record arow in (IEnumerable<Record>)this.mTableRows[index])
          checked { num += arow.GetOrigRowDataSizeInBytes(); }
      }
      foreach (ISelectable index in (IEnumerable<ISelectable>)this.mFunctionValues.Keys)
      {
        foreach (object pObject in (IEnumerable<object>)this.mFunctionValues[index])
          checked { num += SqlHelper.GetAproxByteSizeOf(pObject); }
      }
      return num;
    }

    public IQueryable<Record> GetRows(TableBase table)
    {
      if (this.mTableRows.Count <= 0)
        return default(IQueryable<Record>);
      if (!this.mTableRows.ContainsKey(table))
        throw new Exception("Table instance of type '" + table.GetType() + "' does not exist in result. Check that is was included in select portion of query");
      return mTableRows[table].AsQueryable<Record>();
    }

    public IQueryable<Record> GetRows()
    {
      if (this.mTableRows.Count <= 0)
        return default(IQueryable<Record>);
      return mTableRows.FirstOrDefault().Value.AsQueryable();
    }                             
  }
}

