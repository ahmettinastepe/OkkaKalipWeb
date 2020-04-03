using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Controllers.Base;
using OkkaKalipWeb.UI.Models;
using System.Linq;

namespace OkkaKalipWeb.UI.Controllers
{
    public class ShopController : BaseController
    {
        private IProductService _productService;

        public ShopController(IProductService productService, IInfoService infoService) : base(infoService)
        {
            _productService = productService;
        }

        public IActionResult Index(string category, int page = 1)
        {
            const int pageSize = 3;
            return View(new ProductListModel()
            {
                InfoModel = GetInfo(),
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category,
                    Controller = "products"
                },

                Products = _productService.GetProductsByCategory(category, page, pageSize)
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
                InfoModel = GetInfo(),
                Product = product,
                Categories = product.ProductCategories.Select(x => x.Category).ToList()
            });
        }
    }
}