
using System;
using System.Data.Linq;
using System.Linq;

namespace Toast.Data
{
  public class DbManager : IDbManager
  {
    private ToastSettings _settings;


    public Version CurrentSchemaVersion
    {
      get { return Version.Parse("0.0.0.0"); }
    }


    public DbManager(ToastSettings settings)
    {
      _settings = settings;
    }


    public void CheckAndSetup()
    {
      // TODO: Check the schema version and call upgrade methods
      //       if necessary
      if (!DatabaseExists())
        CreateDatabase();
    }


    public Version GetDbSchemaVersion()
    {
      using (var ctx = NewContext()) {
        var versionKey = ctx
          .GetTable<Meta>()
          .FirstOrDefault(m => m.Key == "Version");

        if (versionKey == null)
          return Version.Parse("0.0.0.0");

        return Version.Parse(versionKey.Value);
      }
    }


    public bool DatabaseExists()
    {
      using (var ctx = NewContext())
        return ctx.DatabaseExists();
    }

    public void CreateDatabase()
    {
      // create a new database
      using (var ctx = NewContext())
        ctx.CreateDatabase();

      // saves version number
      using (var ctx = NewContext()) {
        var versionKey = new Meta {
          Key = "Version",
          Value = CurrentSchemaVersion.ToString()
        };

        ctx.GetTable<Meta>().InsertOnSubmit(versionKey);
        ctx.SubmitChanges();
      }
    }


    public DataContext NewContext()
    {
      return new ToastDb(_settings.DbConnectionString);
    }
  }
}
