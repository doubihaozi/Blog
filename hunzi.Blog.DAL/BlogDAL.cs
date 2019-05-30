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
        public string ConnStr { get; set; }

        public BlogDAL(string connstr)
        {
            this.ConnStr = connstr;
        }

        /// <summary>
        /// 添加一条博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(BlogModel model)
        {
            ///打开数据库进行操作.
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"insert into Blog(Title,Body,Body_md,CBh,CName,Remark,Sort) values(@Title,@Body,@Body_md,@CBh,@CName,@Remark,@Sort);select @@IDENTITY");
                int Id = conn.Query<int>(sql, model).FirstOrDefault();
                return Id;
            }
        }
        /// <summary>
        /// 删除某一条博客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"update Blog set Status=-1 where Bid=@Id");
                int res = conn.Execute(sql, new { Id = Id });
                return res;
            }
        }
        /// <summary>
        /// 查询所有的博客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Model.BlogModel> GetBlogList(string where = "")
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"select * from Blog where Status=0");
                if (where != "")
                {
                    sql += " " + where;
                }
                var List = conn.Query<BlogModel>(sql).ToList();
                return List;
            }
        }

        /// <summary>
        /// 统计博客数量、状态为正常的
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(string where = "")
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"select count(*) from Blog where Status=0");
                if (where != "")
                {
                    sql += " " + where;
                }
                int count = conn.ExecuteScalar<int>(sql);
                return count;
            }
        }

        /// <summary>
        /// 获取指定ID的博客
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BlogModel GetBlogModel(int Bid)
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"select * from Blog where Bid=@Bid");
                var Blog = conn.QueryFirstOrDefault<BlogModel>(sql, new { Bid = Bid });
                return Blog;
            }
        }
        /// <summary>
        /// 修改博客内容或标题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(BlogModel model)
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"update Blog set Title=@Title,Body=@Body,CName=@CName,CBh=@CBh 
                                            where Bid=@Bid");
                int res = conn.Execute(sql, model);
                return res;
            }
        }
    }
}
