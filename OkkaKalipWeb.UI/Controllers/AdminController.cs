using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.UI.Models;

namespace OkkaKalipWeb.UI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            ViewBag.SelectedMenu = RouteData.Values["controller"];

            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}