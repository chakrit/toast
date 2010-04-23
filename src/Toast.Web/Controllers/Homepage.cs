
namespace Toast.Web.Controllers
{
  public class Homepage : ToastController
  {
    public override void Initialize()
    {
      Get(Urls.Homepage, c => ToastPages.Home.Main());
    }
  }
}
