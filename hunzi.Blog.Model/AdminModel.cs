using System;
using System.Collections.Generic;
using System.Text;

namespace hunzi.Blog.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class AdminModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Aid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set;}
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 账号密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 状态 默认为0 0=正常、-1=删除、1=禁用
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否为管理员账号 0=管理员、1=普通用户
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
    }
}
