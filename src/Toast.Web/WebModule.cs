
using System;
using System.Collections.Generic;
using System.Linq;

using Autofac;

using Fu;
using Fu.Services;
using Fu.Services.Models;
using Fu.Services.Sessions;
using Fu.Services.Templating;
using Fu.Services.Web;
using Fu.Steps;

using NHaml;
using NHaml.TemplateResolution;

using Toast.Web.Controllers;

using Token = Toast.Web.Tokens.Token;

namespace Toast.Web
{
  public class WebModule : Module
  {
    private ToastSettings _settings;

    public WebModule(ToastSettings settings)
    {
      _settings = settings;
    }


    protected override void Load(ContainerBuilder b)
    {
      base.Load(b);

      // only use the setup controller at first run
      if (_settings.FirstRun) {
        b.RegisterType<Setup>()
          .As<IFuController>()
          .SingleInstance()
          .PropertiesAutowired();

        // also include all static contents (CSS/JS etc.)
        b.RegisterType<Content>()
          .As<IFuController>()
          .SingleInstance()
          .PropertiesAutowired();

        // and a model binder for settings
        b.RegisterType<ModelBinder<ToastSettings>>()
          .As<IService>()
          .SingleInstance();

      }
      else {
        // register all controllers except the setup controllers
        b.RegisterAssemblyTypes(typeof(ToastController).Assembly)
          .AssignableTo<ToastController>()
          .Where(t => t != typeof(Setup))
          .As<IFuController>()
          .SingleInstance()
          .PropertiesAutowired();
      }


      // create a modelbinder for all token types
      var tokenType = typeof(Token);
      var binderType = typeof(ModelBinder<>);

      var tokenTypes = tokenType
        .Assembly
        .GetTypes()
        .Where(t => tokenType.IsAssignableFrom(t))
        .Where(t => !t.IsAbstract && !t.IsInterface)
        .Select(t => binderType.MakeGenericType(t))
        .ToArray();

      Array.ForEach(tokenTypes, t =>
        b.RegisterType(t).As<IService>().SingleInstance());


      // misc. required web services
      b.RegisterType<FormDataParser>().As<IService>().SingleInstance();
      b.RegisterType<MultipartFormDataParser>().As<IService>().SingleInstance();


      // templating services
      b.Register(c => buildTemplateOptions(c))
        .As<TemplateOptions>()
        .SingleInstance();

      b.RegisterType<TemplateEngine>()
        .As<TemplateEngine>()
        .UsingConstructor(typeof(TemplateOptions))
        .SingleInstance();

      b.RegisterType<HamlTemplateService>()
        .As<IService>()
        .UsingConstructor(typeof(TemplateEngine))
        .SingleInstance();


      // uses memory-based sessions, for now. we can upgrade
      // to a DB-backed or Redis-backed session store later
      // however, that might run counter to the goal of Toast
      // which is maximum simplicity, I don't think we need that
      b.RegisterType<InMemorySessionService<ISession>>()
        .As<IService>()
        .SingleInstance();


      // Fu application
      b.Register(c => buildFuSettings(c))
        .As<FuSettings>()
        .SingleInstance();

      b.Register(c => buildFuApp(c))
        .As<IApp>()
        .SingleInstance();
    }


    private FuSettings buildFuSettings(IComponentContext c)
    {
      var ntSettings = c.Resolve<ToastSettings>();

      return new FuSettings {
        Hosts = new[] { ntSettings.Host + ":" + ntSettings.Port.ToString() }
      };
    }

    private IApp buildFuApp(IComponentContext c)
    {
      var services = c.Resolve<IEnumerable<IService>>();
      var settings = c.Resolve<FuSettings>();
      var controllers = c.Resolve<IEnumerable<IFuController>>();

      var pipeline = fu.Map.Controllers(controllers.ToArray());

      return new App(settings, services, pipeline);
    }


    private TemplateOptions buildTemplateOptions(IComponentContext c)
    {
      var settings = c.Resolve<ToastSettings>();

      // setup template content provider
      var tmplProvider = new FileTemplateContentProvider();

      tmplProvider.PathSources.Clear();
      tmplProvider.PathSources.Add("Content/haml");

      // build the template options
      var opts = new TemplateOptions {
        AutoRecompile = true,
        UseTabs = false,
        IndentSize = 2,
        TemplateContentProvider = tmplProvider,
        OutputDebugFiles = settings.DebugMode,
      };

      // add all assemblies required to be referenced by the template code
      var refs = new[] {
        typeof(ToastTemplate).Assembly,
        typeof(ToastSettings).Assembly,
        typeof(System.Web.HttpContext).Assembly
      };

      opts.References.Clear();
      Array.ForEach(refs, opts.AddReference);

      opts.AddReference("Toast.exe");

      // add Toast-specific usings
      var usings = new[] {
        "Toast",
        "Toast.Web",
        "Toast.Web.Tokens"
      };

      Array.ForEach(usings, opts.AddUsing);

      return opts;
    }
  }
}
