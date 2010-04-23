
using Fu;
using Fu.Steps;

namespace Toast.Web.Controllers
{
  public class Homepage : ToastController
  {
    public override void Initialize()
    {
      Get(Urls.Ping, fu.Static.Json(new { ok = true }));

      Get(Urls.Homepage, c => ToastPages.Home.Main());

      // reset script for debugging purpose
#if DEBUG
      Get(Urls.SetupReset, step => ctx =>
      {
        Settings.FirstRun = true;
        Settings.SaveDefault();

        Events.RequestRestart(this);
      });
#endif
    }
  }
}
