using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace OnlineStore.Web.Api.Controllers;

[ApiController]
[Authorize]
public abstract class BaseApiController : ControllerBase
{

    protected BaseApiController()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt",
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true)
            .CreateLogger();
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