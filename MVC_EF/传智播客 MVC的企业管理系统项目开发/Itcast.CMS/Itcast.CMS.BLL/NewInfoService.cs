using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itcast.CMS.BLL
{
    public class NewInfoService
    {
        DAL.NewInfoDal newInfoDal = new DAL.NewInfoDal();
        public List<T_New> GetPageEntityList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return newInfoDal.GetPageEntityList(start, end);
        }
        public int GetPageCount(int pageSize)
        {
            int recordCount = newInfoDal.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }
        public T_New GetModel(int id)
        {
            return newInfoDal.GetEntityModel(id);
        }
        public bool DeleteEntityModel(int id)
        {
            return newInfoDal.DeleteEntityModel(id) > 0;
        }
        public bool InsertEntityModel(T_New newInfo)
        {
            return newInfoDal.InsertEntityModel(newInfo) > 0;
        }
        public bool UpdateEntityModel(T_New newInfo)
        {
            return newInfoDal.UpdateEntityModel(newInfo) > 0;
        }
    }
}
