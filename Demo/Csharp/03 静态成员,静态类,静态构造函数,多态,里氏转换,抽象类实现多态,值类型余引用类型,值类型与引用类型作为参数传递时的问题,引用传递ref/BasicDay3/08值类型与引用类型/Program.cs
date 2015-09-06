using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08值类型与引用类型
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 值类型与引用类型

            //int n = 100;

            //值类型赋值的时候将栈中的数据拷贝了一个副本。
            //int m = n;
            //m = m + 1;
            //Console.WriteLine(m);
            //Console.WriteLine(n);
            //Console.ReadKey();
            //==========================================================================

            Person p = new Person();
            p.Name = "黄林";


            //引用类型赋值的时候是将栈中的地址拷贝了一个副本。
            Person p1 = p;

            p1.Name = "许正龙";


            Console.WriteLine(p.Name);   //"许正龙"

            Console.WriteLine();
            Console.ReadKey();

            #endregion


            #region 案例,值类型与引用类型参数 进行  “值传递”时的情况


            //int number = 100;

            //M1(number);  

            //Console.WriteLine(number); //???????  100
            //Console.ReadKey();


            ////========================================
            //int[] arr = new int[] { 1, 2, 3 };  //引用类型的值传递

            //M2(arr);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);//????????  2 4 6 
            //}
            //Console.ReadKey();


            ////=============================================
            //int[] arr1 = new int[] { 1, 2, 3 };

            //M3(arr1);

            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    Console.WriteLine(arr1[i]); //??????????  1 2 3
            //}
            //Console.ReadKey();
            ////=====================================================


            //Person hl = new Person();
            //hl.Name = "黄林";
            //M4(hl);
            //Console.WriteLine(hl.Name);//???????????黄林

            ////=====================================================

            //Person zdd = new Person();
            //zdd.Name = "郑丹丹";
            //M5(zdd);
            //Console.WriteLine(zdd.Name);//?????????? 苏坤
            //Console.ReadKey();

            ////============================================
            //Person zdd = new Person();
            //zdd.Name = "郑丹丹";
            //M6(zdd);
            //Console.WriteLine(zdd.Name);//??????????郑丹丹
            //Console.ReadKey();

            #endregion

        }

        static void M6(Person p1)
        {    
            p1 = new Person();
            p1.Name = "苏坤";
            p1.Name = "许正龙";
        }
        static void M5(Person p1)
        {
            p1.Name = "苏坤";
            p1 = new Person();
            p1.Name = "许正龙";
        }

        static void M4(Person p)
        {
            Person px = new Person();
            px.Name = "马毅";
            p = px;
        }


        static void M3(int[] arrArg)
        {
            arrArg = new int[] { 9, 10, 11 };
        }

        static void M2(int[] arrArg)
        {
            for (int i = 0; i < arrArg.Length; i++)
            {
                arrArg[i] = arrArg[i] * 2;
            }
        }

        //"闷声发大财，too simple"
        static void M1(int m)
        {
            m = m + 1;
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
}
