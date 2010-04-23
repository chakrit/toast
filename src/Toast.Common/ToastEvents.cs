
using System;

namespace Toast
{
  // NOTE: As we're not using interfaces for this thing,
  //       don't add anything fancy, keep it as a list
  //       of simple event/raiseMethod pair
  public sealed class ToastEvents
  {
    public event EventHandler RestartRequested;


    public void RequestRestart(object sender)
    {
      var ev = RestartRequested;
      if (ev != null)
        ev(sender, EventArgs.Empty);
    }
  }
}
