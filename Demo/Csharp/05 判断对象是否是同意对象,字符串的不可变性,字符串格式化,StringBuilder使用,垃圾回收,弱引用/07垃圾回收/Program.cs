using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07垃圾回收
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 垃圾回收1

            ////Person p = new Person();

            ////p.Name = "hello";

            ////Person p1 = p;


            ////p = null;


            ////p1 = null;

            //Person p1 = new Person();
            //Person p2 = new Person();
            //Person p3 = new Person();


            //Person[] pers = new Person[3];
            //pers[0] = p1;
            //pers[1] = p2;
            //pers[2] = p3;

            //p1 = null;
            //p2 = null;
            //p3 = null;

            ////pers[0]



            ////垃圾回收是.net ClR自动来执行的。一般不需要手动干预。
            ////GC.Collect();



            ////=========
            //Console.WriteLine("===========================");
            //Console.ReadKey();

            #endregion

            #region 垃圾回收2

            ////GC.Collect();
            //int n = GC.MaxGeneration;
            //Console.WriteLine(n);
            //GC.Collect(0);
            //GC.Collect(1);
            //GC.Collect(2);
            //Console.ReadKey();


            //MyClass mm = new MyClass();
            //mm.Do();
            //mm.Dispose();

            using (MyClass mm = new MyClass())
            {
            }
            //mm.Dispose();
            //using (mm)
            //{

            //}
            Console.WriteLine("ok");
            Console.ReadKey();
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

    class MyClass : IDisposable
    {
        public MyClass()
        {

        }

        public void Do()
        {
            //internal static extern void InternalBlockCopy(Array src, int srcOffsetBytes, Array dst, int dstOffsetBytes, int byteCount);
        }

        //public void shifang()
        //{

        //}


        //这个“析构”
        ~MyClass()
        {

        }

        #region IDisposable 成员

        public void Dispose()
        {
            //.............
            //释放非托管资源
            Console.WriteLine("Dispose....");
        }

        #endregion
    }
}
