﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OkkaKalipWeb.UI.Controllers
{
    public class ImageGalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}