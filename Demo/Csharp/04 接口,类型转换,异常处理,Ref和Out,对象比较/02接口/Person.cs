using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02接口2
{

    public interface ICollectHomework
    {
        void Collect();
    }

    public class Person
    {

    }

    public class Student : Person, ICollectHomework
    {

        #region ICollectHomework 成员

        public void Collect()
        {
            Console.WriteLine("学生收作业");
        }

        #endregion
    }

    public class Teacher : Person, ICollectHomework
    {

        #region ICollectHomework 成员

        public void Collect()
        {
            Console.WriteLine("老师收作业。。");
        }

        #endregion
    }

    public class SchoolMaster : Person
    {

    }


}
