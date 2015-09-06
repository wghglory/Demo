using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05泛型委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action非泛型版本：无参无返回值
            Action action1 = M1; // new Action(M1);
            action1();

            //泛型:避免了定义多个委托
            MyGenericDelegate<string> md = M1;
            MyGenericDelegate<int> mdd = M1;

            //Action<T>泛型版本：有参数，无返回值
            Action<string> actionGeneric = M1;
            Action<int> actionInt = M1;

            Action<string> actionAnonymous = delegate(string x)
            {
                Console.WriteLine(x + "泛型委托和匿名函数");
            };

            Action<string> a1 = x => { Console.WriteLine(x); };
            a1("泛型action + lambda");
            Action<int, int> a2 = (a, b) => { Console.WriteLine(a + b); };
            a2(1,2);


            //Func<>有返回值,只有一个泛型版本，没有非泛型版本.4个参数：前三个参数，最后一个是返回值out int
            Func<int, int, int, int> fun = (x, y, z) => { return x + y + z; };
            Console.WriteLine(fun(5, 3, 5));


            Console.ReadKey();
        }

        static void M1()
        {
            Console.WriteLine("action!");
        }

        static void M1(string x)
        {
            Console.WriteLine(x);
        }

        static void M1(int x)
        {
            Console.WriteLine(x);
        }

    }

    public delegate void MyGenericDelegate<T>(T args);
}
