using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.Model;
using Ajax.CRUD.DAL;

namespace Ajax.CRUD.BLL
{
    public class TblCommentsBll
    {
        private TblCommentsDal dal = new TblCommentsDal();
        public List<TblComments> GetAllComments()
        {
            return dal.GetAllComments();
        }

        public int Add(TblComments tblComment)
        {
            return dal.Add(tblComment);
        }
        public int Delete(int autoId)
        {
            return dal.Delete(autoId);
        }
        public int Update(TblComments model)
        {
            return dal.Update(model);
        }

        public int Delete(TblComments model)
        {
            return dal.Delete(model.AutoId);
        }
    }
}
