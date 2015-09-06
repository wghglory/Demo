//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using AjaxComment.DAL;
using AjaxComment.Model;

namespace AjaxComment.BLL
{

    public partial class TblAreaBLL
    {
        public TblArea Add(TblArea tblArea)
        {
            return new TblAreaDAL().Add(tblArea);
        }

        public int DeleteByAreaId(int areaId)
        {
            return new TblAreaDAL().DeleteByAreaId(areaId);
        }

		public int Update(TblArea tblArea)
        {
            return new TblAreaDAL().Update(tblArea);
        }
        
        public TblArea GetByAreaId(int areaId)
        {
            return new TblAreaDAL().GetByAreaId(areaId);
        }
        
		public int GetTotalCount()
		{
			return new TblAreaDAL().GetTotalCount();
		}
		
		public IEnumerable<TblArea> GetPagedDataByRowNum(int minrownum,int maxrownum)
		{
			return new TblAreaDAL().GetPagedDataByRowNum(minrownum,maxrownum);
		}
        
        public IEnumerable<TblArea> GetPagedData(int pageSize,int pageIndex)
		{
			return new TblAreaDAL().GetPagedData(pageSize,pageIndex);
		}
		
		public IEnumerable<TblArea> GetAll()
		{
			return new TblAreaDAL().GetAll();
		}
    }
}