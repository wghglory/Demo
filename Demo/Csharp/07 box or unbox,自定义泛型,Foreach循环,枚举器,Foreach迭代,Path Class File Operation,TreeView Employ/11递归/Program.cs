﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11递归
{
    class Program
    {
        static void Main(string[] args)
        {
            T1();
            //Console.ReadKey();
            //Say();
            Console.ReadKey();
        }

        //方法的递归时，必须保证方法中有一个终止条件，否则就会死递归。
        public static void Say()
        {
            Console.WriteLine("山上有座庙");
            Console.WriteLine("庙里有个老和尚和小和尚");
            Console.WriteLine("有一天，老和尚给小和尚讲故事：");
            Console.WriteLine("讲的是：");
            Say();
        }


        public static void T1()
        {
            Console.WriteLine("T1方法被调用啦！！");
            T2();
        }

        public static void T2()
        {
            Console.WriteLine("T2方法被调用了！！！");
            T3();
        }

        public static void T3()
        {
            Console.WriteLine("T3方法被调用了！！");
            //T1();
        }
    }
}
