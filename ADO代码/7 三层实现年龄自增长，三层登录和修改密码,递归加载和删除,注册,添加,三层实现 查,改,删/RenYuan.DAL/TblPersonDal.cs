using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RenYuan.Model;
using System.Data.SqlClient;
using Itcast.Cn;

namespace RenYuan.DAL
{
    public class TblPersonDal
    {
        public int Add(TblPerson model)
        {
            string sql = "insert into TblPerson(uname,age,height,gender) values(@name,@age,@height,@gender)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",model.Name),
            new SqlParameter("@age",model.Age),
            new SqlParameter("@height",model.Height==null?DBNull.Value:(object)model.Height),
            new SqlParameter("@gender",model.Gender==null?DBNull.Value:(object)model.Gender)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }


        public List<TblPerson> GetAllData()
        {
            List<TblPerson> list = new List<TblPerson>();
            string sql = "select * from TblPerson";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //autoId, uName, age, height, gender
                        TblPerson model = new TblPerson();
                        model.AutoId = reader.GetInt32(0);
                        model.Name = reader.GetString(1);
                        model.Age = reader.GetInt32(2);
                        model.Height = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                        model.Gender = reader.IsDBNull(4) ? null : (bool?)reader.GetBoolean(4);
                        list.Add(model);
                    }
                }
            }
            return list;

        }

        public int DeleteByAutoId(int autoId)
        {
            string sql = "delete from TblPerson where autoId=@autoid";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@autoid", autoId));
        }

        public int UpdateByAutoId(TblPerson model)
        {
            string sql = "update TblPerson set uname=@name,age=@age,height=@height,gender=@gender where autoid=@autoId";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",model.Name),
            new SqlParameter("@age",model.Age),
            new SqlParameter("@height",model.Height==null?DBNull.Value:(object)model.Height),
            new SqlParameter("@gender",model.Gender==null?DBNull.Value:(object)model.Gender),
            new SqlParameter("@autoId",model.AutoId)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
    }
}
