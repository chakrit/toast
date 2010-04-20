
using Fu;
using Fu.Steps;

namespace NToast.Web.Controllers
{
  public class Content : ToastController
  {
    // TODO: Add CSS minification
    public override void Initialize()
    {
      Handle("/css/(.*)", fu.Static.Folder("/css/", "Content/css"));
    }
  }
}
