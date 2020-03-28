using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Enums;
using OkkaKalipWeb.UI.Models;
using OkkaKalipWeb.UI.Services;
using System.IO;
using System.Threading.Tasks;

namespace OkkaKalipWeb.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class SliderController : Controller
    {
        private ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult SliderList()
        {
            return View(new SliderListModel()
            {
                Sliders = _sliderService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View(new SliderModel());
        }

        [HttpPost]
        public IActionResult CreateSlider(SliderModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var entity = new Slider()
            {
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
            };

            if (_sliderService.Create(entity))
            {
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = "Slider Eklendi",
                    Title = "Kayıt Ekleme",
                    ToastrType = ToastrType.Success
                });

                return View(new SliderModel());
            }


            ViewBag.ErrorMessage = _sliderService.ErrorMessage;
            return View(model);
        }

        [HttpGet]
        public IActionResult EditSlider(int? id)
        {
            if (id == null)
                return NotFound();

            var entity = _sliderService.GetById((int)id);
            if (entity == null)
                return NotFound();

            var model = new SliderModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSlider(SliderModel model, IFormFile file)
        {
            var entity = _sliderService.GetById(model.Id);
            if (entity == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                entity.Title = model.Title;
                entity.Description = model.Description;

                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\slider", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _sliderService.Update(entity);
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = "Slider Güncellendi",
                    Title = "Kayıt Güncelleme",
                    ToastrType = ToastrType.Info
                });

                return RedirectToAction("SliderList");
            }

            ViewBag.ErrorMessage = _sliderService.ErrorMessage;
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteSlider(int id)
        {
            var entity = _sliderService.GetById(id);
            if (entity != null)
            {
                _sliderService.Delete(entity);
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = "Slider Silindi",
                    Title = "Kayıt Silme",
                    ToastrType = ToastrType.Error
                });
            }

            return RedirectToAction("SliderList");
        }
    }
}