using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01静态类和静态成员
{
    class Program
    {
        //不是所有的静态成员都必须写在静态类中。
        static void Main(string[] args)
        {
            //Person hl = new Person();
            //hl.Name = "黄林";
            //hl.Age = 18;
            //hl.Email = "hl@yahoo.com";
            Person.Planet = "地球";

            ////实例成员是属于具体某个对象的。
            //Person my = new Person();
            //my.Name = "马毅";
            //my.Age = 17;
            //my.Email = "my@yahoo.com";

            //Console.WriteLine(Person.Planet);

            //Console.WriteLine(my.Email);
            //Console.WriteLine(hl.Email);

            //Person.Planet = "火星";

            ////在程序的任何一个地方发访问该静态成员，其实访问的都是同一块内存，所以有一个地方把该值改变，则所有地方获取到的值都变了。
            //Class1 c1 = new Class1();
            //c1.Say();
            //Console.ReadKey();

            //Class1 c = new Class1();

            Class1 c = Class1.GetObject();

        }
    }

    public class Class1
    {
        private Class1()  //私有构造函数
        {

        }
        public static Class1 GetObject()   //单例模式
        {

            return new Class1();
        }
    }


    public class Person
    {
        //这三个属性都是“实例属性”
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

        //静态成员是属于“类”的，不是属于具体“对象”的。
        //所以访问静态成员的时候不能通过对象来访问，(对象.属性名),只能通过"类名"来直接访问静态成员，比如：类名.成员名
        public static string Planet
        {
            get;
            set;
        }

        //public static void Introduce()
        //{
        //    Console.WriteLine("我叫：" + this.Name);
        //}

    }


    static class MyClass
    {
        //在静态类中，所包含的的所有成员必须都是“静态成员”

        static void M1()
        {
        }

    }
}
