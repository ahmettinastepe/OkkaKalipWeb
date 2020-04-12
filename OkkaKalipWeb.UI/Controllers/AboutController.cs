using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    public class AboutController : BaseController
    {
        private IAboutService _aboutService;
        private IAboutServicesService _aboutServicesService;

        public AboutController(IAboutService aboutService, IAboutServicesService aboutServicesService, IInfoService infoService) : base(infoService)
        {
            _aboutService = aboutService;
            _aboutServicesService = aboutServicesService;
        }
        public IActionResult Index()
        {
            var entity = _aboutService.GetAbout();
            return View(new AboutModel()
            {
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages(),
                ImageUrl = entity.ImageUrl,
                AboutTitle = entity.AboutTitle,
                ExperienceYear = entity.ExperienceYear,
                AboutDescription = entity.AboutDescription,
                ValuesTitle = entity.ValuesTitle,
                ValuesDescription = entity.ValuesDescription,
                Founder = entity.Founder,
                Rank = entity.Rank,
                Vision = entity.Vision,
                Mission = entity.Mission,
                WorkProcess = entity.WorkProcess,
                YoutubeTitle = entity.YoutubeTitle,
                YoutubeDescription = entity.YoutubeDescription,
                YoutubeUrl = entity.YoutubeUrl,
                YoutubeImageUrl = entity.YoutubeImageUrl,
                YoutubeHomeImageUrl = entity.YoutubeHomeImageUrl
            });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AboutManage()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AboutManage(AboutModel model)
        {
            return View();
        }

        //Services
        public IActionResult ServiceList()
        {
            return View();
        }

        public IActionResult ServiceDetail(int? id)
        {
            if (id == null) return NotFound();

            var entity = _aboutServicesService.GetById((int)id);
            if (entity == null) return NotFound();

            return View(new AboutServiceModel()
            {
                InfoModel = GetInfo(),
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
                Description = entity.Description
            });
        }
    }
}