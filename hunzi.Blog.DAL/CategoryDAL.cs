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
                string sql =string.Format(@"insert into Category(CaName,Bh,Pbh,Remark) values(@CaName,@Bh,@Pbh,@Remark);select @@IDENTITY");
                int id = connection.Query<int>(sql,categoryModel).First();
                return id;
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

        public static List<CategoryModel> CategoryList()
        {
            using(var conn = ConnectionFactory.GetOpenconnection())
            {
                string sql = string.Format(@"select * from Category");
                var List = conn.Query<CategoryModel>(sql).ToList();
                return List;
            }
            
        }
    }
}
