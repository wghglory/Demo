using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04匿名方法和Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //以后都用lambda表达式，很少用匿名方法，知道

            //匿名方法不能直接在类中定义，而是在给委托变量赋值的时候，需要赋值一个方法，此时可以“现做现卖”，定义一个匿名方法传递给该委托。
            MyDelegate md = delegate()
            {
                Console.WriteLine("匿名方法");
            };
            md = () => { Console.WriteLine("lambda expression"); };
            md();


            MyStringDelegate msd = delegate(string msg)
            {
                Console.WriteLine("有一个返回值的匿名方法" + msg);
            };
            msd = (x) => { Console.WriteLine("lambda" + x); }; //lambda 不用传数据类型，因为委托已经指明
            msd("one return");



            AddDelegate ad = delegate(int x, int y, int z)
            {
                return x + y + z;
            };
            ad = (a, b, c) => { return a + b + c; };
            int sum = ad(1, 2, 3);


            int sumValue = 0;
            AddParamsDelegate apd = delegate(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    sumValue = arr[i] + sumValue;
                }
                return sumValue;
            };
            apd = (arr) => { return arr.Sum(); };

            Console.WriteLine(apd(1, 2, 3, 4, 5));
            Console.ReadKey();
        }
    }

    public delegate void MyDelegate();
    public delegate void MyStringDelegate(string str);
    public delegate int AddDelegate(int n1, int n2, int n3);
    public delegate int AddParamsDelegate(params int[] arr);
}
