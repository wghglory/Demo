using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11ref与out练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 交换两个变量


            //int m = 10, x = 20;
            //Swap(ref m, ref x);
            //Console.WriteLine(m);
            //Console.WriteLine(x);
            //Console.ReadKey();


            #endregion

            #region 用户登录练习
            while (true)
            {
                Console.WriteLine("请输入用户名：");
                string uid = Console.ReadLine();
                Console.WriteLine("请输入密码：");
                string pwd = Console.ReadLine();
                string msg;
                bool isOk = ValidUserLogin(uid, pwd, out msg);
                if (isOk)
                {
                    Console.WriteLine("登录成功====》{0}", msg);
                }
                else
                {
                    Console.WriteLine("登录失败====》{0}", msg);
                }
            }



            #endregion
        }


        static void Method1(string msg)
        {
        }
        static void Method1(int n)
        {
        }
        static void Method1(ref int n)
        {
        }
        static void Method1(ref string msg)
        {
        }
        //static void Method1(out string msg)
        //{
        //    msg = "";
        //}

        private static bool ValidUserLogin(string uid, string pwd, out string msg)
        {
            bool isok = false;
            if (uid != "admin")
            {
                msg = "用户名错误";
            }
            else if (pwd != "888888")
            {
                msg = "密码错误";
            }
            else
            {
                isok = true;
                msg = "欢迎用户：" + uid;
            }
            return isok;
        }

        static void Swap(ref int n1, ref int n2)
        {
            int tmp = n1;
            n1 = n2;
            n2 = tmp;
        }
    }
}
