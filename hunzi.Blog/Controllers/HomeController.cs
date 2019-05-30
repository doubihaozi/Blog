using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hunzi.Blog.Model;
using hunzi.Blog.DAL;
using System.Collections;

namespace hunzi.Blog.Controllers
{
    public class HomeController : Controller
    {
        BlogDAL BlogDAL;

        public HomeController(BlogDAL blogDAL)
        {
            BlogDAL = blogDAL;
        }

        public IActionResult Index()
        {
            return View();
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
            string where = "";
            if (!string.IsNullOrEmpty(model.Title))
            {
                model.Title = Tool.GetSafeSQL(model.Title);
                where += $" and Title like '%{model.Title}%'";
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


    }
}
