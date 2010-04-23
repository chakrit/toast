
using System;

using Autofac;

using Fu;

using Toast.Web;
using Toast.Data;

namespace Toast
{
  public class ToastApp : IDisposable
  {
    private ToastSettings _settings;
    private ToastEvents _events;

    private IContainer _container;
    private IApp _fuApp;


    public ToastEvents Events { get { return _events; } }

    public ToastApp(ToastSettings settings)
    {
      _settings = settings;
      _container = buildContainer();
      _events = _container.Resolve<ToastEvents>();
    }


    public void Start()
    {
      // start the web application
      _fuApp = _fuApp ?? _container.Resolve<IApp>();
      _fuApp.Start();
    }

    public void Stop()
    {
      if (_fuApp == null)
        throw new InvalidOperationException("App has not been started.");

      _fuApp.Stop();
    }


    private IContainer buildContainer()
    {
      var modules = new Module[] {
        new CoreModule(_settings),
        new WebModule(_settings),
        new DataModule()
      };

      var builder = new ContainerBuilder();
      Array.ForEach(modules, builder.RegisterModule);

      return builder.Build();
    }


    public void Dispose()
    {
      if (_fuApp != null)
        _fuApp.Dispose();

      _container.Dispose();
    }
  }
}
