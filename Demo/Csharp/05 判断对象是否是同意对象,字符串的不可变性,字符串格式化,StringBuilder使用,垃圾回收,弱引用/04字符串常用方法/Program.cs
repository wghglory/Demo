using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04字符串常用方法
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion

            //string msg = "Aa我你他";
            //for (int i = 0; i < msg.Length; i++)
            //{
            //    // msg[i] = msg[i];
            //    Console.WriteLine(msg[i]);
            //}
            //Console.ReadKey();

            //// string msg = "";
            //string msg = null;
            //if (msg == "")
            //{

            //}
            //if (msg == string.Empty)
            //{

            //}
            //if (msg.Length == 0)
            //{

            //}

            ////string s1 = "";
            ////string s2 = null;
            //string s = "";
            //if (string.IsNullOrEmpty(s))
            //{

            //}
            //if (s == null || s.Length == 0)
            //{

            //}

            ////
            //if (value != null)
            //{
            //    return (value.Length == 0);
            //}
            //return true;


            //string s = "abc";
            //char[] chs = s.ToCharArray();
            char[] chs = new char[] { 'a', 'b', 'c' };
            string s = new string(chs);  //abc
            Console.WriteLine(s);
            Console.WriteLine(chs.ToString());   //System.Char[]
            Console.ReadKey();

            //string s = "abc";
            string s1 = "ABC";
            //Console.WriteLine((s == s1));
            //Console.WriteLine(s.Equals(s1));
            Console.WriteLine((s.ToLower() == s1.ToLower()));
            Console.WriteLine(s.ToUpper().Equals(s1.ToUpper()));
            Console.WriteLine(s.Equals(s1, StringComparison.OrdinalIgnoreCase));
            //Console.ReadKey();


            ////截取字符串：
            string msg = "welcome to our country!!!!!";
            msg = msg.Substring(11, 3);   //索引，长度
            ////msg.Substring(
            //Console.WriteLine(msg);
            //Console.ReadKey();
            ////string s=new string(


            //分割字符串Split
            //string msg = "公牛|小牛|快船|森林狼|热火|火箭||||皇马|||||湖人||||曼联|||";
            //string[] names = msg.Split('|');
            string[] names = msg.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.ReadKey();

            //====================================================
            //分割字符串Split
            //string msg = "公牛|小牛|快船|森林狼★热火★火箭|||☆皇马☆阿森纳☆尤文图斯|||||湖人||||曼联|||";
            ////string[] names = msg.Split('|');
            string[] names1 = msg.Split(new char[] { '|','☆','★' }, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}
            //Console.ReadKey();

            //==========================================================
            //string msg = "公牛NBA小牛NBA快船NBA森林狼NBA热火NBA火箭NBANBA西甲皇马西甲阿森纳西甲尤文图斯西甲湖人西甲曼联西甲";
            ////string[] names = msg.Split('|');
            //string[] names = msg.Split(new string[] { "NBA", "西甲" }, StringSplitOptions.RemoveEmptyEntries);
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}
            //Console.ReadKey();

            ////===============================================================
            //string msg = "公牛NBA小牛NBA快船NBA森林狼NBA热火NBA火箭NBANBA西甲皇马西甲阿森纳西甲尤文图斯西甲湖人西甲曼联西甲";
            //string[] names = msg.Split(new string[] { "NBA", "西甲" }, StringSplitOptions.RemoveEmptyEntries);
            //msg = string.Join("→", names);
            //Console.WriteLine(msg);
            //Console.ReadKey();

            ////======replace, join============================
            ////string msg = "北京传智博客.net培训，传智博客php培训，传智博客java培训，传智博客平面设计培训，传智博客ios培训,传智博客云计算培训";
            //string msg = "北京传智博客.net培训，传智博客php培训，传智博客java培训，传智博客平面设计培训，传智博客ios培训,传智博客云计算培训。推荐一款超nb,超绿色视频播放器：xxxx.欢迎访问作者的博客：fdsfdsfdsfdsfdsf";
            //// msg = msg.Replace('博', '播');
            //msg = msg.Replace("传智博客", "传智播客");
            //Console.WriteLine(msg);
            //Console.ReadKey();


            //string msg = "   你                        好    吗？  我   很好。    ";
            ////msg = msg.Trim();
            string[] names2 = msg.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            //msg = string.Join(" ", names);
            //Console.WriteLine(msg);
            //Console.ReadKey();

            //string msg = "";
            msg.Replace(" ", "=").Replace("*", "?");
            #endregion

            Person p = new Person();
            p.SayHello().SayHi();
            //p.SayHello();
            //p.SayHi();
            Console.ReadKey();
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

        public Person SayHi()
        {
            Console.WriteLine("hi!!");
            return this;
        }
        public Person SayHello()
        {
            Console.WriteLine("Hello");
            return this;
        }
    }
}
