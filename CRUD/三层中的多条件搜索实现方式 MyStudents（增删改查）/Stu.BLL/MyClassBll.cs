using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.DAL;
using Stu.Model;

namespace Stu.BLL
{
    public class MyClassBll
    {
        MyClassDal dal = new MyClassDal();
        public List<MyClass> GetAllClasses()
        {
            return dal.GetAllClasses();
        }
    }
}
