namespace CooQ.Column
{
  /// <summary>
  /// Abstract numeric column
  ///             Used to idetify table columns that are numeric
  /// 
  /// </summary>
  public abstract class NumericColumnBase : ColumnBase
  {
    protected NumericColumnBase(TableBase table, string columnName, bool isPrimaryKey)
      : base(table, columnName, isPrimaryKey)
    {
    }
  }
}
