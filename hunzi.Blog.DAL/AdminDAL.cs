using System;
using System.Collections.Generic;
using System.Text;
using hunzi.Blog.Model;
using System.Linq;
using Dapper;

namespace hunzi.Blog.DAL
{
    public class AdminDAL
    {

        public string ConnStr { get; set; }

        public AdminDAL(string connstr)
        {
            this.ConnStr = connstr;
        }
        /// <summary>
        /// 获取管理员(用户)列表
        /// </summary>
        /// <returns></returns>
        public  List<AdminModel> GetAdminList()
        {
            using (var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"select * from admin where Status=0");
                var List = conn.Query<AdminModel>(sql).ToList();
                return List;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AdminModel Login(string username, string password)
        {
            string sql = string.Format(@"select * from admin where Status=0 and UserName=@username and PassWord=@password");
            using(var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                var admin = conn.QueryFirstOrDefault<AdminModel>(sql, new { username = username, password = password });
                return admin;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int Insert(AdminModel admin)
        {
            using(var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"insert into admin(UserName,PassWord,Remark,State,Nickname) values(@UserName,@PassWord,@Remark,@State,@Nickname);select @@IDENTITY");
                var Id = conn.Query<int>(sql, admin).First();
                return Id;
            }
        }

        /// <summary>
        /// 删除该用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            using(var conn = ConnectionFactory.GetOpenconnection(ConnStr))
            {
                string sql = string.Format(@"update admin Set Status=-1 where Aid=@Id");
                int res = conn.Execute(sql, new { Id = Id });
                return res;
            }
        }


    }
}
