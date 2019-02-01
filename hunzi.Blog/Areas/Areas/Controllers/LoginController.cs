using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hunzi.Blog.Areas.Areas.Controllers
{
    [Area("Areas")]
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}