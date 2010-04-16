
using Fu.Services.Templating;

using NToast.Web.Tokens;

namespace NToast.Web
{
  public abstract class ToastTemplate : HamlTemplateBase
  {
  }

  public abstract class ToastTemplate<T> : ToastTemplate
    where T : Token
  {
    public T Token { get; set; }
  }
}
