using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01三层.Model;
using _01三层.DAL;

namespace _01三层.BLL
{
    public class TblAreaBll
    {
        TblAreaDal dal = new TblAreaDal();
        public List<TblArea> GetAreasByParentId(int pid)
        {

            return dal.GetAreaByParentId(pid);
        }

        //根据Id删除一条记录的方法
        public int DeleteAreaByAreaId(int areaId)
        {
            return dal.DeleteAreaByAreaId(areaId);
        }

        //递归删除
        public void DeleteAreaDiGui(int areaId)
        {
            //1.删除之前先根据当前的areaId找到所有的父Id为areaId的那些节点的id
            List<TblArea> list = GetAreasByParentId(areaId);
            foreach (var item in list)
            {
                DeleteAreaDiGui(item.AreaId);
            }
            //删除当前记录
            DeleteAreaByAreaId(areaId);
        }
    }
}
