using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Student.DAL
{
    public class SQL_Helper
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        command.Dispose();
                        connection.Dispose();
                        throw;
                    }
                }
            }
        }


        public static object ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
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
                        command.Dispose();
                        connection.Dispose();
                        throw;
                    }
                }
            }
        }

        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
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
                        command.Dispose();
                        connection.Dispose();
                        throw;
                    }
                }
            }
        }

        public static SqlDataReader ExecuteReaderSp(string cmdText, params SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            {
                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        return command.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    catch (Exception)
                    {
                        command.Dispose();
                        connection.Dispose();
                        throw;
                    }
                }
            }
        }
    }
}
