using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.DAL
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


        //检查用户名是否存在
        public int CheckUserExists(string loginId)
        {
            string sql = "select count(*) from Aspx_Users where LoginId=@uid ";
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new SqlParameter("@uid", loginId));
        }
    }
}
