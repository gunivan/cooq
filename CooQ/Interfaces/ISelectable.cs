using System;
using System.ComponentModel;
using System.Data.Common;

namespace CooQ.Interfaces
{
  public interface ISelectable
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    object GetValue(DatabaseBase database, DbDataReader dataReader, int columnIndex);                                                                                               
  }
}
