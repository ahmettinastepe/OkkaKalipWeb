using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
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

            return View(new NewsModel()
            {
                InfoModel = GetInfo(),
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

            News news = _newsService.GetById((int)id);
            if (news == null) return NotFound();

            return View(new NewsModel()
            {
                News = news,
                InfoModel = GetInfo()
            });
        }
    }
}