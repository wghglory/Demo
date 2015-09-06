//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using EasyUI.DAL;
using EasyUI.Model;

namespace EasyUI.BLL
{

    public partial class MyOrderBLL
    {
        public MyOrder Add(MyOrder myOrder)
        {
            return new MyOrderDAL().Add(myOrder);
        }

        public int DeleteById(int id)
        {
            return new MyOrderDAL().DeleteById(id);
        }

		public int Update(MyOrder myOrder)
        {
            return new MyOrderDAL().Update(myOrder);
        }
        
        public MyOrder GetById(int id)
        {
            return new MyOrderDAL().GetById(id);
        }
        
		public int GetTotalCount()
		{
			return new MyOrderDAL().GetTotalCount();
		}
		
		public IEnumerable<MyOrder> GetPagedDataByRowNum(int minrownum,int maxrownum)
		{
			return new MyOrderDAL().GetPagedDataByRowNum(minrownum,maxrownum);
		}
        
        public IEnumerable<MyOrder> GetPagedData(int pageSize,int pageIndex)
		{
			return new MyOrderDAL().GetPagedData(pageSize,pageIndex);
		}
		
		public IEnumerable<MyOrder> GetAll()
		{
			return new MyOrderDAL().GetAll();
		}
    }
}