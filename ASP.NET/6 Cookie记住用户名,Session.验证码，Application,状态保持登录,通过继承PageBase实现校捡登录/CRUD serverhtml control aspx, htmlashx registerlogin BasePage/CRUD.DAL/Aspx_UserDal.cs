using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using Itcast.Cn;
using System.Data.SqlClient;

namespace CRUD.DAL
{
    public class Aspx_UserDal
    {
        public Aspx_User GetUserModelByUidPwd(string uid, string pwd)
        {
            Aspx_User model = null;
            string sql = "select * from Aspx_Users where LoginId=@uid and LoginPwd=@pwd";
            SqlParameter[] pms = new SqlParameter[]{
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
                    }
                }
            }
            return model;
        }
    }
}
