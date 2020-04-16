using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Models;
using OkkaKalipWeb.UI.Services;

namespace OkkaKalipWeb.UI.Controllers
{
    public class BannerController : Controller
    {
        private IBannerImageService _bannerImageService;

        public BannerController(IBannerImageService bannerImageService)
        {
            _bannerImageService = bannerImageService;
        }

        public IActionResult BannerList()
        {
            return View(new BannerImageListModel()
            {
                BannerImages = _bannerImageService.GetAll()
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(IFormFile file)
        {
            if (file != null)
            {
                var entity = new BannerImage() { ImageUrl = file.FileName };

                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\banner", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

                if (_bannerImageService.Create(entity))
                {
                    ToastrService.AddToUserQueue(new Toastr()
                    {
                        Message = Toastr.GetMessage("Banner Resmi"),
                        Title = Toastr.GetTitle("Banner"),
                        ToastrType = ToastrType.Success
                    });

                    return RedirectToAction("BannerList");
                }
            }

            ViewBag.ErrorMessage = _bannerImageService.ErrorMessage;
            return RedirectToAction("BannerList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(int? id, IFormFile file)
        {
            if (id == null) return NotFound();

            var entity = _bannerImageService.GetById((int)id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\banner", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(stream);
                }

                _bannerImageService.Update(entity);
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Banner Resmi", EntityStatus.Update),
                    Title = Toastr.GetTitle("Banner", EntityStatus.Update),
                    ToastrType = ToastrType.Info
                });

                return RedirectToAction("BannerList");
            }

            ViewBag.ErrorMessage = _bannerImageService.ErrorMessage;
            return RedirectToAction("BannerList");
        }

        [HttpPost]
        public IActionResult DeleteBanner(int id)
        {
            var entity = _bannerImageService.GetById(id);
            if (entity == null) return NotFound();

            _bannerImageService.Delete(entity);
            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Banner Resmi", EntityStatus.Delete),
                Title = Toastr.GetTitle("Banner", EntityStatus.Delete),
                ToastrType = ToastrType.Error
            });

            return RedirectToAction("BannerList");
        }
    }
}