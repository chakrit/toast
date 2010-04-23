
using System;

using Fu;
using Fu.Steps;

using Toast.Data;

namespace Toast.Web
{
  public abstract class ToastController : RestStyleController
  {
    protected bool EnableHttpCompression { get; set; }


    public ToastSettings Settings { get; set; }
    public ToastEvents Events { get; set; }
    public IDbManager Db { get; set; }

    public ToastController()
    {
      EnableHttpCompression = true;
    }


    protected override void Map(string url,
      Func<Continuation, Continuation, Continuation> wrapper,
      Continuation handler)
    {
      handler = handler.Then(fu.Result.Render(EnableHttpCompression));

      base.Map(url, wrapper, handler);
    }
  }
}
