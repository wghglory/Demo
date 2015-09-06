using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RenYuan.Model;
using RenYuan.DAL;

namespace RenYuan.BLL
{
    public class TblPersonBll
    {
        TblPersonDal dal = new TblPersonDal();
        public int Add(TblPerson model)
        {
            return dal.Add(model);
        }

        public List<TblPerson> GetAllData()
        {
            return dal.GetAllData();
        }
        public int DeleteByAutoId(int autoId)
        {
            return dal.DeleteByAutoId(autoId);
        }

        public int UpdateByAutoId(TblPerson model)
        {
            return dal.UpdateByAutoId(model);
        }
    }
}
