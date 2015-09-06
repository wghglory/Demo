using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01静态类练习
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Name = "hl";
            Person.Show(p);   
            // PersonMethod.SayHi(p);
            SayHi();
            Console.ReadKey();
        }

        //静态成员的数据直到程序退出后才会释放资源，而实例对象，只要使用完毕就可以执行垃圾回收。
        static void SayHi()
        {
            Person p = new Person();
            p.Name = "aaaaa";
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

        public static void Show(Person p)  
        {
            Console.WriteLine(p.Name);
        }

    }

    static class PersonMethod
    {
        public static void SayHi(Person p)   //破坏封装，不要写static的，不然乱糟糟
        {
            Console.WriteLine(p.Name);
        }
    }
}
