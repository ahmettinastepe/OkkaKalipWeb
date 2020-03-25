using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OkkaKalipWeb.UI.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult SliderList()
        {
            return View();
        }
    }
}