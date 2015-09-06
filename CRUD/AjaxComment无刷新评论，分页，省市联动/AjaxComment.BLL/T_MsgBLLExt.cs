using AjaxComment.DAL;
using AjaxComment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjaxComment.BLL
{
    public partial class T_MsgBLL
    {
        public IEnumerable<T_Msg> GetDataByPage(int pagesize, int pageindex, out int recordcount, out int pagecount)
        {
            T_MsgDAL dal = new T_MsgDAL();
            return dal.GetDataByPage(pagesize, pageindex, out  recordcount, out  pagecount);
        }
    }
}
