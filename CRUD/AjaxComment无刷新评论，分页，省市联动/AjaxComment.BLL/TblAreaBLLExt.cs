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
        public IEnumerable<TblArea> GetAreasByParentId(int pid)
        {
            TblAreaDAL dal = new TblAreaDAL();
            return dal.GetAreasByParentId(pid);
        }

    }
}