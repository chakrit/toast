
using Autofac;

namespace Toast.Data
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder b)
    {
      b.RegisterType<DbManager>()
        .As<IDbManager>()
        .SingleInstance()
        .PropertiesAutowired();
    }
  }
}
