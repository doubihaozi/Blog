using System;
using System.Collections.Generic;
using System.Text;

namespace hunzi.Blog.Model
{
    public class CategoryModel
    {
        public int Cid { get; set; }
        public DateTime CreateDate { get; set; }
        public string CaName { get; set; }
        public string Bh { get; set; }
        public string Pbh { get; set; }
        public string Remark { get; set; }
    }
}
