
using System;
using System.Diagnostics;

namespace NToast
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var listener = new TextWriterTraceListener(Console.Out);
      Trace.Listeners.Add(listener);

      var settings = ToastSettings.LoadDefault();
      //var app = new NToastApp(settings);

      //app.Start();

      var dbMan = new NToast.Data.DbManager(settings);
      dbMan.CreateDatabase();
    }
  }
}
