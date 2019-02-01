using System.Linq;
using hunzi.Blog.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace hunzi.Blog.DAL
{
    public class BlogDAL
    {
        /// <summary>
        /// 添加一条博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Insert(BlogModel model)
        {
            ///打开数据库进行操作.
            using (var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"insert into Blog(Title,Body,Body_md,CaBh,CaName,Remark,Sort) values(@Title,@Body,@Body_md,@CaBh,@CaName,@Remark,@Sort);select @@IDENTITY");
                int Id = conn.Query<int>(sql, model).First();
                return Id;
            }
        }
        /// <summary>
        /// 删除某一条博客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static int Delete(int Id)
        {
            using (var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"delete from Blog where Bid=@Id");
                int res = conn.Execute(sql,new { Id = Id });
                return res;
            }
        }
        /// <summary>
        /// 查询所有的博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Model.BlogModel> GetBlog(BlogModel model)
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"select * from Blog");
                if (!string.IsNullOrEmpty(model.Title))
                {
                    sql +=" "+" where Title=@Title";
                }
                if (!string.IsNullOrEmpty(model.CaName))
                {
                    sql +=" "+"where CaName=@CaName";
                }
                var List = conn.Query<BlogModel>(sql,model).ToList();
                return List;
            }
        }

        /// <summary>
        /// 获取指定ID的博客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static BlogModel GetBlogModel(int Bid)
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"select * from Blog where Bid=@Bid");
                var Blog = conn.QueryFirst<BlogModel>(sql,new { Bid =Bid});
                return Blog;
            }
        }
        /// <summary>
        /// 修改博客内容或标题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Update(BlogModel model)
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"update Blog set Title=@Title,Body=@Body,CaName=@CaName where Bid=@Bid");
                int res = conn.Execute(sql, model);
                return res;
            }
        }
    }
}
