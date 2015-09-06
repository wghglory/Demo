using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06隐式类型
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person();
            var p = new { Name = "黄林", Age = 18, Email = "huangling@yahoo.com" };
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Age);
            Console.WriteLine(p.Email);
            //隐式类型只能读取不能赋值。
            //p.Name = "xzl";
            Console.ReadKey();
        }
    }

    //public class Person
    //{
    //    public string Name
    //    {
    //        get;
    //        set;
    //    }
    //    public int Age
    //    {
    //        get;
    //        set;
    //    }
    //    public string Email
    //    {
    //        get;
    //        set;
    //    }

    //}
}
