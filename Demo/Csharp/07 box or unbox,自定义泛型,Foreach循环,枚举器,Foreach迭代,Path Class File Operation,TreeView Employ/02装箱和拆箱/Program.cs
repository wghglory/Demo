using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace _02装箱和拆箱
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 装箱和拆箱
            //int n = 100;
            ////有没有发生装箱？？？
            //string s = Convert.ToString(n);
            //int m = int.Parse(s);
            //Console.ReadKey();


            //int n = 100;
            //object o = n;//发生了一次装箱
            //int m = (int)o; //发生了一次拆箱。
            //int n = 100;
            //IComparable com = n;
            //int m = (int)com;
            //Console.WriteLine(m);
            //Console.ReadKey();

            //Person p = new Student();//?


            ////装箱的时候是什么类型，拆箱的时候也必须使用对应的类型拆箱。
            ////double d = 100.9;
            ////object o = d;
            ////int n = (int)o;
            ////Console.WriteLine(n);
            ////Console.ReadKey();

            //int n = 10;
            //object o = n;
            //double d = (double)o;
            //Console.WriteLine(d);
            //Console.ReadKey();


            //int n = 100;
            //Console.WriteLine(n);//这里调用了int参数的重载，所以没有发生装箱。


            //Console.WriteLine("黄林：{0}，许正龙：{1},杨硕：{2}", 10, 11, 12);
            //Console.ReadKey();

            //int n = 100;
            //int m = 100;

            //Console.WriteLine(n.Equals(m));
            //Console.WriteLine(object.ReferenceEquals(n, m));
            //Console.ReadKey();

            ////int n = 10;
            ////object o = n; //装箱一次
            ////n = 100;
            ////Console.WriteLine(n + "," + (int)o); //拆箱一次
            ////Console.ReadKey();

            //string s = 5 + "====" + 10;
            //Console.WriteLine(s);

            #endregion

            #region 装箱和拆箱性能问题

            //ArrayList arrInt = new ArrayList();
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    arrInt.Add(i);
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //Console.ReadKey();


            //使用泛型集合避免装箱和拆箱。
            //List<int> arrInt = new List<int>();
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < 1000000; i++)
            //{
            //    arrInt.Add(i);
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //Console.ReadKey();

            #endregion

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

    }

    class Student : Person
    {

    }
}
