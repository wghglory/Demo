using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12判断两个对象是否为同一个对象
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "苏坤";
            p1.Age = 18;
            p1.Email = "sk@itcast.cn";

            Person p2 = new Person();
            p2.Name = "苏坤";
            p2.Age = 18;
            p2.Email = "sk@itcast.cn";

            Person p3 = p1;

            //Console.ReadKey();

            //
            //p3 p1
            //p1.Equals(p2)
            if (p1 == p2)
            {
            }

            //比较两个对象是否为同一个对象
            //当需要比较两个对象是否为同一个对象的时候请使用object.ReferenceEquals()方法。
            Console.WriteLine(object.ReferenceEquals(p1, p2));
            Console.WriteLine(object.ReferenceEquals(p1, p3));


            Console.ReadKey();
            //if (object.ReferenceEquals(p1,p2))
            //{

            //}

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
}
