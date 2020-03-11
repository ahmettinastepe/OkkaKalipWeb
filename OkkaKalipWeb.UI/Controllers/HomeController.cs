using Microsoft.AspNetCore.Mvc;

namespace OkkaKalipWeb.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SelectedMenu = RouteData.Values["controller"];
            return View();
        }
    }
}