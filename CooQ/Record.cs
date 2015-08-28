using CooQ.Conditions;
using CooQ.CooqDataException;
using CooQ.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;

namespace CooQ
{
  using CooQ.Types;
  using CooQ.Interfaces;
  using System.Reflection;
  /// <summary>
  /// Abstract row
  /// 
  /// </summary>
  public abstract class Record
  {
    /// <summary>
    /// Place holder object used to indicate if a value has not been set or selected.
    /// 
    /// </summary>
    private static readonly Record.NotSet NOT_SET = new Record.NotSet();
    private bool mIsInit = false;
    private TableBase table;
    /// <summary>
    /// Holds the committed row data
    /// 
    /// </summary>
    private object[] rowData;
    /// <summary>
    /// Holds the current row data that is not yet committed to the database
    /// 
    /// </summary>
    private object[] mCurrentData;
    /// <summary>
    /// Holds the row data that has been updated to database but not yet committed.
    ///             This is used to help with commit and rollback actions.
    /// 
    /// </summary>
    private object[] mPersistedData;
    private Record.RowStateEnum mPreviousRowState;
    private Record.RowStateEnum mRowState;
    /// <summary>
    /// Stores the transaction used to call Update() row with. This is used for checked the row isn't being updated to different transactions e.t.c.
    /// 
    /// </summary>
    private Transaction mUpdateTransaction;

    protected virtual TableBase Table
    {
      get
      {
        return this.table;
      }
    }

    [Browsable(false)]
    public Record.RowStateEnum RowState
    {
      get
      {
        return this.mRowState;
      }
    }

    protected Record(TableBase table)
    {
      if (table == null)
        throw new CooqDataException.CooqPreconditionException("table cannot be null");
      this.table = table;
      this.mPreviousRowState = Record.RowStateEnum.AddPending;
      this.mRowState = Record.RowStateEnum.AddPending;
    }

    /// <summary>
    /// Initialises row data. This is called either when the row is loaded from a select query or when a property is accessed on a new row.
    /// 
    /// </summary>
    private void Init()
    {
      if (this.mIsInit)
        return;
      this.mIsInit = true;
      this.mPreviousRowState = Record.RowStateEnum.AddPending;
      this.mRowState = Record.RowStateEnum.AddPending;
      this.rowData = new object[this.table.Columns.Count];
      this.mCurrentData = new object[this.table.Columns.Count];
      this.mPersistedData = new object[this.table.Columns.Count];
      int index = 0;
      while (index < this.table.Columns.Count)
      {
        this.mCurrentData[index] = Record.NOT_SET;
        this.mPersistedData[index] = Record.NOT_SET;
        checked { ++index; }
      }
    }

    /// <summary>
    /// Loads row from select query
    /// 
    /// </summary>
    /// <param name="table"/><param name="selectColumns"/><param name="reader"/>
    internal void LoadFromQuery(DatabaseBase database, TableBase table, IList<ISelectable> selectColumns, DbDataReader reader)
    {
      if (database == null)
        throw new NullReferenceException("database cannot be null");
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (this.mIsInit)
        throw new Exception("Row is already initialised");
      this.mIsInit = true;
      this.table = table;
      this.rowData = new object[this.table.Columns.Count];
      this.mCurrentData = new object[this.table.Columns.Count];
      this.mPersistedData = new object[this.table.Columns.Count];
      int index = 0;
      while (index < this.table.Columns.Count)
      {
        ColumnBase ColumnBase = this.table.Columns[index];
        int num = selectColumns.IndexOf((ISelectable)ColumnBase);
        this.rowData[index] = num == -1 ? Record.NOT_SET : (!reader.IsDBNull(num) ? ColumnBase.GetValue(database, reader, num) : null);
        this.mCurrentData[index] = this.rowData[index];
        this.mPersistedData[index] = Record.NOT_SET;
        checked { ++index; }
      }
      this.mPreviousRowState = Record.RowStateEnum.Exists;
      this.mRowState = Record.RowStateEnum.Exists;
    }

    /// <summary>
    /// Returns true if all the columns selected on this row returned null when loaded from the database. This is used to determine if a row returned null from a left join.
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public bool IsRowNull()
    {
      bool flag = true;
      int index = 0;
      while (index < this.table.Columns.Count)
      {
        object obj = this.rowData[index];
        if (obj != Record.NOT_SET && obj != null)
        {
          flag = false;
          break;
        }
        checked { ++index; }
      }
      return flag;
    }

    /// <summary>
    /// Returns value of column in this row.
    /// 
    /// </summary>
    /// <param name="column"/>
    /// <returns/>
    public object GetValue(ColumnBase column)
    {
      if (!this.mIsInit)
        this.Init();
      int index = this.table.Columns.IndexOf(column);
      if (index == -1)
        throw new CooqDataAccessException("Column does not exist in table class. Table: " + this.table.TableName + ", column name: " + column.ColumnName);
      object obj = this.mCurrentData[index];
      if (obj == Record.NOT_SET)
      {
        if (column.IsAutoId)
        {
          if (this.mRowState == Record.RowStateEnum.AddPending)
            throw new CooqDataAccessException("Auto id on column '" + column.ColumnName + "' has not been set. Row probably hasn't been persisted to database");
          throw new CooqDataAccessException("Column '" + column.ColumnName + "' is not set on row. This probably means it was not used in the select query");
        }
        if (this.mRowState != Record.RowStateEnum.AddPending)
          throw new CooqDataAccessException("Column '" + column.ColumnName + "' is not set on row. This probably means it was not used in the select query");
        obj = column.GetDefaultType();
      }
      if (this.mRowState == Record.RowStateEnum.DeletePending || this.mRowState == Record.RowStateEnum.DeletePerformedNotYetCommitted)
        throw new CooqDataAccessException("Cannot access a columns data when is deleted");
      return obj;
    }

    public object GetValue(CooQ.ColumnBase column, CooQ.Record record)
    {
      return record.GetValue(column);
    }
  
    /// <summary>
    /// Sets column value on row.
    /// 
    /// </summary>
    /// <param name="column"/><param name="value"/>
    internal void SetValue(ColumnBase column, object value)
    {
      if (!this.mIsInit)
        this.Init();
      int index = this.table.Columns.IndexOf(column);
      if (index == -1)
        throw new CooqDataAccessException("Column does not exist in table class. Table: " + this.table.TableName + ", column name: " + column.ColumnName);
      if (this.mRowState == Record.RowStateEnum.DeletePending || this.mRowState == Record.RowStateEnum.DeletePerformedNotYetCommitted || this.mRowState == Record.RowStateEnum.DeletedAndCommitted)
        throw new CooqDataAccessException("Cannot set columns data when row is deleted");
      this.mCurrentData[index] = value;
    }

    /// <summary>
    /// Flags row to be deleted from database. Row is deleted from database when the Update(...) method is called.
    /// 
    /// </summary>
    public void Delete()
    {
      if (this.mRowState == Record.RowStateEnum.AddPerformedNotYetCommitted)
        throw new CooqDataAccessException("You cannot delete a row that has been inserted but not yet committed");
      if (this.mRowState == Record.RowStateEnum.DeletePending || this.mRowState == Record.RowStateEnum.DeletePerformedNotYetCommitted || this.mRowState == Record.RowStateEnum.DeletedAndCommitted)
        return;
      if (this.mRowState == Record.RowStateEnum.AddPending)
        this.mRowState = Record.RowStateEnum.DeletedAndCommitted;
      else
        this.mRowState = Record.RowStateEnum.DeletePending;
    }

    /// <summary>
    /// Updates row changes to database. Adds new rows, updates existing rows with changes and deletes rows that are marked to be deleted.
    ///             If row has any auto id columns defined those values are loaded from database after an insert.
    ///             When updating rows there are two ways that the row is identified. The first is using the concurrency setting on the table or the global setting 'Settings.UseConcurrenyChecking'. (Note the table overrides the global setting).
    ///             When this is ture the row is found by comparing all column values. If the row can't be found (i.e. Another process has altered the row) then a concurreny exception is thrown.
    ///             If Settings.UseConcurrenyChecking == false then the row is found by looking up primary key values. If the row doesn't have a primary key defined an exception is thrown.
    /// 
    /// </summary>
    /// <param name="transaction"/>
    public void Update(Transaction transaction)
    {
      this.Update(transaction, false);
    }

    /// <summary>
    /// Updates row changes to database. Adds new rows, updates existing rows with changes and deletes rows that are marked to be deleted.
    ///             If row has any auto id columns defined those values are loaded from database after an insert.
    ///             When updating rows there are two ways that the row is identified. The first is using the concurrency setting on the table or the global setting 'Settings.UseConcurrenyChecking'. (Note the table overrides the global setting).
    ///             When this is ture the row is found by comparing all column values. If the row can't be found (i.e. Another process has altered the row) then a concurreny exception is thrown.
    ///             If Settings.UseConcurrenyChecking == false then the row is found by looking up primary key values. If the row doesn't have a primary key defined an exception is thrown.
    /// 
    /// </summary>
    /// <param name="transaction"/><param name="discardRowAfterUpdate">If true the row is not updated internally when transaction is committed / rolled back.</param>
    public void Update(Transaction transaction, bool discardRowAfterUpdate)
    {
      if (transaction == null)
        throw new CooqPreconditionException("transaction cannot be null");
      if (this.mRowState == Record.RowStateEnum.DeletedAndCommitted)
        throw new CooqPreconditionException("Row doesn't exist in database. You cannot call update on row that doesn't exist in the database.");
      if (this.mRowState == Record.RowStateEnum.DeletePerformedNotYetCommitted)
        throw new CooqPreconditionException("Row has already been deleted from the database and is waiting for transaction to be committed. You cannot update a deleted row more than once within a transaction.");
      if (this.mRowState == Record.RowStateEnum.AddPerformedNotYetCommitted)
        throw new CooqPreconditionException("Cannot call Update(...) more than once on a row within the same trasaction");
      if (!this.mIsInit)
        this.Init();
      if (this.mUpdateTransaction == null)
      {
        this.mUpdateTransaction = transaction;
        if (!discardRowAfterUpdate)
        {
          transaction.CommitEvent += new Transaction.CommitPerformed(this.Transaction_CommitEvent);
          transaction.RollbackEvent += new Transaction.RollbackPerformed(this.Transaction_RollbackEvent);
        }
      }
      else if (this.mUpdateTransaction != transaction)
        throw new CooqDataAccessException("row.Update() has been called more than once on this row with a different transaction instance than before.");
      if (this.table.Columns.Count == 0)
        throw new CooqDataAccessException("Table has no fields defined. Cannot update row.");
      if (this.mRowState == Record.RowStateEnum.AddPending)
      {
        InsertBuilder insertBuilder = new InsertBuilder(this.table);
        List<ColumnBase> list = new List<ColumnBase>();
        int index1 = 0;
        while (index1 < this.table.Columns.Count)
        {
          ColumnBase column = this.table.Columns[index1];
          if (column.IsAutoId)
          {
            list.Add(column);
          }
          else
          {
            object value = this.mCurrentData[index1];
            if (value == Record.NOT_SET)
              value = (object)null;
            insertBuilder.SetInternal(column, value);
            this.mPersistedData[index1] = value;
          }
          checked { ++index1; }
        }
        if (list.Count == 0)
        {
          insertBuilder.Execute(transaction);
        }
        else
        {
          IResult result = insertBuilder.Returning(list.ToArray()).Execute(transaction);
          if (list.Count > 1)
            throw new CooqDataAccessException("Only one auto id field is supported");
          int index2 = 0;
          while (index2 < list.Count)
          {
            ColumnBase column = list[index2];
            int index3 = this.table.Columns.IndexOf(column);
            this.mCurrentData[index3] = result.GetRow(column.Table, 0).GetValue(column);
            this.mPersistedData[index3] = this.mCurrentData[index3];
            checked { ++index2; }
          }
        }
        this.mRowState = Record.RowStateEnum.AddPerformedNotYetCommitted;
      }
      else if (this.mRowState == Record.RowStateEnum.DeletePending)
      {
        DeleteBuilder deleteBuilder = new DeleteBuilder(this.table);
        Condition condition = null;
        bool? concurrenyChecking = this.table.UseConcurrenyChecking;
        int num;
        if (!concurrenyChecking.HasValue)
        {
          num = Settings.UseConcurrenyChecking ? 1 : 0;
        }
        else
        {
          concurrenyChecking = this.table.UseConcurrenyChecking;
          num = concurrenyChecking.Value ? 1 : 0;
        }
        bool flag1 = num != 0;
        bool flag2 = false;
        int index = 0;
        while (index < this.table.Columns.Count)
        {
          ColumnBase pLeft = this.table.Columns[index];
          if (flag1 || pLeft.IsPrimaryKey)
          {
            flag2 = true;
            object pRight = this.mPersistedData[index];
            if (pRight == Record.NOT_SET)
              pRight = this.rowData[index];
            if (condition == null)
              condition = pRight != Record.NOT_SET ? (Condition)new ColumnCondition(pLeft, Operator.EQUALS, pRight) : (Condition)new IsNullCondition((ISelectable)pLeft);
            else
              condition &= pRight != Record.NOT_SET ? (Condition)new ColumnCondition(pLeft, Operator.EQUALS, pRight) : (Condition)new IsNullCondition((ISelectable)pLeft);
          }
          checked { ++index; }
        }
        if (!flag2)
          throw new CooqDataAccessException("There are no primary keys set on row and use concurrency checking is turned off. Unable to delete.");
        deleteBuilder.Where(condition);
        if (deleteBuilder.Execute(transaction).RowsEffected != 1)
          throw new CooqDataAccessException("Row not updated. Possible data concurrency issue.");
        this.mRowState = Record.RowStateEnum.DeletePerformedNotYetCommitted;
      }
      else
      {
        bool flag1 = false;
        int index1 = 0;
        while (index1 < this.rowData.Length)
        {
          if (this.rowData[index1] is Record.NotSet)
            throw new CooqDataAccessException("Not all columns were loaded in row. Unable to update.");
          if ((this.mPersistedData[index1] != null || this.mCurrentData[index1] != null) && (this.mPersistedData[index1] == null && this.mCurrentData[index1] != null || this.mPersistedData[index1] != null && this.mCurrentData[index1] == null || !this.mPersistedData[index1].Equals(this.mCurrentData[index1])))
          {
            flag1 = true;
            break;
          }
          checked { ++index1; }
        }
        if (flag1)
        {
          UpdateBuilder updateBuilder = new UpdateBuilder(this.table);
          Condition condition = null;
          bool? concurrenyChecking = this.table.UseConcurrenyChecking;
          int num;
          if (!concurrenyChecking.HasValue)
          {
            num = Settings.UseConcurrenyChecking ? 1 : 0;
          }
          else
          {
            concurrenyChecking = this.table.UseConcurrenyChecking;
            num = concurrenyChecking.Value ? 1 : 0;
          }
          bool flag2 = num != 0;
          bool flag3 = false;
          int index2 = 0;
          while (index2 < this.table.Columns.Count)
          {
            ColumnBase ColumnBase = this.table.Columns[index2];
            if (!ColumnBase.IsAutoId && this.mPersistedData[index2] != this.mCurrentData[index2])
              updateBuilder.SetInternal(ColumnBase, this.mCurrentData[index2]);
            if (flag2 || ColumnBase.IsPrimaryKey)
            {
              flag3 = true;
              object pRight = this.mPersistedData[index2];
              if (pRight == Record.NOT_SET)
                pRight = this.rowData[index2];
              if (condition == null)
                condition = pRight != null ? new ColumnCondition(ColumnBase, Operator.EQUALS, pRight) : (Condition)new IsNullCondition((ISelectable)ColumnBase);
              else
                condition &= pRight != null ? new ColumnCondition(ColumnBase, Operator.EQUALS, pRight) : (Condition)new IsNullCondition((ISelectable)ColumnBase);
            }
            this.mPersistedData[index2] = this.mCurrentData[index2];
            checked { ++index2; }
          }
          if (!flag3)
            throw new CooqDataAccessException("There are no primary keys set on row and use concurrency checking is turned off. Unable to update.");
          updateBuilder.Where(condition);
          if (updateBuilder.Execute(transaction).RowsEffected != 1)
            throw new CooqDataAccessException("Row not updated. Possible data concurrency issue.");
        }
      }
    }

    /// <summary>
    /// Called when transaction is committed.
    /// 
    /// </summary>
    private void Transaction_CommitEvent()
    {
      this.mUpdateTransaction = (Transaction)null;
      if (this.mRowState == Record.RowStateEnum.AddPending || this.mRowState == Record.RowStateEnum.DeletePending)
        throw new CooqDataAccessException("Unexpected state. Row State must not be AddPending or DeletePending during a transaction commit. mRowState = '" + this.mRowState.ToString() + "'");
      if (this.mRowState == Record.RowStateEnum.DeletePerformedNotYetCommitted || this.mRowState == Record.RowStateEnum.DeletedAndCommitted)
      {
        this.rowData = (object[])null;
        this.mCurrentData = (object[])null;
        this.mPersistedData = (object[])null;
        this.mPreviousRowState = Record.RowStateEnum.DeletedAndCommitted;
        this.mRowState = Record.RowStateEnum.DeletedAndCommitted;
      }
      else
      {
        int index = 0;
        while (index < this.rowData.Length)
        {
          this.rowData[index] = this.mPersistedData[index];
          if (this.mCurrentData[index] == Record.NOT_SET)
            this.mCurrentData[index] = (object)null;
          this.mPersistedData[index] = (object)null;
          checked { ++index; }
        }
        this.mPreviousRowState = Record.RowStateEnum.Exists;
        this.mRowState = Record.RowStateEnum.Exists;
      }
    }

    /// <summary>
    /// Called when transaction is rolled back.
    /// 
    /// </summary>
    private void Transaction_RollbackEvent()
    {
      this.mUpdateTransaction = (Transaction)null;
      int index = 0;
      while (index < this.table.Columns.Count)
      {
        if (this.mPreviousRowState == Record.RowStateEnum.AddPending && this.table.Columns[index].IsAutoId)
          this.mCurrentData[index] = (object)Record.NOT_SET;
        this.mPersistedData[index] = (object)Record.NOT_SET;
        checked { ++index; }
      }
      if (this.mRowState == Record.RowStateEnum.AddPerformedNotYetCommitted)
      {
        this.mRowState = Record.RowStateEnum.AddPending;
      }
      else
      {
        if (this.mRowState != Record.RowStateEnum.DeletePerformedNotYetCommitted)
          throw new CooqDataAccessException("Unexpected Row State. mRowState = '" + this.mRowState.ToString() + "'");
        if (this.mPreviousRowState == Record.RowStateEnum.AddPending)
          this.mRowState = Record.RowStateEnum.DeletedAndCommitted;
        else
          this.mRowState = Record.RowStateEnum.DeletePending;
      }
    }

    /// <summary>
    /// Returns the rows data size from the original (Last committed) data size. (Not the changed data size).
    /// 
    /// </summary>
    /// 
    /// <returns/>
    internal int GetOrigRowDataSizeInBytes()
    {
      int num = 0;
      int index = 0;
      while (index < this.rowData.Length)
      {
        object pObject = this.rowData[index];
        if (pObject != null && pObject != Record.NOT_SET)
          checked { num += SqlHelper.GetAproxByteSizeOf(pObject); }
        checked { ++index; }
      }
      return num;
    }                            

    /// <summary>
    /// Place holder class
    /// 
    /// </summary>
    private class NotSet
    {
    }

    public enum RowStateEnum
    {
      Exists,
      AddPending,
      AddPerformedNotYetCommitted,
      DeletePending,
      DeletePerformedNotYetCommitted,
      DeletedAndCommitted,
    }                    
  }
}
