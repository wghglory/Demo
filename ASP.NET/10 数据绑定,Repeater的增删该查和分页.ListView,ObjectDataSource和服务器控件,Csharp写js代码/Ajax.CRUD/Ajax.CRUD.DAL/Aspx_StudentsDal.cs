using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.Model;
using System.Data.SqlClient;

namespace Ajax.CRUD.DAL
{
    public class Aspx_StudentsDal
    {
        public List<Aspx_Students> GetAllStudents()
        {
            List<Aspx_Students> list = new List<Aspx_Students>();
            string sql = "select * from Aspx_Students";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //stuId, stuName, stuAge, stuGender, stuEmail, stuBirthday
                        Aspx_Students model = new Aspx_Students();
                        model.StuId = reader.GetInt32(0);
                        model.StuName = reader.GetString(1);
                        model.StuAge = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        model.StuGender = reader.GetString(3);
                        model.StuEmail = reader.GetString(4);
                        model.StuBirthday = reader.GetDateTime(5);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="recordcount"></param>
        /// <param name="pagecount"></param>
        /// <returns></returns>
        public List<Aspx_Students> GetStudentsByPage(int pagesize, int pageindex, out int recordcount, out int pagecount)
        {
            List<Aspx_Students> list = new List<Aspx_Students>();
            string sql = "usp_GetSutdentsByPage";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@pagesize",pagesize),
            new SqlParameter("@pageIndex",pageindex),
            new SqlParameter("@recordCount",System.Data.SqlDbType.Int),
            new SqlParameter("@pagecount",System.Data.SqlDbType.Int)
            };
            pms[2].Direction = System.Data.ParameterDirection.Output;
            pms[3].Direction = System.Data.ParameterDirection.Output;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.StoredProcedure, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Aspx_Students model = new Aspx_Students();
                        model.StuId = reader.GetInt32(0);
                        model.StuName = reader.GetString(1);
                        model.StuAge = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        model.StuGender = reader.GetString(3);
                        model.StuEmail = reader.GetString(4);
                        model.StuBirthday = reader.GetDateTime(5);
                        list.Add(model);

                    }
                }
            }
            recordcount = Convert.ToInt32(pms[2].Value);
            pagecount = Convert.ToInt32(pms[3].Value);
            return list;

        }

        public List<Aspx_Students> GetStudentsBetweentAnd(int startNumber, int maxRows)
        {
            List<Aspx_Students> list = new List<Aspx_Students>();
            string sql = "select * from 	(select *,rn=row_number() over(order by stuId) from Aspx_Students) as t 	where t.rn between @sn+1 and @sn+@en+1";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@sn",startNumber),
            new SqlParameter("@en",maxRows)
            };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Aspx_Students model = new Aspx_Students();
                        model.StuId = reader.GetInt32(0);
                        model.StuName = reader.GetString(1);
                        model.StuAge = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        model.StuGender = reader.GetString(3);
                        model.StuEmail = reader.GetString(4);
                        model.StuBirthday = reader.GetDateTime(5);
                        list.Add(model);
                    }
                }
            }
            return list;

        }


        public Aspx_Students GetStudentInfoBySid(int sid)
        {
            Aspx_Students model = null;
            string sql = "select * from Aspx_Students where StuId=@sid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@sid", sid)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new Aspx_Students();
                        model.StuId = reader.GetInt32(0);
                        model.StuName = reader.GetString(1);
                        model.StuAge = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        model.StuGender = reader.GetString(3);
                        model.StuEmail = reader.GetString(4);
                        model.StuBirthday = reader.GetDateTime(5);
                    }
                }
            }
            return model;

        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="aspx_Student"></param>
        /// <returns></returns>
        public int Add(Aspx_Students aspx_Student)
        {
            string sql = "INSERT INTO Aspx_Students (stuName, stuAge, stuGender, stuEmail, stuBirthday) VALUES (@stuName, @stuAge, @stuGender, @stuEmail, @stuBirthday)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@stuName", ToDBValue(aspx_Student.StuName)),
						new SqlParameter("@stuAge", ToDBValue(aspx_Student.StuAge)),
						new SqlParameter("@stuGender", ToDBValue(aspx_Student.StuGender)),
						new SqlParameter("@stuEmail", ToDBValue(aspx_Student.StuEmail)),
						new SqlParameter("@stuBirthday", ToDBValue(aspx_Student.StuBirthday)),
					};

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, para);
        }

        //删除一条记录
        public int DeleteByStuId(int stuId)
        {
            string sql = "DELETE from Aspx_Students WHERE StuId = @StuId";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@stuId", stuId));
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="aspx_Student"></param>
        /// <returns></returns>
        public int Update(Aspx_Students aspx_Student)
        {
            string sql = "UPDATE Aspx_Students SET  stuName = @stuName, StuAge = @StuAge, StuGender = @StuGender, StuEmail = @StuEmail, StuBirthday = @StuBirthday WHERE stuId = @stuId";
            SqlParameter[] para = new SqlParameter[]{
            new SqlParameter("@stuId", aspx_Student.StuId),
            new SqlParameter("@StuName", ToDBValue(aspx_Student.StuName)),
            new SqlParameter("@StuAge", ToDBValue(aspx_Student.StuAge)),
            new SqlParameter("@StuGender", ToDBValue(aspx_Student.StuGender)),
            new SqlParameter("@StuEmail", ToDBValue(aspx_Student.StuEmail)),
            new SqlParameter("@StuBirthday", ToDBValue(aspx_Student.StuBirthday))
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, para);
        }

        //获取表中的总记录条数
        public int GetTotalCount()
        {
            string sql = "select count(*) from Aspx_Students";
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text);
        }



        public object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
    }
}
