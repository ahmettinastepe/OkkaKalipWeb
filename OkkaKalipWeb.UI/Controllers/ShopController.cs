using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Models;
using System.Linq;

namespace OkkaKalipWeb.UI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
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

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
                return NotFound();

            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(x => x.Category).ToList()
            });
        }
    }
}