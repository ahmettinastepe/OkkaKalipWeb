using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Functions;
using OkkaKalipWeb.UI.Models;
using OkkaKalipWeb.UI.Services;
using System.IO;
using System.Threading.Tasks;

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
                YoutubeHomeImageUrl = entity.YoutubeHomeImageUrl,
                DifferentText = entity.DifferentText,
                DifferentKeywords = entity.DifferentKeywords
            });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult AboutManage()
        {
            var entity = _aboutService.GetAbout();
            return View(entity.EntityConvert<AboutModel>());
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AboutManage(AboutModel model, IFormFile about, IFormFile youtubeImage, IFormFile youtubeHomeImage)
        {
            var entity = _aboutService.GetAbout();
            if (ModelState.IsValid)
            {
                entity.AboutTitle = model.AboutTitle;
                entity.ExperienceYear = model.ExperienceYear;
                entity.AboutDescription = model.AboutDescription;
                entity.ValuesTitle = model.ValuesTitle;
                entity.Founder = model.Founder;
                entity.Rank = model.Rank;
                entity.Vision = model.Vision;
                entity.Mission = model.Mission;
                entity.WorkProcess = model.WorkProcess;
                entity.YoutubeUrl = model.YoutubeUrl;
                entity.YoutubeTitle = model.YoutubeTitle;
                entity.YoutubeDescription = model.YoutubeDescription;
                entity.DifferentText = model.DifferentText;
                entity.DifferentKeywords = model.DifferentKeywords;

                if (about != null)
                    if (about.Length > 0)
                    {
                        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await about.CopyToAsync(stream);
                            entity.ImageUrl = fileName;
                        }
                    }

                if (youtubeImage != null)
                    if (youtubeImage.Length > 0)
                    {
                        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await youtubeImage.CopyToAsync(stream);
                            entity.YoutubeImageUrl = fileName;
                        }
                    }

                if (youtubeHomeImage != null)
                    if (youtubeHomeImage.Length > 0)
                    {
                        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await youtubeHomeImage.CopyToAsync(stream);
                            entity.YoutubeHomeImageUrl = fileName;
                        }
                    }
            }

            _aboutService.Update(entity);
            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Kurumsal Bilgiler", EntityStatus.Update),
                Title = Toastr.GetTitle("Kurumsal Bilgi", EntityStatus.Update),
                ToastrType = ToastrType.Info
            });

            return View(entity.EntityConvert<AboutModel>());
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
                BannerImages = GetBannerImages(),
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
                Description = entity.Description
            });
        }
    }
}