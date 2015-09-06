using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03多态1
{
    public static class MyClass2
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            //object o = new object();
            //Console.WriteLine(o.ToString());//???? System.Object

            //Person p = new Person();
            //Console.WriteLine(p.ToString());//???? System.03多态

            //string msg = "你好呀";
            //Console.WriteLine(msg.ToString());//????? “你好呀”

            //Console.ReadKey();

            #region 类型转换的另外一种方式

            Person p = new Student();
            //Person p = new Person();

            //通过这种方式进行类型转换时，如果没写if，转换失败则直接报异常！！
            //if(p is Student)
            //{
            //    Student s = (Student)p;
            //}

            //进行类型转换的另外一种方式（推荐使用！）
            //通过as的方式进行类型转换，即便转换失败也不会报异常，而是返回一个null.
            Student s = p as Student;
            if (s != null)
            {
                Console.WriteLine("转换成功！");
            }
            else
            {
                Console.WriteLine("转换失败！");
            }
            Console.WriteLine("ok");
            Console.ReadKey();
            #endregion
        }
    }
    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }

    public class Student : Person
    {

    }
}
