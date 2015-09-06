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
	public partial class TblAreaDAL
	{
        public TblArea Add(TblArea tblArea)
		{
				string sql ="INSERT INTO TblArea (AreaName, AreaPId)  output inserted.AreaId VALUES (@AreaName, @AreaPId)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@AreaName", ToDBValue(tblArea.AreaName)),
						new SqlParameter("@AreaPId", ToDBValue(tblArea.AreaPId)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetByAreaId(newId);
		}

        public int DeleteByAreaId(int areaId)
		{
            string sql = "DELETE TblArea WHERE AreaId = @AreaId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@AreaId", areaId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
						
        public int Update(TblArea tblArea)
        {
            string sql =
                "UPDATE TblArea " +
                "SET " +
			" AreaName = @AreaName" 
                +", AreaPId = @AreaPId" 
               
            +" WHERE AreaId = @AreaId";

			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@AreaId", tblArea.AreaId)
					,new SqlParameter("@AreaName", ToDBValue(tblArea.AreaName))
					,new SqlParameter("@AreaPId", ToDBValue(tblArea.AreaPId))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TblArea GetByAreaId(int areaId)
        {
            string sql = "SELECT * FROM TblArea WHERE AreaId = @AreaId";
            using(SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@AreaId", areaId)))
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
		
		public TblArea ToModel(SqlDataReader reader)
		{
			TblArea tblArea = new TblArea();

			tblArea.AreaId = (int)ToModelValue(reader,"AreaId");
			tblArea.AreaName = (string)ToModelValue(reader,"AreaName");
			tblArea.AreaPId = (int?)ToModelValue(reader,"AreaPId");
			return tblArea;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TblArea";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TblArea> GetPagedDataByRowNum(int minrownum,int maxrownum)
		{
			var list = new List<TblArea>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by AreaId) rownum FROM TblArea) t where rownum>=@minrownum and rownum<=@maxrownum";
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
        
        public IEnumerable<TblArea> GetPagedData(int pageSize,int pageIndex)
		{
			var list = new List<TblArea>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by AreaId) rownum FROM TblArea) t where rownum between ((@pageIndex-1)*@pageSize)+1 and (@pageIndex*@pageSize)";
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
		
		public IEnumerable<TblArea> GetAll()
		{
			var list = new List<TblArea>();
			string sql = "SELECT * FROM TblArea";
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