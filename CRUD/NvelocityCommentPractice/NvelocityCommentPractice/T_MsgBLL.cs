//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using NvelocityCommentPractice.DAL;
using NvelocityCommentPractice.Model;

namespace NvelocityCommentPractice.BLL
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
		
		public IEnumerable<T_Msg> GetPagedData(int minrownum,int maxrownum)
		{
			return new T_MsgDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<T_Msg> GetAll()
		{
			return new T_MsgDAL().GetAll();
		}
    }
}