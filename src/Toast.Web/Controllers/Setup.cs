
using System.Threading;

using Fu;
using Fu.Steps;

using Toast.Web.Tokens;

namespace Toast.Web.Controllers
{
  public class Setup : ToastController
  {
    public override void Initialize()
    {
      // Redirects the "/" to the setup url, if it's not the same
      if (Urls.Homepage != Urls.SetupHome)
        Get(Urls.Homepage, fu.Redirect.To(Urls.SetupHome));

      // show the first page with the settings
      Get(Urls.SetupHome, c => ToastPages
        .Setup
        .First(new SetupToken { Settings = Settings }));

      // save settings and show a restart page
      Post(Urls.SetupHome, c =>
      {
        var settings = c.Get<ToastSettings>();

        // TODO: Add validation when we have xVal integrated and running

        // if (!validated)
        //   return ToastPages.Setup.First(new SetupToken { Settings = settings });

        return ToastPages.Setup.Done(new SetupToken { Settings = settings });
      });

      // commit settings to disk and restart the application in normal mode
      Post(Urls.SetupCommit, step => ctx =>
      {
        var settings = ctx.Get<ToastSettings>();

        // turns off FirstRun mode
        settings.FirstRun = false;
        settings.SaveDefault();

        // shows a restart page to the user first
        fu.Results(ToastPages.Setup.Restart())(step)(ctx);

        // wait a few seconds so the client can download css/js etc.
        // TODO: Is there a way to makedo without this little delay?
        Thread.Sleep(3000);

        // setup database
        Db.CheckAndSetup();
        Events.RequestRestart(this);
      });
    }
  }
}
