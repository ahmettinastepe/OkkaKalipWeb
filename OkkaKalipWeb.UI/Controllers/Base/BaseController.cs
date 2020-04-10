using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Controllers.Base
{
    public class BaseController : Controller
    {
        private IInfoService _infoService;

        public BaseController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        public Info GetInfo()
        {
            return _infoService.GetInfo();
        }

        public List<BannerImage> GetBannerImages()
        {
            return _infoService.GetAllBannerIamges();
        }
    }
}