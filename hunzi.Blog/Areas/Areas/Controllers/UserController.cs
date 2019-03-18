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
            ViewBag.List = AdminDAL.GetAdminList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            int i = AdminDAL.Delete(id);
            if (i > 0)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败,请联系管理员！");
            }
        }
    }
}