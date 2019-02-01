using System;
using System.Collections.Generic;
using System.Text;

namespace hunzi.Blog.Model
{
    public class AdminModel
    {
        public int Aid { get; set; }
        public DateTime CreateTime { get; set;}
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Remark { get; set; }
    }
}
