using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _02ado.net中使用事务
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            string constr = "";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand("sql", con))
                    {
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "sql";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(null);
                        cmd.ExecuteNonQuery();
                    }
                    //tran.Commit();
                    tran.Rollback();
                }

            }
        }
    }
}
