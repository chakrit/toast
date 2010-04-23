
using System;
using System.Diagnostics;
using System.Threading;

namespace Toast
{
  internal class Program
  {
    private static ToastApp _app;


    public static void Main(string[] args)
    {
      var listener = new TextWriterTraceListener(Console.Out);
      Trace.Listeners.Add(listener);

      launchApp();
    }


    private static void onRestart(object sender, EventArgs e)
    {
      // executes this code in a foreground thread to prevent the app from
      // terminating when _app.Stop() because this event *will* be invoked
      // from a background thread... thus calling _app.Stop() will results
      // in app termination
      var thread = new Thread(() =>
      {
        _app.Events.RestartRequested -= onRestart;
        _app.Stop();
        _app.Dispose();
        _app = null;

        launchApp();
      });

      thread.IsBackground = false;
      thread.Start();
    }

    private static void launchApp()
    {
      var settings = ToastSettings.LoadDefault();
      _app = new ToastApp(settings);

      _app.Events.RestartRequested += onRestart;
      _app.Start();
    }
  }
}
