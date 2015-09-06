using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _01作业问题
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion

            //ArrayList list = new ArrayList();
            //list.Sort();
            //string s = "abc";
            //string s1 = "Abc";
            //int n = s.CompareTo(s1);
            //int m = string.Compare("abc", "ABC");
            //Console.WriteLine(m);
            ////Console.WriteLine(n);
            //Console.ReadKey();

            //int n = 10;
            //int m = 20;
            //n.CompareTo(m)

            #endregion

            // var s ="ffs";
            // s = "dfsdf";
            //// f(s);
            // object sss =123;
            // sss = (int)sss;
            // Console.WriteLine(sss);
            // Console.WriteLine(s);
            // Console.ReadKey();

            //var 叫：【类型推断】
            //1.使用var声明变量与直接使用对应的类型声明变量是完全一样的。
            //编译器在编译时就已经将var替换成了对应的数据类型。
            //int n = 100;
            //var m = 100;
            //2.C#中的var与js中的var完全不一样。C#中的var依然表示强类型，而javascript中的var是弱类型。
            ////以下是js
            //var n = 10;
            //n = "dddd";
            //n = true;
           // var m = 100;
            //var n = 100;
            //Console.WriteLine(n);
            //var m = "hello";
            //Console.WriteLine(m);
            //var p = new Person();
            //Console.WriteLine(p.ToString());
            //Console.ReadKey();

            //var n;
            //Console.WriteLine(n);

            //var只能用作局部变量（方法中声明的变量）。不能用作类的成员变量，不能用作方法的返回值，不能用作方法的参数。

        }

        //static void f(var s)
        //{
        //    s = s + "dfdf";
        //}
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
