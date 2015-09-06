using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10可变参数
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 可变参数
            ////
            ////Test("aa", 10, 1, 2, 32, 4, 5, 6);
            //int[] arrInt = new int[] { 1, 2, 3, 4, 5 };
            //Test("xxx");
            ////Test("aaaaa", arrInt);
            //Test("aaaa", null);
            //Console.ReadKey();
            //Console.WriteLine("");
            //List<string> list = new List<string>();
            //Console.WriteLine("==={0}===", list);
            //Console.ReadKey();
            #endregion

            #region out参数
            ////int m = 1000;
            //int m;
            //Test1(out m);
            //Console.WriteLine(m);
            //Console.ReadKey();

            #endregion

            //int money = 1000;
            //JianJin(ref money);
            //KouKuan(ref money);
            //Console.WriteLine(money);
            //Console.ReadKey();
            //string n;
            //int h;
            //int age = GetAge(out n, out h);
            //Console.WriteLine(age);
            //Console.WriteLine(n);
            //Console.WriteLine(h);
            //Console.ReadKey();

            string s = "333";
            int result;
            bool b = int.TryParse(s, out result);
            if (b)
            {
                Console.WriteLine("转换成功，结果为：{0}", result);
            }
            else
            {
                Console.WriteLine("失败，out参数的值是：{0}", result);
            }
            Console.ReadKey();

        }

        static int GetAge(out string name, out int height)
        {
            name = "黄林";
            height = 180;
            return 1000;
        }
        static void JianJin(ref int m)
        {
            m = m + 300;
        }

        static void KouKuan(ref int m)
        {
            m = m - 300;
        }

        #region out参数
        static void Test1(out int x)
        {
            //out参数在使用之前必须在方法里面为out参数赋值，
            //out参数无法获取传递进来的变量中的值，只能为传递进来的变量赋值。

            //2.out参数在方法执行完毕之前，必须赋值。

            //Console.WriteLine(x);
            //x = 100;
            //x++;
            x = 100;
        }
        static void Test2(ref int y)
        {
            y++;
        }

        #endregion


        //1.如果方法有多个参数，可变参数必须作为最后一个参数
        //2.可变参数可以传递参数也可以不传递参数，如果不传递参数，则args数组为一个长度为0的数组。
        //3.可变参数可以直接传递一个数组进来。
        static void Test(string msg, params int[] args)
        {
            if (args != null)
            {

            }
        }
    }
}
