using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    public class HomeController : BaseController
    {
        private ISliderService _sliderService;

        public HomeController(ISliderService sliderService, IInfoService infoService) : base(infoService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {

            return View(new HomeModel()
            {
                Sliders = _sliderService.GetAll(),
                InfoModel = GetInfo()
            });
        }
    }
}