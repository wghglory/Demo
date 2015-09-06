using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.Model;
using System.Data.SqlClient;

namespace Ajax.CRUD.DAL
{
    public class TblCommentsDal
    {
        public List<TblComments> GetAllComments()
        {
            List<TblComments> list = new List<TblComments>();
            string sql = "select * from TblComments";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblComments model = new TblComments();
                        model.AutoId = reader.GetInt32(0);
                        model.Title = reader.GetString(1);
                        model.Content = reader.GetString(2);
                        model.Email = reader.GetString(3);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public int Add(TblComments tblComment)
        {
            string sql = "INSERT INTO TblComments (title, content, email) output inserted.autoId VALUES (@title, @content, @email)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@title", ToDBValue(tblComment.Title)),
						new SqlParameter("@content", ToDBValue(tblComment.Content)),
						new SqlParameter("@email", ToDBValue(tblComment.Email)),
					};

            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, para);
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
