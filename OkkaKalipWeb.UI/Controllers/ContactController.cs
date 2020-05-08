using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(IInfoService infoService) : base(infoService)
        {
        }
        public IActionResult Index()
        {
            return View(new ContactModel()
            {
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages()
            });
        }
    }
}