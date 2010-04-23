
using Fu.Services.Templating;

using Toast.Web.Tokens;

namespace Toast.Web
{
  public abstract class ToastTemplate : HamlTemplateBase
  {
    public Messages Messages { get; set; }
  }

  public abstract class ToastTemplate<T> : ToastTemplate
    where T : Token
  {
    public T Token { get; set; }
  }
}
