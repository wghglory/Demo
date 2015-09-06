using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05逆变与协变
{
    class Program
    {
        static void Main(string[] args)
        {
            ////string s = "aaaaa";
            ////object o = s;//因为具有父子类关系。类型转换“兼容”
            ////Console.WriteLine(o);
            ////Console.ReadKey();

            //string s = "aaaa";
            //object o = s;
            //string s1 = (string)o;
            //Console.WriteLine(s1);
            //Console.ReadKey();
            //x > y    ==> f1(x) >f2(y)


            string[] strs = new string[] { "aaa", "bbbb", "cccc" };
            //因为.net的特性：“协变”
            //对于数组的”协变“从.net2.0开始支持了。
            object[] objs = strs;
            foreach (var item in objs)
            {
                Console.WriteLine(item);
            }
            //数组虽然可以协变，但是这种协变是unsafe的“类型不安全的。”
            objs[0] = new object();
            Console.WriteLine("-----------------------------");
            string[] strs1 = (string[])objs;
            foreach (var item in strs1)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();


            //int[] n = new int[] { 1, 23, 5 };
            ////下面这句代码不行，协变与逆变只针对引用类型。
            //object[] objs = n;
            //Console.WriteLine("ok");
            //Console.ReadKey();

        }
    }
}
