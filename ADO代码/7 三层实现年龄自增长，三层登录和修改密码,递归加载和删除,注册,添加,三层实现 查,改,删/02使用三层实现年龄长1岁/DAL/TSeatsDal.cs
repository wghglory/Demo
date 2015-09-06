using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Itcast.Cn;
using _08使用三层实现年龄长1岁.Model;

namespace _08使用三层实现年龄长1岁.DAL
{
    //操作T_Seats表的数据访问层类
    public class TSeatsDal
    {
        public int ValidUserLogin(string loginId, string password)
        {
            string sql = "select count(*) from T_Seats where cc_loginId=@uid and cc_loginPassword=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",loginId),
            new SqlParameter("@pwd",password)
            };
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pms);
        }


        public T_Seat GetUserInfoByLoginId(string loginId)
        {
            T_Seat model = null;
            string sql = "select cc_autoId,cc_loginPassword,cc_userName from T_Seats where cc_loginId=@uid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@uid", loginId)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new T_Seat();
                        model.CC_AutoId = reader.GetInt32(0);
                        model.CC_LoginPassword = reader.GetString(1);
                        model.CC_UserName = reader.GetString(2);
                    }
                }
            }

            return model;
        }
    }
}
