using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Functions;
using OkkaKalipWeb.UI.Models;
using OkkaKalipWeb.UI.Services;

namespace OkkaKalipWeb.UI.Controllers
{
    [Authorize(Roles = "admin")]
    [AutoValidateAntiforgeryToken]
    public class InfoController : Controller
    {
        private IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet]
        public IActionResult EditInfo()
        {
            var entity = _infoService.GetInfo();
            return View(entity.EntityConvert<InfoModel>());
        }

        [HttpPost]
        public async Task<IActionResult> EditInfo(InfoModel model, IFormFile logoHeader, IFormFile logoFooter)
        {
            var entity = _infoService.GetInfo();

            if (ModelState.IsValid)
            {
                entity.Address = model.Address;
                entity.Email1 = model.Email1;
                entity.Email2 = model.Email2;
                entity.Tel1 = model.Tel1;
                entity.Tel2 = model.Tel2;
                entity.FacebookUrl = model.FacebookUrl;
                entity.InstagramUrl = model.InstagramUrl;
                entity.TwitterUrl = model.TwitterUrl;
                entity.YoutubeUrl = model.YoutubeUrl;
                entity.MapIframe = model.MapIframe.ChangeMapUrl();
                entity.SiteTitle = model.SiteTitle;
                entity.Author = model.Author;
                entity.Keywords = model.Keywords;
                entity.Description = model.Description;

                if (logoHeader != null)
                    if (logoHeader.Length > 0)
                    {
                        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\info", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await logoHeader.CopyToAsync(stream);
                            entity.LogoHeader = fileName;
                        }
                    }

                if (logoFooter != null)
                    if (logoFooter.Length > 0)
                    {
                        var fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                        var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\info", fileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await logoFooter.CopyToAsync(stream);
                            entity.LogoFooter = fileName;
                        }
                    }
            }

            _infoService.Update(entity);
            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Firma Bilgileri", EntityStatus.Update),
                Title = Toastr.GetTitle("Firma Bilgileri", EntityStatus.Update),
                ToastrType = ToastrType.Info
            });

            return View(entity.EntityConvert<InfoModel>());
        }
    }
}