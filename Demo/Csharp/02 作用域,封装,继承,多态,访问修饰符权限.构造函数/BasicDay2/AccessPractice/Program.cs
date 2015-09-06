using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessPractice
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }


    #region 1

    //class Person
    //{

    //}

    //public class Student : Person       //no, public class cannot inherit from private class
    //{

    //}

    #endregion

    #region 2

    class Person
    {
        public string Name
        {
            get;
            set;
        }
    }

    public class MyClass
    {
        public void SayHi(Person per)   //方法的访问修饰符需要和方法的参数的类型的访问修饰符一致. Person是internal级别
        {
            Console.WriteLine(per.Name);
        }
    }
    #endregion

    #region 3
    ////没问题
    //class Person
    //{

    //}

    //class MyClass
    //{
    //    public void SayHi(Person p)   //这里public没什么意义，类的级别一样internal
    //    {
    //    }
    //}

    #endregion

    #region 4

    //class Person
    //{

    //}

    //public class MyClass
    //{
    //    //方法的参数与方法的返回值都必须得和方法保持一致的访问修饰符
    //    public Person GetPerson()
    //    {
    //        return new Person();   //wrong，返回级别internal
    //    }
    //}


    #endregion

    #region 5

    //class Person
    //{

    //}

    //public class MyClass
    //{

    //    public Person Friend        //wrong，属性类型和访问修饰符也要一致
    //    {
    //        get;
    //        set;
    //    }
    //}

    #endregion

}
