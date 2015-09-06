using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using System.Data.SqlClient;
using Itcast.Cn;

namespace sc0802.Dal
{
    public class Aspx_UserDal
    {

        public Aspx_User GetUserInfo(string uid, string pwd)
        {
            Aspx_User model = null;
            string sql = "select AutoId,LoginId,LoginPwd from Aspx_Users where LoginId=@uid and LoginPwd=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",uid),
            new SqlParameter("@pwd",pwd)
            };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new Aspx_User();
                        model.AutoId = reader.GetInt32(0);
                        model.LoginId = reader.GetString(1);
                        model.LoginPwd = reader.GetString(2);
                    }
                }
            }
            return model;
        }

        public int CheckUserExists(string uid)
        {
            string sql = "select count(*) from aspx_users where loginId=@uid";
            SqlParameter pms = new SqlParameter("@uid", uid);
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pms);
        }
    }
}
