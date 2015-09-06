using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Itcast.Cn;
using CRUD.Model;

namespace CRUD.DAL
{
    public class UsersDal
    {
        public int CheckUserLogin(string loginId, string loginPwd)
        {
            string sql = "select count(*) from Users where loginId=@uid and loginPwd=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",loginId),
            new SqlParameter("@pwd",loginPwd)
            };
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pms);


        }
        public int Add(Users model)
        {
            string sql = "insert into Users(loginId,loginpwd) values(@uid,@pwd)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",model.LoginId),
            new SqlParameter("@pwd",model.LoginPwd)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }

        public List<Users> GetAllUsers()
        {
            List<Users> list = new List<Users>();
            string sql = "select autoId,loginId,loginPwd from Users";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Users model = new Users();
                        model.AutoId = reader.GetInt32(0);
                        model.LoginId = reader.GetString(1);
                        model.LoginPwd = reader.GetString(2);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public int Delete(int autoId)
        {
            string sql = "delete from Users where autoId=@autoId";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@autoId", autoId));
        }

        public Users GetUserInfoByAutoId(int autoid)
        {
            Users model = null;
            string sql = "select * from Users where autoId=@autoid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@autoId", autoid)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new Users();
                        model.AutoId = reader.GetInt32(0);
                        model.LoginId = reader.GetString(1);
                        model.LoginPwd = reader.GetString(2);
                        model.LastLoginTime = reader.GetDateTime(4);
                        model.ErrorCount = reader.GetInt32(3);
                    }
                }
            }
            return model;
        }

        public int Update(Users model)
        {
            //autoId, loginId, loginPwd, ErrorCount, LastLoginTime
            string sql = "update Users set loginId=@uid,loginPwd=@pwd,ErrorCount=@count,LastLoginTime=@date where autoId=@id";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",model.LoginId),
            new SqlParameter("@pwd",model.LoginPwd),
            new SqlParameter("@count",model.ErrorCount),
            new SqlParameter("@date",model.LastLoginTime),
            new SqlParameter("@id",model.AutoId)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
    }
}
