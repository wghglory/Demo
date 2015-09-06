using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06多播委托
{
    class Program
    {
        static void Main(string[] args)
        {
            //同string，不可变性。不断创建新的对象，不是修改原对象
            //自定义这些委托继承MultiCastDelegate，再继承Delegate:object.他俩都是abstract class
            Action<string> action = M1;
            action += M2;
            action += M3;
            action += M4;
            action -= M3;
            action("guanghui");

            Mydelegate md = T1;  //new Mydelegate(M1);
            md = Delegate.Combine(md, new Mydelegate(T2), new Mydelegate(T3)) as Mydelegate;
            Console.WriteLine(md(1));   //这样只能拿到最后一个函数的返回值

            //拿到每个函数的返回值
            Delegate[] delegates = md.GetInvocationList();
            for (int i = 0; i < delegates.Length; i++)
            {
                Console.WriteLine((delegates[i] as Mydelegate)(1));
            }
            Console.ReadKey();
        }

        public delegate int Mydelegate(int msg);

        static int T1(int x)
        {
            return x;
        }
        static int T2(int x)
        {
            return 2 * x;
        }
        static int T3(int x)
        {
            return 3 * x;
        }

        static void M1(string msg)
        {
            Console.WriteLine(msg);
        }
        static void M2(string msg)
        {
            Console.WriteLine(msg);
        }
        static void M3(string msg)
        {
            Console.WriteLine(msg);
        }
        static void M4(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
