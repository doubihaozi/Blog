using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hunzi.Blog.Model;
using hunzi.Blog.DAL;
using System.Collections;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace hunzi.Blog.Areas.Areas.Controllers
{
    [Area("Areas")]
    public class HomeController : Controller
    {
        private IHostingEnvironment hostingEvn;

        AdminDAL AdminDAL;
        BlogDAL BlogDAL;
        CategoryDAL CategoryDAL;

        public HomeController(IHostingEnvironment env,AdminDAL adminDAL,BlogDAL blogDAL,CategoryDAL categoryDAL)
        {
            this.hostingEvn = env;
            AdminDAL = adminDAL;
            BlogDAL = blogDAL;
            CategoryDAL = categoryDAL;
        }

        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("Aid");
            string UserName = HttpContext.Session.GetString("UserName");
            if(id==null)
            {
                return Redirect("/Areas/Login/Login");
            }
            ViewBag.UserName = UserName;
            return View();
        }

        public IActionResult BlogList(BlogModel blog)
        {
            ViewBag.CaList = CategoryDAL.CategoryList();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add(int? Id)
        {
            ViewBag.CategoryList = CategoryDAL.CategoryList();
            BlogModel model = new BlogModel();
            if (Id != null)
            {
                model = BlogDAL.GetBlogModel(Id.Value);
            }
            return View(model);
        }

        /// <summary>
        /// 添加某条博客
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(BlogModel blog)
        {
            CategoryModel model = CategoryDAL.GetCategoryByBh(blog.CBh);
            if (blog.Bid == 0)
            {
                if (model != null)
                {
                    blog.CName = model.CName;
                    blog.CBh = model.CBh;
                }
                blog.CreateDate = DateTime.Now;
                blog.Aid = 1;
                BlogDAL.Insert(blog);
            }
            else
            {
                if (model != null)
                {
                    blog.CName = model.CName;
                    blog.CBh = model.CBh;
                }
                BlogDAL.Update(blog);
            }
            return Redirect("/Areas/Home/BlogList");
        }
        /// <summary>
        /// 删除某条博客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            int i = BlogDAL.Delete(id);
            if (i > 0)
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败、请联系管理员！");
            }
        }

        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetBlogList(BlogModel model, int pageIndex, int pageSize)
        {
            DateTime date = default(DateTime);
            string where = "";
            if (!string.IsNullOrEmpty(model.Title))
            {
                model.Title = Tool.GetSafeSQL(model.Title);
                where += $" and Title like '%{model.Title}%'";
            }
            if (date!=model.StartTime)
            {
                where += $" and CreateDate>={model.StartTime.ToString("yyyy-MM-dd")}";
            }
            if (model.EndTime!=date)
            {
                where += $" and CreateDate<={model.EndTime.ToString("yyyy-MM-dd")}";
            }
            if (!string.IsNullOrEmpty(model.CBh) && model.CBh != "0")
            {
                model.CBh = Tool.GetSafeSQL(model.CBh);
                where += $" and CBh='{model.CBh}'";
            }
            int Count = BlogDAL.GetCount(where);
            int PageIndex = (pageIndex - 1) * pageSize;
            where += $" limit {PageIndex},{pageSize}";

            var List = BlogDAL.GetBlogList(where);
            ArrayList arr = new ArrayList();
            foreach (var item in List)
            {
                arr.Add(new
                {
                    bId = item.Bid,
                    title = item.Title,
                    createDate = item.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    viewNums = item.ViewNums,
                    cName = item.CName
                });
            }
            int pageCount = Count % pageSize == 0 ? Count / pageSize : Count / pageSize + 1;
            return Json(new { data = arr, pageCount = pageCount, total = Count });
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Bid"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ImgUpload(string Title)
        {
            long size = 0;
            var imgFile = Request.Form.Files[0];
            if (imgFile.FileName != null && !string.IsNullOrEmpty(imgFile.FileName))
            {
                var webRootPath = hostingEvn.WebRootPath;
                var filename = ContentDispositionHeaderValue
                               .Parse(imgFile.ContentDisposition)
                               .FileName
                               .Trim('"');
                string extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                #region 判断后缀
                if (!extname.ToLower().Contains("jpg") && !extname.ToLower().Contains("png") && !extname.ToLower().Contains("gif"))
                {
                    return Json(new { code = 1, msg = "只允许上传jpg,png,gif格式的图片" });
                }
                #endregion
                string filename1 = DateTime.Now.ToString("yyyyMMdd") + extname;
                if (!Directory.Exists(webRootPath + $@"\upload\{Title}"))
                {
                    Directory.CreateDirectory(webRootPath + $@"\upload\{Title}");
                }
                filename = hostingEvn.WebRootPath + $@"\upload\{Title}\{filename1}";
                size += imgFile.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    imgFile.CopyTo(fs);
                    fs.Flush();
                }
                return Json(new { code = 0, msg = "上传成功！", data = new { src = $@"\upload\{Title}\{filename1}", title = filename } });
            }
            else return Json(new { code = 1, msg = "上传失败！" });
        }

        

    }
}
