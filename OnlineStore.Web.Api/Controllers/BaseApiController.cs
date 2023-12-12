using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.Api.Controllers;

[ApiController]
//[Authorize]
public abstract class BaseApiController : ControllerBase
{
}