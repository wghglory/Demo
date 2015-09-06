using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _01lock演示
{
    class Program
    {
        static int max = 10000000;
        static long _count = 0;

        //锁的使用步骤：
        //1.建立一个锁对象,锁对象必须是一个引用类型。
        //如果使用值类型，会在枷锁解锁时造成装箱问题，加锁时使用的是一个对象，解锁时使用的是另外一个对象。
        static readonly object objSync = new object();
        static void Main(string[] args)
        {
            #region 代码1
            ////1.递增
            //for (int i = 0; i < max; i++)
            //{
            //    _count++;
            //}

            ////2.递减
            //for (int i = 0; i < max; i++)
            //{
            //    _count--;
            //}
            //Console.WriteLine("_count结果是：{0}", _count);
            //Console.ReadKey();

            #endregion

            #region 代码2
            //Thread t1 = new Thread(new ThreadStart(() =>
            //{
            //    //1.递增
            //    for (int i = 0; i < max; i++)
            //    {
            //        _count++;
            //        //_count = _count + 1;
            //    }
            //}));
            //t1.Start();
            //Console.WriteLine("t1线程已经启动，开始对_count变量++");
            //Console.WriteLine("主线程继续执行.....");
            ////2.递减
            //for (int i = 0; i < max; i++)
            //{
            //    _count--;
            //}

            ////到这里的时候要保证主线程的--操作与t1线程的++操作都执行完毕
            ////等待t1执行完毕
            //t1.Join();
            //Console.WriteLine("_count结果是：{0}", _count);
            //Console.ReadKey();

            #endregion

            #region 解决并发访问变量问题


            Thread t1 = new Thread(new ThreadStart(() =>
            {
                //1.递增
                for (int i = 0; i < max; i++)
                {
                    lock (objSync)
                    {
                        //在lock块中的代码同时只能有一个线程来访问。
                        _count++;
                    }


                    ////标记当前是否已经上锁
                    //bool isLockOk = false;
                    ////上锁
                    //Monitor.Enter(objSync, ref isLockOk);
                    //try
                    //{
                    //    _count++;
                    //}
                    //finally
                    //{
                    //    if (isLockOk)
                    //    {
                    //        Monitor.Exit(objSync);
                    //    }
                    //}


                }
            }));
            t1.Start();
            Console.WriteLine("t1线程已经启动，开始对_count变量++");
            Console.WriteLine("主线程继续执行.....");
            //2.递减
            //加锁后执行变慢！！
            for (int i = 0; i < max; i++)
            {
                lock (objSync)
                {
                    _count--;
                }

            }

            //到这里的时候要保证主线程的--操作与t1线程的++操作都执行完毕
            //等待t1执行完毕
            t1.Join();
            Console.WriteLine("_count结果是：{0}", _count);
            Console.ReadKey();
            #endregion


        }
    }
}
