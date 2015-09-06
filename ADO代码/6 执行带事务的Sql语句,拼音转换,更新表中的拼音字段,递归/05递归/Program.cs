using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05递归
{
    class Program
    {
        static void Main(string[] args)
        {
            ////M1();
            ////Console.ReadKey();
            ////输出结果是什么？？？
            //T1();
            //Console.ReadKey();

            M1(0);
            Console.ReadKey();
        }

        static void M1(int i)
        {
            Console.WriteLine("A" + i);
            i++;
            if (i < 3)
            {
                M1(i);
            }
            Console.WriteLine("B" + i);
        }


        //static int index = 0;
        //static void T1()
        //{
        //    Console.WriteLine("A");
        //    if (index < 3)
        //    {
        //        index++;
        //        T1();

        //    }
        //    Console.WriteLine("B");
        //}







        //如果要是将index++放到这里呢？

        //static void M1()
        //{
        //    Console.WriteLine("M1");
        //    M2();
        //}

        //static void M2()
        //{
        //    Console.WriteLine("M2");
        //}
    }
}
