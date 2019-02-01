using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hunzi.Blog.Models;

namespace hunzi.Blog.Areas.Areas.Controllers
{
    [Area("Areas")]
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Head()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
