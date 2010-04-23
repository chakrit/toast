
using Fu;
using Fu.Steps;

namespace Toast.Web.Controllers
{
  public class Content : ToastController
  {
    public override void Initialize()
    {
      // TODO: Add JS & CSS minification
      Get(Urls.CssFolder + "(.+)", fu.Static.Folder(Urls.CssFolder, "Content/css"));
      Get(Urls.JsFolder + "(.+)", fu.Static.Folder(Urls.JsFolder, "Content/js"));
    }
  }
}
