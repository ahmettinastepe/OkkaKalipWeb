using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Models;
using OkkaKalipWeb.UI.Services;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OkkaKalipWeb.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult ProductList()
        {

            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new Product()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl == null ? "urun-resim-yok.png" : model.ImageUrl,
                Description = model.Description,
                Price = model.Price
            };

            if (_productService.Create(entity))
            {
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Ürün"),
                    Title = Toastr.GetTitle("Ürün"),
                    ToastrType = ToastrType.Success
                });

                return View(new ProductModel());
            }

            ViewBag.ErrorMessage = _productService.ErrorMessage;
            return View(model);
        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
                return NotFound();

            var entity = _productService.GetByIdWithCategories((int)id);
            if (entity == null)
                return NotFound();

            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                SelectedCategories = entity.ProductCategories.Select(x => x.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel model, int[] categoryIds, IFormFile file)
        {
            var entity = _productService.GetById(model.Id);
            if (entity == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Price = model.Price;

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _productService.Update(entity, categoryIds);

                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Ürün",EntityStatus.Update),
                    Title = Toastr.GetTitle("Ürün", EntityStatus.Update),
                    ToastrType = ToastrType.Info
                });

                return RedirectToAction("ProductList");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var entity = _productService.GetById(id);
            if (entity != null)
            {
                _productService.Delete(entity);

                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Ürün", EntityStatus.Delete),
                    Title = Toastr.GetTitle("Ürün", EntityStatus.Delete),
                    ToastrType = ToastrType.Error
                });
            }


            return RedirectToAction("ProductList");
        }

        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
            {
                Categories = _categoryService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);

            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Kategori"),
                Title = Toastr.GetTitle("Kategori"),
                ToastrType = ToastrType.Success
            });

            return View();
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByIdWithProducts(id);

            if (entity == null)
                return NotFound();

            return View(new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = entity.ProductCategories.Select(x => x.Product).ToList()
            });
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity == null)
                return NotFound();

            entity.Name = model.Name;
            _categoryService.Update(entity);

            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Kategori", EntityStatus.Update),
                Title = Toastr.GetTitle("Kategori", EntityStatus.Update),
                ToastrType = ToastrType.Info
            });

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var entity = _categoryService.GetById(id);
            if (entity != null)
            {
                _categoryService.Delete(entity);

                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Kategori", EntityStatus.Delete),
                    Title = Toastr.GetTitle("Kategori", EntityStatus.Delete),
                    ToastrType = ToastrType.Error
                });
            }

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);

            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = "Seçili Ürün Mevcut Kategoriden Silindi",
                Title = "Kategoriden Ürün Silme",
                ToastrType = ToastrType.Error
            });

            return Redirect($"/product/editcategory/{categoryId}");
        }
    }
}