
using System;
using System.Data.Linq;

namespace Toast.Data
{
  public interface IDbManager
  {
    Version CurrentSchemaVersion { get; }
    Version GetDbSchemaVersion();

    bool DatabaseExists();
    void CreateDatabase();

    DataContext NewContext();
  }
}
