using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OkkaKalipWeb.UI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.SelectedMenu = RouteData.Values["controller"];
            return View();
        }
    }
}