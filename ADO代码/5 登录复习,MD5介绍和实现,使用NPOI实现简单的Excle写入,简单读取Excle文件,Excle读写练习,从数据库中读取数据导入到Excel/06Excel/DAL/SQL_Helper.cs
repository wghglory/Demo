using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Homework.DAL;

namespace Alian_SQL_Helper
{
    public static class SQL_Helper
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public static int ExecuteNonquery(string comText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(comText, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    cmd.CommandType = commandType;
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        return cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        conn.Close();
                        cmd.Dispose();
                        throw;
                    }

                }
            }
        }
        public static object ExecuteScalar(string cmdText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.CommandType = commandType;
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        return command.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        command.Dispose();
                        throw new Exception();
                    }
                }
            }
        }
        public static SqlDataReader ExecuteReader(string cmdText, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(cmdText, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                command.CommandType = commandType;
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    connection.Close();
                    command.Dispose();
                    throw new Exception();
                }
            }
        }

        public static bool ExecuteTran(List<SqlAndParamrter> list)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    //打开连接
                    connection.Open();
                    //创建事务
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        command.Transaction = transaction;
                        try
                        {
                            //遍历Sql 语句和参数,执行方式
                            foreach (SqlAndParamrter sqlAndParamrter in list)
                            {
                                //得到Sql语句
                                command.CommandText = sqlAndParamrter.Sql;
                                //得到执行方式
                                command.CommandType = sqlAndParamrter.commandType;
                                //添加参数
                                if (sqlAndParamrter.Parameters != null)
                                {
                                    command.Parameters.AddRange(sqlAndParamrter.Parameters);
                                }
                                //执行
                                command.ExecuteNonQuery();
                                //清空参数
                                command.Parameters.Clear();
                            }
                            //提交事务
                            transaction.Commit();
                            result = true;
                        }
                        catch (Exception)
                        {
                            //回滚事务
                            transaction.Rollback();
                            connection.Close();
                            connection.Dispose();
                            command.Dispose();
                            throw;
                        }
                    }
                }
            }
            return result;
        }
    }
    public class SqlAndParamrter
    {
        /// <summary>
        /// SQL语句
        /// </summary>
        public string Sql { get; set; }
        /// <summary>
        /// 参数化查询参数列表集合
        /// </summary>
        public SqlParameter[] Parameters { get; set; }
        /// <summary>
        /// 执行方式
        /// </summary>
        public CommandType commandType { get; set; }
    }
}
