using CalculatorDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("请输入一个数字：");
            //double d1 = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("请输入一个操作符:");
            //string caozuofu = Console.ReadLine();
            //Console.WriteLine("请输入另一个数字：");
            //double d2 = Convert.ToDouble(Console.ReadLine());
            //Calculator cal = null;
            //switch (caozuofu)
            //{
            //    case "+":
            //        cal = new JiaFaClass(d1, d2);
            //        break;
            //    case "-":
            //        cal = new JianFaDll(d1, d2);
            //        break;
            //    case "*":
            //        cal = new ChengFaClass(d1, d2);
            //        break;
            //}
            //if (cal != null)
            //{
            //    Console.WriteLine("计算结果是：{0}", cal.JiSuan());
            //}
            //else
            //{
            //    Console.WriteLine("没有该功能！");
            //}
            //Console.ReadKey();

            //============================================================================
            Console.WriteLine("请输入一个数字：");
            double d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入一个操作符:");
            string caozuofu = Console.ReadLine();
            Console.WriteLine("请输入另一个数字：");
            double d2 = Convert.ToDouble(Console.ReadLine());
            Calculator cal = GetComputeObject(caozuofu, d2, d2);

            if (cal != null)
            {
                Console.WriteLine("计算结果是：{0}", cal.JiSuan());
            }
            else
            {
                Console.WriteLine("没有该功能！");
            }
            Console.ReadKey();

        }

        //简单工厂设计模式。返回父类对象
        private static Calculator GetComputeObject(string caozuofu, double d1, double d2)
        {
            Calculator result = null;
            switch (caozuofu)
            {
                case "+":
                    result = new JiaFaClass(d1, d2);
                    break;
                case "-":
                    result = new JianFaDll(d1, d2);
                    break;
                case "*":
                    result = new ChengFaClass(d1, d2);
                    break;
            }
            return result;
        }
    }
}