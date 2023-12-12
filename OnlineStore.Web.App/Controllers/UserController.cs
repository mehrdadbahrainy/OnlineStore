using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.App.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
