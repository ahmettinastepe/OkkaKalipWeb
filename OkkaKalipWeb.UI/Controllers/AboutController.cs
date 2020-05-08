using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
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

        [Authorize(Roles = "admin")]
        public IActionResult ServiceManageList()
        {
            var list = _aboutServicesService.GetAll();
            return View(new ServiceListModel() { Services = list });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateService()
        {
            return View(new ServiceModel());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateService(ServiceModel model, IFormFile file)
        {
            if (!ModelState.IsValid) return View(model);
            var entity = new Service();

            if (file != null)
            {
                entity.ImageUrl = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about\service", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);
            }

            entity.Title = model.Title;
            entity.Description = model.Description;            

            if (_aboutServicesService.Create(entity))
            {
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Servis"),
                    Title = Toastr.GetTitle("Servis"),
                    ToastrType = ToastrType.Success
                });

                return View(new ServiceModel());
            }

            ViewBag.ErrorMessage = _aboutServicesService.ErrorMessage;
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditService(int? id)
        {
            if (id == null) return NotFound();

            var entity = _aboutServicesService.GetById((int)id);
            if (entity == null) return NotFound();

            var model = new ServiceModel()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
                Description = entity.Description
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditService(ServiceModel model, IFormFile file)
        {
            var entity = _aboutServicesService.GetById(model.Id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity.Title = model.Title;
                entity.Description = model.Description;

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about\service", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(stream);
                }

                _aboutServicesService.Update(entity);
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Servis", EntityStatus.Update),
                    Title = Toastr.GetTitle("Servis", EntityStatus.Update),
                    ToastrType = ToastrType.Info
                });

                return RedirectToAction("ServiceManageList");
            }

            ViewBag.ErrorMessage = _aboutServicesService.ErrorMessage;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteService(int id)
        {
            var entity = _aboutServicesService.GetById(id);
            if (entity == null) return NotFound();

            _aboutServicesService.Delete(entity);
            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Servis", EntityStatus.Delete),
                Title = Toastr.GetTitle("Servis", EntityStatus.Delete),
                ToastrType = ToastrType.Error
            });

            return RedirectToAction("ServiceManageList");
        }
    }
}