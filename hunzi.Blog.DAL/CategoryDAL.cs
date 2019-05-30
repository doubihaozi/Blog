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
        public string ConnStr { get; set; }

        public CategoryDAL(string connstr)
        {
            this.ConnStr = connstr;
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        public int Insert(CategoryModel categoryModel)
        {
            using (var connection = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"insert into Category(CName,CBh,PBh,Remark) values(@CName,@CBh,@PBh,@Remark);select @@IDENTITY");
                int id = connection.Query<int>(sql, categoryModel).FirstOrDefault();
                return id;
            }
        }

        /// <summary>
        /// 查询最后一条分类列表记录
        /// </summary>
        /// <returns></returns>
        public CategoryModel GetNoeCategory()
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
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
        public bool Delete(int ID)
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"update Category set Status=-1 where Cid=@ID");
                int res = conn.Execute(sql, new { ID = ID });
                if (res > 0)
                    return true;
                else
                    return false;

            }
        }

        /// <summary>
        /// 根据ID修改分类备注以及名称
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool updateCategoru(CategoryModel model) {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"update  Category set CName=@CName,Remark=@Remark where Cid=@Cid");
                int res = conn.Execute(sql, model);
                if (res > 0)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// 查询分类名称以及备注
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CategoryModel GetNameAndRemarkById(int Id)
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"select * from Category where Cid=@Id");
                var model = conn.QueryFirstOrDefault<CategoryModel>(sql, new { Id = Id });
                return model;
            }
        }

        /// <summary>
        /// 根据编号查询分类
        /// </summary>
        /// <param name="cbh"></param>
        /// <returns></returns>
        public CategoryModel GetCategoryByBh(string cbh)
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
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
        public List<CategoryModel> CategoryList()
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"select * from Category where Status=0");
                var List = conn.Query<CategoryModel>(sql).ToList();
                return List;
            }

        }
    }
}
