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

    public partial class T_MsgBLL
    {
        public T_Msg Add(T_Msg t_Msg)
        {
            return new T_MsgDAL().Add(t_Msg);
        }

        public int DeleteById(int id)
        {
            return new T_MsgDAL().DeleteById(id);
        }

		public int Update(T_Msg t_Msg)
        {
            return new T_MsgDAL().Update(t_Msg);
        }
        
        public T_Msg GetById(int id)
        {
            return new T_MsgDAL().GetById(id);
        }
        
		public int GetTotalCount()
		{
			return new T_MsgDAL().GetTotalCount();
		}
		
		public IEnumerable<T_Msg> GetPagedDataByRowNum(int minrownum,int maxrownum)
		{
			return new T_MsgDAL().GetPagedDataByRowNum(minrownum,maxrownum);
		}
        
        public IEnumerable<T_Msg> GetPagedData(int pageSize,int pageIndex)
		{
			return new T_MsgDAL().GetPagedData(pageSize,pageIndex);
		}
		
		public IEnumerable<T_Msg> GetAll()
		{
			return new T_MsgDAL().GetAll();
		}
    }
}