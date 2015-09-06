using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace UserLogin.DAL
{
    public static class SqlHepler
    {
        private static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        public static int ExecuteNonQuery(string sql, params SqlParameter[] pmt)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pmt != null)
                    {
                        cmd.Parameters.AddRange(pmt);
                    }

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public static object ExecuteScalar(string sql, params SqlParameter[] pmt)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pmt != null)
                    {
                        cmd.Parameters.AddRange(pmt);
                    }

                    con.Open();
                    return cmd.ExecuteScalar();
                }

            }
        }


        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pmt)
        {
            SqlConnection con = new SqlConnection(constr);

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pmt != null)
                {
                    cmd.Parameters.AddRange(pmt);
                }

                try
                {
                    con.Open();
                    return cmd.ExecuteReader();
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }
    }
}

