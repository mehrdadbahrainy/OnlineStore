using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Web.App.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
