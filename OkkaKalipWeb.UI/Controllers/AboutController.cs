using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    public class AboutController : BaseController
    {
        private IAboutService _aboutService;

        public AboutController(IAboutService aboutService, IInfoService infoService) : base(infoService)
        {
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            var entity = _aboutService.GetAbout();
            return View(new AboutModel()
            {
                InfoModel = GetInfo(),
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
                YoutubeTitle=entity.YoutubeTitle,
                YoutubeDescription=entity.YoutubeDescription,
                YoutubeUrl=entity.YoutubeUrl,
                YoutubeImageUrl=entity.YoutubeImageUrl,
                YoutubeHomeImageUrl=entity.YoutubeHomeImageUrl
            });
        }

        [HttpGet]
        public IActionResult AboutManage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutManage(AboutModel model)
        {
            return View();
        }
    }
}