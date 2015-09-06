using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01三层.Model;
using Itcast.Cn;
using System.Data.SqlClient;

namespace _01三层.DAL
{
    public class T_SeatsDal
    {
        public T_Seats GetUserInfoByLoginId(string loginId)
        {
            T_Seats model = null;
            string sql = "select cc_autoId,cc_loginPassword,cc_username from T_Seats where CC_LoginId=@uid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@uid", loginId)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new T_Seats();
                        model.AutoId = reader.GetInt32(0);
                        model.Password = reader.GetString(1);
                        model.UserName = reader.GetString(2);
                    }
                }
            }
            return model;
        }

        public int CheckOldPassword(int autoId, string oldPwd)
        {
            string sql = "select count(*) from T_Seats where cc_autoId=@autoid and cc_loginPassword=@oldPwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@autoid",autoId),
            new SqlParameter("@oldPwd",oldPwd)
            };
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pms);
        }

        public int UpdatePassword(int autoId, string newPwd)
        {
            string sql = "update T_Seats set cc_loginPassword=@pwd where cc_autoId=@autoid";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@autoid",autoId),
            new SqlParameter("@pwd",newPwd)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }


        public int Add(T_Seats model)
        {
            string sql = "insert into T_Seats(CC_LoginId,CC_LoginPassword,CC_UserName) output inserted.CC_Autoid values(@loginId,@pwd,@name)";

            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@loginId",model.CC_LoginId),
            new SqlParameter("@pwd",model.Password),
            new SqlParameter("@name",model.UserName)
            };
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pms);
        }

        //select count(*) from T_Seats where cc_loginId=@loginid
        //检查用户名是否存在！
        public int CheckLoginIdExists(string loginId)
        {
            string sql = "select count(*) from T_Seats where cc_loginId=@loginid";
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new SqlParameter("@loginid", loginId));
        }
    }
}
