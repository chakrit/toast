
using Fu;
using Fu.Steps;

namespace NToast.Web.Controllers
{
  public class Homepage : ToastController
  {
    public override void Initialize()
    {
      Handle(Urls.Homepage, c => new ToastPage("Home.Main"));
    }
  }
}
