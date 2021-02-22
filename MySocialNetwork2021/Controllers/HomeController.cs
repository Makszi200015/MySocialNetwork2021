﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySocialNetwork2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Friends()
        {
            return View();
        }
        public IActionResult Bans()
        {
            return View();
        }

        public IActionResult MyPhotoAlbum()
        {
            return View();
        }

        public IActionResult MyPhotos()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
