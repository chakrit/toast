
using System;

namespace NToast.Web
{
  public interface ISession
  {
    bool Authorized { get; set; }
    Guid UserId { get; set; }

    string Username { get; set; }
  }
}
