﻿
// AUTOGENERATED - from ToastPages.tt on 04/19/2010 01:03:09

using NToast.Web.Tokens;

namespace NToast.Web
{
  public static class ToastPages
  {

    private static HomeLayout _layoutHome = new HomeLayout();

    public static HomeLayout Home { get { return _layoutHome; } }

    public class HomeLayout
    {
      protected internal HomeLayout() { }

      public ToastPage Main()
      {
        return new ToastPage("Home.Main");
      }

      public ToastPage<TToken> Main<TToken>(TToken token)
        where TToken : Token
      {
        return new ToastPage<TToken>("Home.Main", token);
      }

    }

    private static SetupLayout _layoutSetup = new SetupLayout();

    public static SetupLayout Setup { get { return _layoutSetup; } }

    public class SetupLayout
    {
      protected internal SetupLayout() { }

      public ToastPage First()
      {
        return new ToastPage("Setup.First");
      }

      public ToastPage<TToken> First<TToken>(TToken token)
        where TToken : Token
      {
        return new ToastPage<TToken>("Setup.First", token);
      }

    }
  }
}

