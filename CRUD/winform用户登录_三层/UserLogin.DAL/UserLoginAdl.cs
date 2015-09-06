using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin.DAL
{
    public class UserLoginAdl
    {
        /// <summary>
        /// 根据用户名查找用户信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public Users GetUsersData(string loginId)
        {
            Users us = null;
            string sql = "select * from Users where UsersName=@loginId";
            using (SqlDataReader read = SqlHepler.ExecuteReader(sql, new SqlParameter("@loginId", loginId)))
            {

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        us = new Users();
                        us.ID = read.GetInt32(0);
                        us.UsersName = read.GetString(1);
                        us.Pwd = read.GetString(2);
                    }
                }
            }

            return us;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="loginPwd"></param>
        /// <returns></returns>
        public int ChangePassword(int loginId, string loginPwd)
        {
            string sql = "update  Users set Pwd=@NewLoginPwd where ID=@loginId";
            SqlParameter[] pmt = {
                                     new SqlParameter("@NewLoginPwd",loginPwd),
                                     new SqlParameter("@loginId",loginId)
                                 };

           return  SqlHepler.ExecuteNonQuery(sql, pmt);
        }

        /// <summary>
        /// 验证旧密码是否输入正确
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetOldPasswordIsError(int Id, string password)
        {
            string sql = "select count(*) from Users where ID=@id and Pwd=@password";
            SqlParameter[] pmt = {
                                     new SqlParameter("@id",Id),
                                     new SqlParameter("@password",password)
                                 };

            return (int)SqlHepler.ExecuteScalar(sql, pmt);
        }

    }
}
