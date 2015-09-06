using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EasyUI
{
    public static class SqlHelper
    {       

        public static readonly string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        //执行增删改的
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connstr))
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

        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        //封装一个执行返回单个值的方法
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connstr))
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

        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            return ExecuteScalar(sql, CommandType.Text, pms);
        }

        //返回SqlDataReader对象的方法

        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(connstr);
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
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            return ExecuteReader(sql, CommandType.Text, pms);
        }


        //封装一个返回DataTable的方法
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connstr))
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

        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            return ExecuteDataTable(sql, CommandType.Text, pms);
        }

        //封装一个带事务的执行Sql语句的方法
        public static void ExecuteNonQueryTran(List<SqlAndParameter> list)
        {
            using (SqlConnection con = new SqlConnection(connstr))
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