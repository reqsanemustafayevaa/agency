﻿using Microsoft.AspNetCore.Mvc;


namespace agencyproject12.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}