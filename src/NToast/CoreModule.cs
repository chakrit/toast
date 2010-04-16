﻿
using Autofac;

namespace NToast
{
  public class CoreModule : Module
  {
    private ToastSettings _settings;

    public CoreModule(ToastSettings settings)
    {
      _settings = settings;
    }


    protected override void Load(ContainerBuilder b)
    {
      b.RegisterInstance(_settings);
    }
  }
}
