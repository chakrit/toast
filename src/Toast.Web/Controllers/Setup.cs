﻿
using Toast.Web.Tokens;

namespace Toast.Web.Controllers
{
  public class Setup : ToastController
  {
    public override void Initialize()
    {
      // show the first page with the settings
      Get(Urls.Homepage, c => ToastPages
        .Setup
        .First(new SetupToken { Settings = Settings }));
    }
  }
}