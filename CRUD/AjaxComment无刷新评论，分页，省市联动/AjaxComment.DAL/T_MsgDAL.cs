//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AjaxComment.Model;

namespace AjaxComment.DAL
{
	public partial class T_MsgDAL
	{
        public T_Msg Add(T_Msg t_Msg)
		{
				string sql ="INSERT INTO T_Msgs (Title, Message, NickName, IsAnonymous, IPAddress, PostDate)  output inserted.Id VALUES (@Title, @Message, @NickName, @IsAnonymous, @IPAddress, @PostDate)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Title", ToDBValue(t_Msg.Title)),
						new SqlParameter("@Message", ToDBValue(t_Msg.Message)),
						new SqlParameter("@NickName", ToDBValue(t_Msg.NickName)),
						new SqlParameter("@IsAnonymous", ToDBValue(t_Msg.IsAnonymous)),
						new SqlParameter("@IPAddress", ToDBValue(t_Msg.IPAddress)),
						new SqlParameter("@PostDate", ToDBValue(t_Msg.PostDate)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_Msgs WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
						
        public int Update(T_Msg t_Msg)
        {
            string sql =
                "UPDATE T_Msgs " +
                "SET " +
			" Title = @Title" 
                +", Message = @Message" 
                +", NickName = @NickName" 
                +", IsAnonymous = @IsAnonymous" 
                +", IPAddress = @IPAddress" 
                +", PostDate = @PostDate" 
               
            +" WHERE Id = @Id";

			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", t_Msg.Id)
					,new SqlParameter("@Title", ToDBValue(t_Msg.Title))
					,new SqlParameter("@Message", ToDBValue(t_Msg.Message))
					,new SqlParameter("@NickName", ToDBValue(t_Msg.NickName))
					,new SqlParameter("@IsAnonymous", ToDBValue(t_Msg.IsAnonymous))
					,new SqlParameter("@IPAddress", ToDBValue(t_Msg.IPAddress))
					,new SqlParameter("@PostDate", ToDBValue(t_Msg.PostDate))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_Msg GetById(int id)
        {
            string sql = "SELECT * FROM T_Msgs WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@Id", id)))
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
		
		public T_Msg ToModel(SqlDataReader reader)
		{
			T_Msg t_Msg = new T_Msg();

			t_Msg.Id = (int)ToModelValue(reader,"Id");
			t_Msg.Title = (string)ToModelValue(reader,"Title");
			t_Msg.Message = (string)ToModelValue(reader,"Message");
			t_Msg.NickName = (string)ToModelValue(reader,"NickName");
			t_Msg.IsAnonymous = (bool)ToModelValue(reader,"IsAnonymous");
			t_Msg.IPAddress = (string)ToModelValue(reader,"IPAddress");
			t_Msg.PostDate = (DateTime)ToModelValue(reader,"PostDate");
			return t_Msg;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_Msgs";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_Msg> GetPagedDataByRowNum(int minrownum,int maxrownum)
		{
			var list = new List<T_Msg>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Msgs) t where rownum>=@minrownum and rownum<=@maxrownum";
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
        
        public IEnumerable<T_Msg> GetPagedData(int pageSize,int pageIndex)
		{
			var list = new List<T_Msg>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Msgs) t where rownum between ((@pageIndex-1)*@pageSize)+1 and (@pageIndex*@pageSize)";
			using(SqlDataReader reader = SqlHelper.ExecuteReader(sql,
				new SqlParameter("@pageSize",pageSize),
				new SqlParameter("@pageIndex",pageIndex)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public IEnumerable<T_Msg> GetAll()
		{
			var list = new List<T_Msg>();
			string sql = "SELECT * FROM T_Msgs";
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