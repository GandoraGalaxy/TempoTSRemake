﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TempoTS.MVC.Controllers
{
    public class TimeClockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}