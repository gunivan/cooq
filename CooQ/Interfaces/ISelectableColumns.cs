using System;
using System.ComponentModel;

namespace CooQ.Interfaces
{
  public interface ISelectableColumns
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    ISelectable[] SelectableColumns { get; }
  }
}
