using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using Itcast.Cn;
using Stu.Model;

namespace sc0802.Dal
{
    public class Aspx_NewsDal
    {

        public int Add(Aspx_News aspx_New)
        {
            string sql = "insert into Aspx_News values(@title,@content,@date,@author,@bigImg,@smallImg,@typeId)";
            SqlParameter[] pms = new SqlParameter[]
					{
						new SqlParameter("@title", ToDBValue(aspx_New.NewsTitle)),
						new SqlParameter("@content", ToDBValue(aspx_New.NewsContent)),
						new SqlParameter("@date", ToDBValue(aspx_New.NewsIssueDate)),
						new SqlParameter("@author", ToDBValue(aspx_New.NewsAuthor)),
						new SqlParameter("@bigImg", ToDBValue(aspx_New.NewsImage)),
						new SqlParameter("@smallImg", ToDBValue(aspx_New.NewsSmallImage)),
						new SqlParameter("@typeId", ToDBValue(aspx_New.NewsTypeId))
					};

            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }

        public List<Aspx_News> GetAllNews()
        {
            List<Aspx_News> list = new List<Aspx_News>();
            string sql = "select * from Aspx_news order by NewsIssueDate desc";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //NewsId, NewsTitle, NewsContent, NewsIssueDate, NewsAuthor, NewsImage, NewsSmallImage, NewsTypeId
                        Aspx_News model = new Aspx_News();
                        model.NewsId = reader.GetInt32(0);
                        model.NewsTitle = reader.GetString(1);
                        model.NewsContent = reader.GetString(2);
                        model.NewsIssueDate = reader.IsDBNull(3) ? null : (DateTime?)reader.GetDateTime(3);
                        model.NewsAuthor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        model.NewsImage = reader.IsDBNull(5) ? null : reader.GetString(5);
                        model.NewsSmallImage = reader.IsDBNull(6) ? null : reader.GetString(6);
                        model.NewsTypeId = reader.GetInt32(7);
                        list.Add(model);

                    }
                }
            }
            return list;
        }


        public List<Aspx_News> GetNewsByPage(int pageSize, int pageIndex, out int recordCount, out int pageCount)
        {
            List<Aspx_News> list = new List<Aspx_News>();
            string sql = "usp_getNewsByPage";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@pageSize",pageSize),
            new SqlParameter("@pageIndex",pageIndex),
            new SqlParameter("@recordCount",System.Data.SqlDbType.Int),
            new SqlParameter("@pagecount",System.Data.SqlDbType.Int)
            };
            pms[2].Direction = System.Data.ParameterDirection.Output;
            pms[3].Direction = System.Data.ParameterDirection.Output;

            #region MyRegion
            //执行读取操作
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.StoredProcedure, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // NewsId, 
                        //NewsTitle, 
                        //NewsIssueDate, 
                        //NewsAuthor, 
                        //NewsSmallImage,
                        //TypeName
                        Aspx_News model = new Aspx_News();
                        model.NewsId = reader.GetInt32(0);
                        model.NewsTitle = reader.GetString(1);
                        model.NewsIssueDate = reader.IsDBNull(2) ? null : (DateTime?)reader.GetDateTime(2);
                        model.NewsAuthor = reader.IsDBNull(3) ? null : reader.GetString(3);
                        model.NewsSmallImage = reader.IsDBNull(4) ? null : reader.GetString(4);
                        Aspx_Type typeModel = new Aspx_Type();
                        typeModel.TypeName = reader.IsDBNull(5) ? null : reader.GetString(5);
                        model.Aspx_TypeObject = typeModel;
                        list.Add(model);

                    }
                }
            }
            #endregion

            recordCount = Convert.ToInt32(pms[2].Value);
            pageCount = Convert.ToInt32(pms[3].Value);

            return list;

        }



        public int DeleteByNewsId(int newsId)
        {
            string sql = "delete from Aspx_News where newsId=@nid";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@nid", newsId));
        }

        public Aspx_News GetNewsModelByNewsId(int id)
        {
            Aspx_News model = null;
            string sql = "select * from Aspx_News where NewsId=@nid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@nid", id)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new Aspx_News();
                        model.NewsId = reader.GetInt32(0);
                        model.NewsTitle = reader.GetString(1);
                        model.NewsContent = reader.GetString(2);
                        model.NewsIssueDate = reader.IsDBNull(3) ? null : (DateTime?)reader.GetDateTime(3);
                        model.NewsAuthor = reader.IsDBNull(4) ? null : reader.GetString(4);
                        model.NewsImage = reader.IsDBNull(5) ? null : reader.GetString(5);
                        model.NewsSmallImage = reader.IsDBNull(6) ? null : reader.GetString(6);
                        model.NewsTypeId = reader.GetInt32(7);
                    }
                }
            }
            return model;
        }

        private object ToDBValue(object value)
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
