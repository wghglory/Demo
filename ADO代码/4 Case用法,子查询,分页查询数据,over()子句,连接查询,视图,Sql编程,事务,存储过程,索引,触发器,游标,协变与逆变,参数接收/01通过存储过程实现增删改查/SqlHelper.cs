using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace _01通过存储过程实现增删改查
{
    public static class SqlHelper
    {
        private static readonly string constr = "";

        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
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
    }

    //SqlParameter[] pms = new SqlParameter[] { };

    //        pms[0].Direction = System.Data.ParameterDirection.Output;


    //        SqlHelper.ExecuteNonQuery("aaaa", System.Data.CommandType.StoredProcedure, pms);

    //        pms[0].Value;
}
