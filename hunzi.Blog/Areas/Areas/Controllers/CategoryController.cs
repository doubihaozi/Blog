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
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CaList = CategoryDAL.CategoryList();
            return View();
        }


        public IActionResult Add()
        {
            CategoryModel category = new CategoryModel();
            return View();
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CategoryModel category)
        {
            CategoryModel model = CategoryDAL.GetNoeCategory();
            if (category.Cid == 0)
            {
                category.CBh ="0"+(int.Parse(model.CBh) + 1).ToString();
                category.CreateDate = DateTime.Now;
                CategoryDAL.Insert(category);
            }
            return Redirect("/Areas/Category/Index");
        }
    }
}