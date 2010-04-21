
using Fu;
using Fu.Steps;

namespace NToast.Web.Controllers
{
  public class Content : ToastController
  {
    // TODO: Add CSS minification
    public override void Initialize()
    {
      Get(Urls.CssFolder + "(.+)", fu.Static.Folder(Urls.CssFolder, "Content/css"));
    }
  }
}
