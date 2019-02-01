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
        public static DbConnection GetOpenconnection()
        {
            //var connection = new SqlConnection("server=47.107.124.51;uid=root;pwd=123456;database=BlogCore;");
            var conn = new MySqlConnection("server=47.107.124.51;user id=root;password=123456;pooling=true;Charset=utf8;database=BlogCore;");
            //connection.Open();
            conn.Open();
            return conn;
            //return cconnection;
        }
    }
}
