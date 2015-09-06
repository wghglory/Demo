using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02字符串的特性1_不可变性
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 字符串的不可变性1
            ////1.字符串一旦被创建就不可修改。
            string s22 = "Hello World!";
            s22 = s22.ToUpper();
            Console.WriteLine(s22);  //HELLO WORLD, 新开辟一个大写字母的空间，s22从Hello指向HELLO了
            Console.ReadKey();

            //string s1 = "abc";
            //string s2 = "x";
            //s1 = s1 + s2;
            //Console.WriteLine(s1);   //abcx
            //Console.ReadKey();
            #endregion

            #region 字符串不可变性2

            ////string a = "a";
            ////string b = "b";
            ////string c = "c";
            ////a = a + b;
            ////a = a + c;     //abc

            //===============================================
            //string a = "a";
            //a = a + "b";
            //a = a + "c";
            //Console.WriteLine(a);    //abc, 开辟了5个空间，4个垃圾，浪费内存
            //Console.ReadKey();
            #endregion

            #region 字符串池
            string s1111 = new string(new char[] { 'a', 'b', 'c' });
            string s2222 = new string(new char[] { 'a', 'b', 'c' });  //vs2010   immediate window *s2222
            //s2222 = s1111;

            // string s1 = "abc";
            //string s2 = "abc";

            //"afdsafdsfdsf"
            //"fdsafdsafdsfdsfsaf"
            //string s = "dfjdsafdslkffaf";

            //string a = "a";
            //string b = "b";
            //string c = "c";
            //string s2 = a + b + c;
            ////string s2 = "a" + "b" + "c";

            string s = "a";
            string s1 = "b";
            string s2 = s + s1;
            //string.Intern(s2);
            //string.IsInterned(s2
            //Console.WriteLine(s2);
            Console.ReadKey();

            #endregion

        }
    }
}
