using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using Stu.DAL;

namespace Stu.BLL
{
    public class MyStudentBll
    {
        MyStudentDal dal = new MyStudentDal();

        public List<MyStudent> GetAllStudents()
        {
            return dal.GetAllStudents();
        }

        public int Add(MyStudent model)
        {
            return dal.Add(model);
        }

        public int Update(MyStudent model)
        {
            return dal.Update(model);
        }

        public int Delete(int id)
        {
            return dal.Delete(id);
        }

        public List<MyStudent> SearchData(List<Condition> listWhere)
        {
            return dal.SearchData(listWhere);
        }
    }
}
