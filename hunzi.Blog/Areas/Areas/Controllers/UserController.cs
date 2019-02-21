using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hunzi.Blog.Model;
using hunzi.Blog.DAL;

namespace hunzi.Blog.Areas.Areas.Controllers
{
    [Area("Areas")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}