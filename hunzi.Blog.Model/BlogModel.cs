using System;
using System.Collections.Generic;
using System.Text;

namespace hunzi.Blog.Model
{
    /// <summary>
    /// 博客表
    /// </summary>
    public class BlogModel
    {   
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Bid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// （暂无用处）
        /// </summary>
        public string Body_md { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int ViewNums { get; set; }
        /// <summary>
        /// 分类编号
        /// </summary>
        public string CBh { get; set; }
        /// <summary>
        /// 分类父级编号（暂无用处）
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态 默认为0 0=正常、-1=删除、1=禁用
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 添加者ID
        /// </summary>
        public int Aid { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
