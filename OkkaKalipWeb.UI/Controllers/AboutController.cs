using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    public class AboutController : BaseController
    {
        public AboutController(IInfoService infoService) : base(infoService)
        {
        }
        public IActionResult Index()
        {
            return View(new AboutModel()
            {
                InfoModel = GetInfo()
            });
        }
    }
}