using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using System.Data.SqlClient;

namespace Stu.DAL
{
    public class MyStudentDal
    {
        //获取所有学生信息
        public List<MyStudent> GetAllStudents()
        {
            List<MyStudent> list = new List<MyStudent>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader("select 	s.fid, 	s.fname, 	s.fage, 	s.fgender, 	s.fmath, 	s.fenglish, 	s.fclassid, 	c.className, 	s.fbirthday from MyStudent as s inner join myclass as c on s.fclassid=c.classid"))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyStudent model = new MyStudent();
                        model.Fid = reader.GetInt32(0);
                        model.FName = reader.GetString(1);
                        model.FAge = reader.GetInt32(2);
                        model.FGender = reader.GetString(3);
                        model.FMath = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        model.FEnglish = reader.GetInt32(5);
                        model.Class = new MyClass() { ClassId = reader.GetInt32(6), ClassName = reader.GetString(7) };
                        model.FBirthday = reader.GetDateTime(8);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        //增加一条记录
        public int Add(MyStudent model)
        {
            string sql = "insert into MyStudent(FName, FAge, FGender, FMath, FEnglish, FClassId, FBirthday) values(@name,@age,@gender,@math,@english,@classid,@birthday)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",model.FName),
            new SqlParameter("@age",model.FAge),
            new SqlParameter("@gender",model.FGender),
            new SqlParameter("@math",model.FMath==null?DBNull.Value:(object)model.FMath),
            new SqlParameter("@english",model.FEnglish),
            new SqlParameter("@classid",model.Class.ClassId),
            new SqlParameter("@birthday",model.FBirthday)
            };
            return SqlHelper.ExecuteNonQuery(sql, pms);
        }


        //根据主键Id获取某条记录的信息
        public MyStudent GetStudentInfoById(int id)
        {
            MyStudent model = null;

            string sql = "select * from MyStudent where fid=@id";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id", (object)id)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        //Fid, FName, FAge, FGender, FMath, FEnglish, FClassId, FBirthday
                        model = new MyStudent();
                        model.Fid = reader.GetInt32(0);
                        model.FName = reader.GetString(1);
                        model.FAge = reader.GetInt32(2);
                        model.FGender = reader.GetString(3);
                        model.FMath = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        model.FEnglish = reader.GetInt32(5);
                        model.Class = new MyClass() { ClassId = reader.GetInt32(6) };
                        model.FBirthday = reader.GetDateTime(7);
                    }
                }
            }
            return model;
        }


        //更新一条数据
        public int Update(MyStudent model)
        {
            //FName, FAge, FGender, FMath, FEnglish, FClassId, FBirthday
            string sql = "update MyStudent set fname=@name,Fage=@age,fgender=@gender,fmath=@math,fenglish=@english,fclassid=@classid,fbirthday=@birthday where fid=@id";

            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",model.FName),
            new SqlParameter("@age",model.FAge),
            new SqlParameter("@gender",model.FGender),
            new SqlParameter("@math",model.FMath==null?DBNull.Value:(object)model.FMath),
            new SqlParameter("@english",model.FEnglish),
            new SqlParameter("@classid",model.Class.ClassId),
            new SqlParameter("@birthday",model.FBirthday),
            new SqlParameter("@id",model.Fid)
            };
            return SqlHelper.ExecuteNonQuery(sql, pms);
        }

        //根据主键Id删除一条数据

        public int Delete(int id)
        {
            string sql = "delete from MyStudent where fid=@id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));
        }

        public List<MyStudent> SearchData(List<Condition> listWhere)
        {
            List<MyStudent> list = new List<MyStudent>();
            StringBuilder sbSql = new StringBuilder("select 	s.fid, 	s.fname, 	s.fage, 	s.fgender, 	s.fmath, 	s.fenglish, 	s.fclassid, 	c.className, 	s.fbirthday from MyStudent as s inner join myclass as c on s.fclassid=c.classid");
            List<string> wheres = new List<string>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (var item in listWhere)
            {
                switch (item.Operation)
                {
                    case Opt.Equal:
                        wheres.Add(item.PropertyName + " = @" + item.PropertyName);
                        break;
                    case Opt.NotEqual:
                        wheres.Add(item.PropertyName + " <> @" + item.PropertyName);
                        break;
                    case Opt.GreaterThan:
                        wheres.Add(item.PropertyName + " > @" + item.PropertyName);
                        break;
                    case Opt.LessThan:
                        wheres.Add(item.PropertyName + " < @" + item.PropertyName);
                        break;
                    case Opt.Like:
                        wheres.Add(item.PropertyName + " like @" + item.PropertyName);
                        item.Value = item.Value + "%";
                        break;
                }

                parameters.Add(new SqlParameter("@" + item.PropertyName, item.Value));
            }
            if (wheres.Count > 0)
            {
                sbSql.Append(" where ");
                sbSql.Append(string.Join(" and ", wheres.ToArray()));
            }
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sbSql.ToString(), parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyStudent model = new MyStudent();
                        model.Fid = reader.GetInt32(0);
                        model.FName = reader.GetString(1);
                        model.FAge = reader.GetInt32(2);
                        model.FGender = reader.GetString(3);
                        model.FMath = reader.IsDBNull(4) ? null : (int?)reader.GetInt32(4);
                        model.FEnglish = reader.GetInt32(5);
                        model.Class = new MyClass() { ClassId = reader.GetInt32(6), ClassName = reader.GetString(7) };
                        model.FBirthday = reader.GetDateTime(8);
                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
