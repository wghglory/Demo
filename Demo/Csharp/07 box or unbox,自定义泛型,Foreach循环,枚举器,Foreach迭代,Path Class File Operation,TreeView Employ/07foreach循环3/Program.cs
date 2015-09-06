using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _07foreach循环3
{
    class Program
    {
        static void Main(string[] args)
        {

            //string[] ss = { "a", "b", "c" };
            //IEnumerable ie = ss;
            //foreach (var item in ie)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            #region method 1

            Person p = new Person();

            foreach (var item in p.GetEachObj())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            #endregion

            #region method 2

            //Person p1 = new Person();
            //foreach (var item in p1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            // IEnumerator
            #endregion

        }
    }

    //method 1
    public class Person
    {

        public IEnumerable GetEachObj()
        {
            for (int i = 0; i < Friends.Length; i++)
            {
                yield return Friends[i];
            }
        }


        private string[] Friends = new string[] { "黄林", "许正龙", "彭德怀", "杨硕" };
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

    //method 2:
    //public class Person
    //{
    //    private string[] Friends = new string[] { "黄林", "许正龙", "彭德怀", "杨硕", "马毅" };
    //    public string Name
    //    {
    //        get;
    //        set;
    //    }
    //    public int Age
    //    {
    //        get;
    //        set;
    //    }
    //    public string Email
    //    {
    //        get;
    //        set;
    //    }


    //    //当返回值类型是IEnumerator时，编译器帮我们生成了一个“枚举器”类，即：一个实现了IEnumerator接口的类型。
    //    public IEnumerator GetEnumerator()
    //    {
    //        for (int i = 0; i < Friends.Length; i++)
    //        {
    //            yield return Friends[i];
    //        }
    //    }
    //}

}
