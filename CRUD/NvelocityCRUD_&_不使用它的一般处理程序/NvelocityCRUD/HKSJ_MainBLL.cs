//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using Nvelocity.DAL;
using Nvelocity.Model;

namespace Nvelocity.BLL
{

    public partial class HKSJ_MainBLL
    {
        public HKSJ_Main Add(HKSJ_Main hKSJ_Main)
        {
            return new HKSJ_MainDAL().Add(hKSJ_Main);
        }

        public int DeleteByID(int iD)
        {
            return new HKSJ_MainDAL().DeleteByID(iD);
        }

		public int Update(HKSJ_Main hKSJ_Main)
        {
            return new HKSJ_MainDAL().Update(hKSJ_Main);
        }
        
        public HKSJ_Main GetByID(int iD)
        {
            return new HKSJ_MainDAL().GetByID(iD);
        }
        
		public int GetTotalCount()
		{
			return new HKSJ_MainDAL().GetTotalCount();
		}
		
		public IEnumerable<HKSJ_Main> GetPagedData(int minrownum,int maxrownum)
		{
			return new HKSJ_MainDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<HKSJ_Main> GetAll()
		{
			return new HKSJ_MainDAL().GetAll();
		}
    }
}