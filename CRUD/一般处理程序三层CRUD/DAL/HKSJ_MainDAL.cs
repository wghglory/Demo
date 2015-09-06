//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GeneralHandler.Model;

namespace GeneralHandler.DAL
{
	public partial class HKSJ_MainDAL
	{
        public HKSJ_Main Add(HKSJ_Main hKSJ_Main)
		{
				string sql ="INSERT INTO HKSJ_Main (title, content, type, Date, people, picUrl)  output inserted.ID VALUES (@title, @content, @type, @Date, @people, @picUrl)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@title", ToDBValue(hKSJ_Main.Title)),
						new SqlParameter("@content", ToDBValue(hKSJ_Main.Content)),
						new SqlParameter("@type", ToDBValue(hKSJ_Main.Type)),
						new SqlParameter("@Date", ToDBValue(hKSJ_Main.Date)),
						new SqlParameter("@people", ToDBValue(hKSJ_Main.People)),
						new SqlParameter("@picUrl", ToDBValue(hKSJ_Main.PicUrl)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetByID(newId);
		}

        public int DeleteByID(int iD)
		{
            string sql = "DELETE HKSJ_Main WHERE ID = @ID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
						
        public int Update(HKSJ_Main hKSJ_Main)
        {
            string sql =
                "UPDATE HKSJ_Main " +
                "SET " +
			" title = @title" 
                +", Content = @Content" 
                +", Type = @Type" 
                +", Date = @Date" 
                +", People = @People" 
                +", PicUrl = @PicUrl" 
               
            +" WHERE ID = @ID";

			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", hKSJ_Main.ID)
					,new SqlParameter("@Title", ToDBValue(hKSJ_Main.Title))
					,new SqlParameter("@Content", ToDBValue(hKSJ_Main.Content))
					,new SqlParameter("@Type", ToDBValue(hKSJ_Main.Type))
					,new SqlParameter("@Date", ToDBValue(hKSJ_Main.Date))
					,new SqlParameter("@People", ToDBValue(hKSJ_Main.People))
					,new SqlParameter("@PicUrl", ToDBValue(hKSJ_Main.PicUrl))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public HKSJ_Main GetByID(int iD)
        {
            string sql = "SELECT * FROM HKSJ_Main WHERE ID = @ID";
            using(SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@ID", iD)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public HKSJ_Main ToModel(SqlDataReader reader)
		{
			HKSJ_Main hKSJ_Main = new HKSJ_Main();

			hKSJ_Main.ID = (int)ToModelValue(reader,"ID");
			hKSJ_Main.Title = (string)ToModelValue(reader,"title");
			hKSJ_Main.Content = (string)ToModelValue(reader,"content");
			hKSJ_Main.Type = (string)ToModelValue(reader,"type");
			hKSJ_Main.Date = (DateTime)ToModelValue(reader,"Date");
			hKSJ_Main.People = (string)ToModelValue(reader,"people");
			hKSJ_Main.PicUrl = (string)ToModelValue(reader,"picUrl");
			return hKSJ_Main;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM HKSJ_Main";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<HKSJ_Main> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<HKSJ_Main>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by ID) rownum FROM HKSJ_Main) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public IEnumerable<HKSJ_Main> GetAll()
		{
			var list = new List<HKSJ_Main>();
			string sql = "SELECT * FROM HKSJ_Main";
			using(SqlDataReader reader = SqlHelper.ExecuteReader(sql))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		public object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
}