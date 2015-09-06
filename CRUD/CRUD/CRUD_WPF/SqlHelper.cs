using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CRUD_WPF
{
    public static class SqlHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["Student"].ConnectionString;

        ////连接字符串的作用就是告诉连接对象，要连接哪个服务器的哪个数据库，用户名是多少密码是多少
        ////Data Source="";指定 服务器Ip(计算机名)   或者  服务器\实例名

        //执行增删改的
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //封装一个执行返回单个值的方法
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //返回SqlDataReader对象的方法

        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);   //这不能using，编译try finally, connection关闭了
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    //参数System.Data.CommandBehavior.CloseConnection表示当外部调用该DataReader对象的Close()方法时，在该Close()方法内部，会自动表用与该DataReader相关联的Connection的Close()方法。
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        //封装一个返回DataTable的方法
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }

            return dt;
        }

        //封装一个带事务的执行Sql语句的方法
        public static void ExecuteNonQueryTran(List<SqlAndParameter> list)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    using (SqlTransaction trans = con.BeginTransaction())
                    {
                        cmd.Transaction = trans;
                        try
                        {
                            foreach (var SqlObject in list)
                            {
                                cmd.CommandText = SqlObject.Sql;
                                if (SqlObject.Parameters != null)
                                {
                                    cmd.Parameters.AddRange(SqlObject.Parameters);
                                }
                                cmd.CommandType = SqlObject.CmdType;
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            trans.Commit();
                        }
                        catch (Exception)
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }

    public class SqlAndParameter
    {
        public string Sql
        {
            get;
            set;
        }

        public SqlParameter[] Parameters
        {
            get;
            set;
        }

        public CommandType CmdType
        {
            get;
            set;
        }
    }
}
