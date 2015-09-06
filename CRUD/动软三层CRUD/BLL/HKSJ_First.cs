using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using MaticSoft.Model;
namespace MaticSoft.BLL
{
	/// <summary>
	/// HKSJ_First
	/// </summary>
	public partial class HKSJ_First
	{
		private readonly MaticSoft.DAL.HKSJ_First dal=new MaticSoft.DAL.HKSJ_First();
		public HKSJ_First()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Name)
		{
			return dal.Exists(Name);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MaticSoft.Model.HKSJ_First model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MaticSoft.Model.HKSJ_First model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Name)
		{
			
			return dal.Delete(Name);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Namelist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(Namelist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MaticSoft.Model.HKSJ_First GetModel(string Name)
		{
			
			return dal.GetModel(Name);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MaticSoft.Model.HKSJ_First GetModelByCache(string Name)
		{
			
			string CacheKey = "HKSJ_FirstModel-" + Name;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Name);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MaticSoft.Model.HKSJ_First)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MaticSoft.Model.HKSJ_First> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MaticSoft.Model.HKSJ_First> DataTableToList(DataTable dt)
		{
			List<MaticSoft.Model.HKSJ_First> modelList = new List<MaticSoft.Model.HKSJ_First>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MaticSoft.Model.HKSJ_First model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

