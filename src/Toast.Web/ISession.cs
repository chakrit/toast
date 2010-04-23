
using System;

namespace Toast.Web
{
  public interface ISession
  {
    bool Authorized { get; set; }
    Guid UserId { get; set; }

    string Username { get; set; }
  }
}
