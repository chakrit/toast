
using NToast.Web.Tokens;

namespace NToast.Web.Controllers
{
  public class Setup : ToastController
  {
    public const string Homepage = "/";


    public override void Initialize()
    {
      // show the first page with the settings
      Handle(Homepage, c => ToastPages
        .Setup
        .First(new SetupToken { Settings = Settings }));
    }
  }
}
