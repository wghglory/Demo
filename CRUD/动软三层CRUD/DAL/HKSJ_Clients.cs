﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MaticSoft.DAL
{
	/// <summary>
	/// 数据访问类:HKSJ_Clients
	/// </summary>
	public partial class HKSJ_Clients
	{
		public HKSJ_Clients()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "HKSJ_Clients"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HKSJ_Clients");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MaticSoft.Model.HKSJ_Clients model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HKSJ_Clients(");
			strSql.Append("title,softName,content,liaisonPhone,liaisonPeple,date,peple)");
			strSql.Append(" values (");
			strSql.Append("@title,@softName,@content,@liaisonPhone,@liaisonPeple,@date,@peple)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@softName", SqlDbType.VarChar,150),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@liaisonPhone", SqlDbType.VarChar,22),
					new SqlParameter("@liaisonPeple", SqlDbType.VarChar,30),
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@peple", SqlDbType.VarChar,20)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.softName;
			parameters[2].Value = model.content;
			parameters[3].Value = model.liaisonPhone;
			parameters[4].Value = model.liaisonPeple;
			parameters[5].Value = model.date;
			parameters[6].Value = model.peple;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MaticSoft.Model.HKSJ_Clients model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HKSJ_Clients set ");
			strSql.Append("title=@title,");
			strSql.Append("softName=@softName,");
			strSql.Append("content=@content,");
			strSql.Append("liaisonPhone=@liaisonPhone,");
			strSql.Append("liaisonPeple=@liaisonPeple,");
			strSql.Append("date=@date,");
			strSql.Append("peple=@peple");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@softName", SqlDbType.VarChar,150),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@liaisonPhone", SqlDbType.VarChar,22),
					new SqlParameter("@liaisonPeple", SqlDbType.VarChar,30),
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@peple", SqlDbType.VarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.softName;
			parameters[2].Value = model.content;
			parameters[3].Value = model.liaisonPhone;
			parameters[4].Value = model.liaisonPeple;
			parameters[5].Value = model.date;
			parameters[6].Value = model.peple;
			parameters[7].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HKSJ_Clients ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HKSJ_Clients ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MaticSoft.Model.HKSJ_Clients GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,softName,content,liaisonPhone,liaisonPeple,date,peple from HKSJ_Clients ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			MaticSoft.Model.HKSJ_Clients model=new MaticSoft.Model.HKSJ_Clients();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MaticSoft.Model.HKSJ_Clients DataRowToModel(DataRow row)
		{
			MaticSoft.Model.HKSJ_Clients model=new MaticSoft.Model.HKSJ_Clients();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["softName"]!=null)
				{
					model.softName=row["softName"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["liaisonPhone"]!=null)
				{
					model.liaisonPhone=row["liaisonPhone"].ToString();
				}
				if(row["liaisonPeple"]!=null)
				{
					model.liaisonPeple=row["liaisonPeple"].ToString();
				}
				if(row["date"]!=null && row["date"].ToString()!="")
				{
					model.date=DateTime.Parse(row["date"].ToString());
				}
				if(row["peple"]!=null)
				{
					model.peple=row["peple"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,softName,content,liaisonPhone,liaisonPeple,date,peple ");
			strSql.Append(" FROM HKSJ_Clients ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,title,softName,content,liaisonPhone,liaisonPeple,date,peple ");
			strSql.Append(" FROM HKSJ_Clients ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM HKSJ_Clients ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from HKSJ_Clients T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "HKSJ_Clients";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

