using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hunzi.Blog.DAL;
using hunzi.Blog.Model;

namespace hunzi.Blog.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            string str = "";
            int id = 0;
            //id = BlogDAL.Insert(new Model.BlogModel { Title = "测试", Body = "测试内容", Body_md = string.Empty, CaBh = "01", CaName = "C#", Remark = "" });
            //id = BlogDAL.Update(new Model.BlogModel { Title = "测试2", Body = "测试内容2", CaName = "Java", Bid = 1 });
            //if(id>0)
            //{
            //    return Content("修改成功！");
            //}
            //else
            //List<BlogModel> models = BlogDAL.GetBlogList();
            //foreach (var item in models)
            //{
            //    str = $"<div>博客标题:" + item.Title + ",内容:" + item.Body + "</div>";
            //}
            return Content(str);
        }
    }
}