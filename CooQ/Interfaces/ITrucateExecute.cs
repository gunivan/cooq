using CooQ;

namespace CooQ.Interfaces
{
  public interface ITrucateExecute
  {
    string GetSql();

    string GetSql(DatabaseBase database);

    int Execute();

    int Execute(Transaction transaction);
  }
}
