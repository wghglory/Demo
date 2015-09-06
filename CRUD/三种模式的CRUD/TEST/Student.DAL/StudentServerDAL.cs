using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;

namespace Student.DAL
{
    public class StudentServerDAL : IBaseDAL.IStudentDAL
    {

        public Model.StudentsModel GetModel(int sid)
        {
            StudentsModel model = null;
            const string strSql = "select SId, SName, SAge, SEmail, SBirthday, SGender from T_Students where SId=@sid";
            using (SqlDataReader reader = SQL_Helper.ExecuteReader(strSql, new SqlParameter("@sid", sid)))
            {
                if (reader.HasRows)
                {
                    int sIdIndex = reader.GetOrdinal("SId");
                    int sNameInex = reader.GetOrdinal("SName");
                    int sAgeIndex = reader.GetOrdinal("SAge");
                    int sEmailIndex = reader.GetOrdinal("SEmail");
                    int sBirthdayIndex = reader.GetOrdinal("SBirthday");
                    int sGenderIndex = reader.GetOrdinal("SGender");

                    if (reader.Read())
                    {
                        model = new StudentsModel
                            {
                                SId = reader.GetInt32(sIdIndex),
                                SName = reader.GetString(sNameInex),
                                SAge = reader.GetInt32(sAgeIndex),
                                SEmail = reader.GetString(sEmailIndex),
                                SBirthday = reader.GetDateTime(sBirthdayIndex),
                                SGender = reader.GetString(sGenderIndex)
                            };
                    }

                }
            }
            return model;
        }
        public int Delete(int Sid)
        {
            const string strSql = "delete T_Students where SId = @SId";

            return SQL_Helper.ExecuteNonQuery(strSql, new SqlParameter("@SId", Sid));
        }

        public int Add(Model.StudentsModel model)
        {

            const string strSql =
                "insert into T_Students (SName , SAge, SEmail, SBirthday, SGender) values(@SName, @SAge, @SEmail, @SBirthday, @SGender)";
            SqlParameter[] parameters =
                {
                    new SqlParameter("@SName",model.SName),
                     new SqlParameter("@SAge",model.SAge),
                      new SqlParameter("@SEmail",model.SEmail),
                       new SqlParameter("@SBirthday",model.SBirthday),
                        new SqlParameter("@SGender",model.SGender)
                };


            return SQL_Helper.ExecuteNonQuery(strSql, parameters);
        }

        public int Update(Model.StudentsModel model)
        {
            const string strSql =
                "update T_Students set SName = @SName, SAge = @SAge, SEmail = @SEmail, SBirthday = @SBirthday, SGender = @SGender where SId = @SId";


            SqlParameter[] parameters =
                {
                    new SqlParameter("@SName",model.SName),
                     new SqlParameter("@SAge",model.SAge),
                      new SqlParameter("@SEmail",model.SEmail),
                       new SqlParameter("@SBirthday",model.SBirthday),
                        new SqlParameter("@SGender",model.SGender),
                         new SqlParameter("@SId",model.SId)
                };


            return SQL_Helper.ExecuteNonQuery(strSql, parameters);
        }

        public List<Model.StudentsModel> GetList(int pageSize, int pageIndex)
        {

            List<Model.StudentsModel> list = new List<StudentsModel>();
            using (SqlDataReader reader = SQL_Helper.ExecuteReaderSp("Usp_PageStudent", new SqlParameter("@pageIndex", pageIndex), new SqlParameter("@pageSize", pageSize)))
            {
                if (reader.HasRows)
                {
                    int sIdIndex = reader.GetOrdinal("SId");
                    int sNameInex = reader.GetOrdinal("SName");
                    int sAgeIndex = reader.GetOrdinal("SAge");
                    int sEmailIndex = reader.GetOrdinal("SEmail");
                    int sBirthdayIndex = reader.GetOrdinal("SBirthday");
                    int sGenderIndex = reader.GetOrdinal("SGender");

                    while (reader.Read())
                    {
                        Model.StudentsModel model = new StudentsModel
                            {
                                SId = reader.GetInt32(sIdIndex),
                                SName = reader.GetString(sNameInex),
                                SAge = reader.GetInt32(sAgeIndex),
                                SEmail = reader.GetString(sEmailIndex),
                                SBirthday = reader.GetDateTime(sBirthdayIndex),
                                SGender = reader.GetString(sGenderIndex)
                            };

                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public int GetDataAllCount()
        {
            const string strSql = "select count([SId]) from T_Students";
            return (int)SQL_Helper.ExecuteScalar(strSql);
        }
    }
}
