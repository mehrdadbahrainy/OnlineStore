using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Api.Controllers;

[ApiController]
[Authorize]
public abstract class BaseApiController : ControllerBase
{

    protected BaseApiController()
    {

    }

    public int? UserId
    {
        get
        {
            var userIdentity = this.User.Identity;
            if (userIdentity is { IsAuthenticated: true })
            {
                return int.Parse(this.User.Claims.First(i => i.Type == "UserId").Value);
            }

            return null;
        }
    }
}