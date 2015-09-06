using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace _06自己封装一个SqlHelper
{
    public static class SqlHelper
    {
        //private static readonly string conStr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";

        //通过读取配置文件来获取连接字符串
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["sqlConnStr"].ConnectionString;

        //insert、delete、update
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //可变参数pms如果用户不传递的时候，是一个长度为0的数组。不是null。
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        //返回单个值的
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //可变参数pms如果用户不传递的时候，是一个长度为0的数组。不是null。
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }


        //select 查询多行多列,调用ExecuteReader()来实现
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    //参数System.Data.CommandBehavior.CloseConnection表示当外部调用该DataReader对象的Close()方法时，在该Close()方法内部，会自动表用与该DataReader相关联的Connection的Close()方法。
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    //这里的关闭不要写在finally中，因为需要return 一个SqlDataReader
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        //封装返回DataTable
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
