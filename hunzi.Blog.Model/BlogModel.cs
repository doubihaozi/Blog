using System;
using System.Collections.Generic;
using System.Text;

namespace hunzi.Blog.Model
{
    public class BlogModel
    {   
        public int Bid { get; set; }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Body_md { get; set; }
        public int ViewNum { get; set; }
        public string CaBh { get; set; }
        public string CaName { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
    }
}
