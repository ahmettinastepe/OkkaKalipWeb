using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class ClientsLogoController : Controller
    {
        private IClientsLogoService _clientsLogoService;

        public ClientsLogoController(IClientsLogoService clientsLogoService)
        {
            _clientsLogoService = clientsLogoService;
        }

        public IActionResult ClientsLogoList()
        {
            return View(new ClientsLogoList()
            {
                ClientsLogos = _clientsLogoService.GetAll()
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientsLogo(IFormFile file)
        {
            if (file != null)
            {
                var entity = new ClientsLogo() { ImageUrl = file.FileName };

                var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about\partners", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

                if (_clientsLogoService.Create(entity))
                {
                    ToastrService.AddToUserQueue(new Toastr()
                    {
                        Message = Toastr.GetMessage("Partner Logosu"),
                        Title = Toastr.GetTitle("Logo"),
                        ToastrType = ToastrType.Success
                    });

                    return RedirectToAction("ClientsLogoList");
                }
            }

            ViewBag.ErrorMessage = _clientsLogoService.ErrorMessage;
            return RedirectToAction("ClientsLogoList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClientsLogo(int? id, IFormFile file)
        {
            if (id == null) return NotFound();

            var entity = _clientsLogoService.GetById((int)id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    entity.ImageUrl = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img\about\partners", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                        await file.CopyToAsync(stream);
                }

                _clientsLogoService.Update(entity);
                ToastrService.AddToUserQueue(new Toastr()
                {
                    Message = Toastr.GetMessage("Partner Logosu", EntityStatus.Update),
                    Title = Toastr.GetTitle("Logo", EntityStatus.Update),
                    ToastrType = ToastrType.Info
                });

                return RedirectToAction("ClientsLogoList");
            }
            ViewBag.ErrorMessage = _clientsLogoService.ErrorMessage;
            return RedirectToAction("ClientsLogoList");
        }

        [HttpPost]
        public IActionResult DeleteClientLogo(int id)
        {
            var entity = _clientsLogoService.GetById(id);
            if (entity == null) return NotFound();

            _clientsLogoService.Delete(entity);
            ToastrService.AddToUserQueue(new Toastr()
            {
                Message = Toastr.GetMessage("Partner Logosu", EntityStatus.Delete),
                Title = Toastr.GetTitle("Logo", EntityStatus.Delete),
                ToastrType = ToastrType.Error
            });

            return RedirectToAction("ClientsLogoList");
        }
    }
}