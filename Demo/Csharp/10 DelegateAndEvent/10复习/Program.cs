using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01复习
{
    public class MyClass
    {
        public Action Md;
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region 复习委托

            //////1.委托是一种数据类型，使用之前先要定义一个委托类型。

            //////2.声明委托变量，创建委托对象
            //////(x,y)=>{return x+y;};
            ////MyDelegate1 md1 = (x, y) => x + y;           // M1;// new MyDelegate1(M1);
            ////int r = md1(10, 100);
            ////Console.WriteLine(r);
            ////Console.ReadKey();

            ////MyDelegate2<int> md2 = (x, y) => x + y;
            ////int r = md2(10, 10);
            ////Console.WriteLine(r);
            ////Console.ReadKey();

            ////无返回值到的委托
            ////Action
            ////Action<string,int> 

            ////有返回值的委托
            ////Func<int, int, int, string> fun;

            //////(x, y) => (x + y).ToString()
            ////M2((x, y) => (x + y).ToString());
            ////Console.ReadKey();

            ////Func<string, string, string> fn = M3();
            ////string result = fn("你", "好");
            ////Console.WriteLine(result);
            ////Console.ReadKey();  

            //MyClass mc = new MyClass();
            //mc.Md = () => { Console.WriteLine("啥都没有。。"); };
            //mc.Md();
            //Console.ReadKey();

            #endregion


            #region 事件

            //List<int> list = new List<int>() { 1, 3, 5, 7, 9 };
            //int sum=list.Sum(x => 2 * x);
            //Console.WriteLine(sum);
            //Console.ReadKey();

            //MyClass1 mc1 = new MyClass1();
            ////为事件注册处理程序
            //mc1.ShiJian += new Action<string>(mc1_ShiJian);
            //mc1.Start();
            //Console.WriteLine("ok");
            //Console.ReadKey();

            #endregion
        }

        static void mc1_ShiJian(string obj)
        {
            Console.WriteLine("某某某事件被触发了，事件中的消息:{0}", obj);
        }

        static void M2(Func<int, int, string> fn)
        {
            Console.WriteLine(fn(100, 200));
        }

        static Func<string, string, string> M3()
        {
            return new Func<string, string, string>((x, y) => x + y);
        }


        static int M1(int x, int y)
        {
            return x + y;
        }
    }

    public class MyClass1
    {
        public event Action<string> ShiJian;

        public void Start()
        {
            if (ShiJian != null)
            {
                //触发事件
                ShiJian(System.DateTime.Now.ToString());
            }
        }
    }


    public delegate void MyDelegate();

    public delegate int MyDelegate1(int n, int m);

    public delegate T MyDelegate2<T>(T t1, T t2);
}
