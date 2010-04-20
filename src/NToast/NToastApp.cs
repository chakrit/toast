﻿
using Autofac;

using System;

using Fu;

using NToast.Web;

namespace NToast
{
  public class NToastApp
  {
    private ToastSettings _settings;
    private IContainer _container;

    public NToastApp(ToastSettings settings)
    {
      _settings = settings;
      _container = buildContainer();
    }


    public void Start()
    {
      // start the web application
      var webApp = _container.Resolve<IApp>();
      webApp.Start();
    }


    private IContainer buildContainer()
    {
      var modules = new Module[] {
        new CoreModule(_settings),
        new WebModule(_settings),
      };

      var builder = new ContainerBuilder();
      Array.ForEach(modules, builder.RegisterModule);

      return builder.Build();
    }
  }
}
