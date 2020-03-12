using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString().ToLower(),
                Categories = _categoryService.GetAll()
            });
        }
    }
}