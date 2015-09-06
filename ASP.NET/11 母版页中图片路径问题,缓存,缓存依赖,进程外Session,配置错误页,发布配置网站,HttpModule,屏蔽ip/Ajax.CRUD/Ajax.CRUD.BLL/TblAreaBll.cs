using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.DAL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.BLL
{
    public class TblAreaBll
    {
        private TblAreaDal dal = new TblAreaDal();
        public List<TblArea> GetAreasByParentId(int pid)
        {
            return dal.GetAreasByParentId(pid);
        }
    }
}
