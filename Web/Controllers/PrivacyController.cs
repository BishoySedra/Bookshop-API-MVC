﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
