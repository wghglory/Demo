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

    public partial class SupplierBLL
    {
        public Supplier Add(Supplier supplier)
        {
            return new SupplierDAL().Add(supplier);
        }

        public int DeleteBySupplierID(int supplierID)
        {
            return new SupplierDAL().DeleteBySupplierID(supplierID);
        }

		public int Update(Supplier supplier)
        {
            return new SupplierDAL().Update(supplier);
        }
        
        public Supplier GetBySupplierID(int supplierID)
        {
            return new SupplierDAL().GetBySupplierID(supplierID);
        }
        
		public int GetTotalCount()
		{
			return new SupplierDAL().GetTotalCount();
		}
		
		public IEnumerable<Supplier> GetPagedData(int minrownum,int maxrownum)
		{
			return new SupplierDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<Supplier> GetAll()
		{
			return new SupplierDAL().GetAll();
		}
    }
}