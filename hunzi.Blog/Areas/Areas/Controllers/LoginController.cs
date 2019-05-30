using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using hunzi.Blog.Model;
using hunzi.Blog.DAL;

namespace hunzi.Blog.Areas.Areas.Controllers
{
    [Area("Areas")]
    public class LoginController : Controller
    {

        AdminDAL AdminDAL;

        public LoginController(AdminDAL adminDAL)
        {
            AdminDAL = adminDAL;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            username = Tool.GetSafeSQL(username);
            password = Tool.MD5Hash(password);

            AdminModel admin = AdminDAL.Login(username, password);
            if (admin == null)
            {
                return Json(new { code = 1, msg = "用户账号或密码错误！" });
            }
            else
            {
                HttpContext.Session.SetInt32("Aid", admin.Aid);
                HttpContext.Session.SetString("UserName", admin.UserName);
                return Json(new { code = 0, msg = "登录成功！" });
            }
        }
    }
}