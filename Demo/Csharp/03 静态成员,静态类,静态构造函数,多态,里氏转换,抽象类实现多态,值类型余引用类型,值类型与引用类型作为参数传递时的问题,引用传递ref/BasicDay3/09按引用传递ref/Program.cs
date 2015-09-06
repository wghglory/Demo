using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09按引用传递ref
{
    class Program
    {
        static void Main(string[] args)
        {
            //int m = 100;
            ////“按引用传递”传递的是栈本身的地址
            ////“值传递”传递的是栈中的内容，是将栈中的内容拷贝了一个副本。
            ////这种传递方式其实m和n就是同一个变量的两个不同的别名而已。
            //M1(ref m);
            //Console.WriteLine(m);   //101
            //Console.ReadKey();


            //Person my = new Person();
            //my.Name = "马毅";
            //M3(ref my);
            //Console.WriteLine(my.Name);   //石国庆
            //Console.ReadKey();

            //========================================
            Person p1 = new Person();
            p1.Name = "黄林";
            M2(ref p1);
            Console.WriteLine(p1.Name);    //许正龙
            Console.ReadKey();
            //=================================================

        }
        static void M2(ref Person p2)
        {
            p2 = new Person();
            p2.Name = "许正龙";
        }
        static void M3(ref Person per)
        {
            per.Name = "石国庆";
        }
        static void M1(ref int n)
        {
            n = n + 1;
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
