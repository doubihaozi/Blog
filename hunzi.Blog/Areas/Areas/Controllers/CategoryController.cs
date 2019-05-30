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
        
        CategoryDAL CategoryDAL;
        public CategoryController(CategoryDAL categoryDAL)
        {
            CategoryDAL = categoryDAL;
        }

        public IActionResult Index()
        {
            ViewBag.CaList = CategoryDAL.CategoryList();
            return View();
        }


        public IActionResult Add(int?Id)
        {
            CategoryModel category = new CategoryModel();
            if (Id != null)
            {
                category = CategoryDAL.GetNameAndRemarkById(Id.Value);
            }
            return View(category);
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
            else if (category.Cid != 0) {
                CategoryDAL.updateCategoru(category);
            }
            return Redirect("/Areas/Category/Index");
        }

        public IActionResult Delete(int id)
        {
            if (CategoryDAL.Delete(id))
            {
                return Content("删除成功！");
            }
            else
            {
                return Content("删除失败！请联系管理员。");
            }
        }

    }
}