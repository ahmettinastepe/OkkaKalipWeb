using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.UI.Controllers
{
    public class HomeController : BaseController
    {
        private ISliderService _sliderService;
        private IAboutService _aboutService;
        private INewsService _newsService;
        private IAboutServicesService _aboutServicesService;
        private IClientsLogoService _clientsLogoService;

        public HomeController(ISliderService sliderService, IAboutService aboutService, INewsService newsService, IAboutServicesService aboutServicesService, IClientsLogoService clientsLogoService, IInfoService infoService) : base(infoService)
        {
            _sliderService = sliderService;
            _aboutService = aboutService;
            _newsService = newsService;
            _aboutServicesService = aboutServicesService;
            _clientsLogoService = clientsLogoService;
        }

        public IActionResult Index()
        {
            var aboutEntity = _aboutService.GetAbout();
            List<News> newsModelList = _newsService.GetAll().TakeLast(3).ToList();

            var serviceList = _aboutServicesService.GetAll();

            var clientsLogoList = _clientsLogoService.GetAll();

            return View(new HomeModel()
            {
                Sliders = _sliderService.GetAll(),
                InfoModel = GetInfo(),
                AboutModel = new AboutModel()
                {
                    AboutTitle = aboutEntity.AboutTitle,
                    AboutDescription = aboutEntity.AboutDescription,
                    Founder = aboutEntity.Founder,
                    Rank = aboutEntity.Rank,
                    YoutubeUrl = aboutEntity.YoutubeUrl,
                    YoutubeHomeImageUrl = aboutEntity.YoutubeHomeImageUrl,
                    Mission = aboutEntity.Mission,
                    Vision = aboutEntity.Vision,
                    WorkProcess = aboutEntity.WorkProcess
                },
                NewsListModel = newsModelList,
                Services = serviceList,
                ClientsLogos = clientsLogoList
            });
        }
    }
}