using System;
using System.Collections.Generic;
using System.Text;

namespace hunzi.Blog.Model
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 分类编号
        /// </summary>
        public string CBh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pbh { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 状态 默认为0 0=正常、-1=删除、1=禁用
        /// </summary>
        public int Status { get; set; }
    }
}
