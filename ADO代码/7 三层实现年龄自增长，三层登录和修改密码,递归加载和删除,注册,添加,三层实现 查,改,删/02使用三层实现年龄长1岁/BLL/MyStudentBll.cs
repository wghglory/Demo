using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _08使用三层实现年龄长1岁.DAL;

namespace _08使用三层实现年龄长1岁.BLL
{
    public class MyStudentBll
    {
        MyStudentDal dal = new MyStudentDal();
        public int AgeInc()
        {
            return dal.AgeInc();
        }
    }
}
