
using Fu;
using Fu.Results;
using Fu.Steps;

namespace NToast.Web
{
  public abstract class ToastController : FuController
  {
    protected override void Handle(string urlRegex, params Continuation[] steps)
    {
      // if no ^ and $ supplied, assumes we want to match entire Urls
      // so we automatically adds ^ and $ to prevents partial matches
      if (!urlRegex.StartsWith("^") && !urlRegex.EndsWith("$"))
        urlRegex = "^" + urlRegex + "$";

      // adds a Result.Render() step
      var step = fu
        .Compose(steps)
        .Then(fu.Result.Render(true));

      base.Handle(urlRegex, step);
    }

    // we frequently used the Results framework, so we're providing
    // overload here for convenience
    protected void Handle(string urlRegex, Reduce<IResult> resultStep)
    {
      Handle(urlRegex, fu.Results(resultStep));
    }
  }
}
