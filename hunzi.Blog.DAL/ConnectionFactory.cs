using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace hunzi.Blog.DAL
{
    /// <summary>
    /// 数据库库连接工厂
    /// </summary>
    public class ConnectionFactory
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="ConnStr"></param>
        /// <returns></returns>
        public static DbConnection GetOpenconnection(string ConnStr)
        {
            //var connection = new SqlConnection("server=;uid=root;pwd=;database=;");
            var conn = new MySqlConnection(ConnStr);
            //connection.Open();
            conn.Open();
            return conn;
            //return cconnection;
        }
    }
}
