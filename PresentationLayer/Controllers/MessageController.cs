﻿using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
