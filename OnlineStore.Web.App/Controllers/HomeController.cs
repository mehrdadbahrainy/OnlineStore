using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
