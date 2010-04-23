
using System;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Toast
{
  public partial class ToastSettings
  {
    public Version Version = Assembly.GetEntryAssembly().GetName().Version;

    public string Host = "localhost";
    public long Port = 80;

    public string DbConnectionString = "Data Source=ToastDb.sdf;Persist Security Info=False";

    public bool FirstRun = true;


#if DEBUG
    public bool DebugMode = true;
#else
    public bool DebugMode = false;
#endif
  }


  public partial class ToastSettings
  {
    public const string DefaultFilename = "settings.json";


    public void SaveTo(string filename)
    {
      var serializer = new JavaScriptSerializer();
      var result = serializer.Serialize(this);

      File.WriteAllText(filename, result);
    }

    public void SaveDefault()
    {
      SaveTo(DefaultFilename);
    }


    public static ToastSettings LoadFrom(string filename)
    {
      var serializer = new JavaScriptSerializer();
      var json = File.ReadAllText(filename);

      return serializer.Deserialize<ToastSettings>(json);
    }

    public static ToastSettings LoadDefault()
    {
      if (File.Exists(DefaultFilename))
        return LoadFrom(DefaultFilename);

      // create the file if it doesn't exists
      var settings = new ToastSettings();
      settings.SaveTo(DefaultFilename);

      return settings;
    }
  }
}
