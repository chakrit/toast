
namespace Toast.Web
{
  public static class Urls
  {
    public const string CssFolder = "/css/";
    public const string JsFolder = "/js/";

    public const string Homepage = "/";
    public const string Ping = "/ping";

    public const string SetupHome = "/setup";
    public const string SetupCommit = "/setup/save";

#if DEBUG
    public const string SetupReset = "/setup/reset";
#endif
  }
}
