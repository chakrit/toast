
using System;
using System.Diagnostics;

namespace Toast
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var listener = new TextWriterTraceListener(Console.Out);
      Trace.Listeners.Add(listener);

      var settings = ToastSettings.LoadDefault();
      var app = new ToastApp(settings);

      app.Start();
    }
  }
}
