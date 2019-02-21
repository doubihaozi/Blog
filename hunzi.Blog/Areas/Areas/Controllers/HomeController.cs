using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hunzi.Blog.Model;
using hunzi.Blog.DAL;

namespace hunzi.Blog.Areas.Areas.Controllers
{
    [Area("Areas")]
    public class HomeController : Controller
    {
        BlogDAL blogDAL = new BlogDAL();

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult BlogList()
        {
            BlogModel model = new BlogModel();
            ViewBag.CaList = CategoryDAL.CategoryList();
            ViewBag.BlogList = BlogDAL.GetBlog(model);
            return View();
        }

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


        [HttpPost]
        public IActionResult Add(BlogModel blog)
        {
            CategoryModel model = CategoryDAL.GetCategoryByBh(blog.CBh);
            if (blog.Bid == 0)
            {
                if (model != null)
                {
                    blog.CName = model.CName;
                }
                blog.CreateDate = DateTime.Now;
                blog.Aid = 1;
                BlogDAL.Insert(blog);
            }
            else
            {
                BlogDAL.Update(blog);
            }
            return Redirect("/Areas/Home/Index");
        }
    }
}
