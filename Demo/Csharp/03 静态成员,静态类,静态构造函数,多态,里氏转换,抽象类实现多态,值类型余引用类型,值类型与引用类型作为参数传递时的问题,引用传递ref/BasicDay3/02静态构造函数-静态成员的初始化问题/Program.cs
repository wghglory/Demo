using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02静态构造函数_静态成员的初始化问题
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyClass.n1 = 1000;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            MyClass mc = new MyClass();
            MyClass.name = "马毅";
            Console.WriteLine(MyClass.name);
            Console.ReadKey();
            //类中的静态成员，在第一次使用静态类的时候进行初始化。
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

        public static string Sid = "0001";

        public static int Weight;
    }

    public class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("====================实例构造函数被执行了====================");
        }
        //静态构造函数的特点：
        //静态构造函数不能手动来调用，而是在第一次使用静态成员的时候自动调用的,所以不能为静态构造函数添加访问修饰符，默认为private
        //因为静态构造函数是系统自动调用的，所以也不需要（不能）添加任何参数
        //1.静态构造函数只执行一次（）
        //2.在第一次使用静态类或者静态成员的时候执行。
        static MyClass()
        {
            Console.WriteLine("===静态构造函数被执行啦=======");
            n1 = 100;
            name = "黄林";
        }

        public static int n1;

        public static string name;
    }
}
