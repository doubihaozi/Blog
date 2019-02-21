using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using hunzi.Blog.Model;

namespace hunzi.Blog.DAL
{
    public class CategoryDAL
    {
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        public static int Insert(CategoryModel categoryModel)
        {
            using (var connection = ConnectionFactory.GetOpenconnection())
            {
                string sql =string.Format(@"insert into Category(CName,CBh,PCBh,Remark) values(@CName,@CBh,@PCBh,@Remark);select @@IDENTITY");
                int id = connection.Query<int>(sql,categoryModel).First();
                return id;
            }
        }

        /// <summary>
        /// 查询最后一条分类列表记录
        /// </summary>
        /// <returns></returns>
        public static CategoryModel GetNoeCategory()
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"select * from Category order by Cid Desc limit 1");
                var category = conn.QueryFirstOrDefault<CategoryModel>(sql);
                return category;
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"update Category set Status=-1 where Cid=@Cid");
                int res = conn.Execute(sql, ID);
                if (res > 0)
                    return true;
                else
                    return false;

            }
        }

        /// <summary>
        /// 根据编号查询分类
        /// </summary>
        /// <param name="cbh"></param>
        /// <returns></returns>
        public static CategoryModel GetCategoryByBh(string cbh)
        {
            using (var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"select * from Category where CBh=@CBh and Status=0");
                var model = conn.QueryFirstOrDefault<CategoryModel>(sql, new { cbh = cbh });
                return model;
            }
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        public static List<CategoryModel> CategoryList()
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"select * from Category where Status=0");
                var List = conn.Query<CategoryModel>(sql).ToList();
                return List;
            }
            
        }
    }
}
