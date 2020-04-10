using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Models;
using OkkaKalipWeb.UI.Services;
using System.IO;
using System.Threading.Tasks;

namespace OkkaKalipWeb.UI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class NewsController : BaseController
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService, IInfoService infoService) : base(infoService)
        {
            _newsService = newsService;
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 4;

            return View(new NewsListModel()
            {
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages(),
                PageInfo = new PageInfo()
                {
                    TotalItems = _newsService.GetAll().Count,
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    Controller = "News"
                },

                NewsList = _newsService.GetNewsByPageSize(page, pageSize)
            });
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();

            News entity = _newsService.GetById((int)id);
            if (entity == null) return NotFound();

            return View(new NewsModel()
            {
                InfoModel = GetInfo(),
                BannerImages = GetBannerImages(),
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                DateTime = entity.DateTime
            });
        }

        [Authorize(Roles = "admin")]
        public IActionResult NewsList()
        {
            return View(new NewsListModel()
            {
                NewsList = _newsService.GetAll()
            });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateNews()
        {
            return View(new NewsModel());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult CreateNews(NewsModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new News()
            {
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                Author = model.Author,
                Description = model.Description
            };

            if (_newsService.Create(entity))
            {
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Haber"),
                    Title = Toastr.GetTitle("Haber"),
                    ToastrType = ToastrType.Success
                });

                return View(new NewsModel());
            }

            ViewBag.ErrorMessage = _newsService.ErrorMessage;
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult EditNews(int? id)
        {
            if (id == null) return NotFound();

            var entity = _newsService.GetById((int)id);
            if (entity == null) return NotFound();

            var model = new NewsModel()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Title = entity.Title,
                Author = entity.Author,
                Description = entity.Description,
                DateTime = entity.DateTime
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditNews(NewsModel model, IFormFile file)
        {
            var entity = _newsService.GetById(model.Id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity.Title = model.Title;
                entity.Author = model.Author;
                entity.Description = model.Description;
                entity.DateTime = model.DateTime;

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\news", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(stream);
                }

                _newsService.Update(entity);
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Haber", EntityStatus.Update),
                    Title = Toastr.GetTitle("Haber", EntityStatus.Update),
                    ToastrType = ToastrType.Info
                });

                return RedirectToAction("NewsList");
            }

            ViewBag.ErrorMessage = _newsService.ErrorMessage;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteNews(int id)
        {
            var entity = _newsService.GetById(id);
            if (entity == null) return NotFound();

            _newsService.Delete(entity);
            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Haber", EntityStatus.Delete),
                Title = Toastr.GetTitle("Haber", EntityStatus.Delete),
                ToastrType = ToastrType.Error
            });

            return RedirectToAction("NewsList");
        }
    }
}