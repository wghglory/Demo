using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _03线程池
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 线程池使用

            Console.WriteLine("主线程：" + Thread.CurrentThread.ManagedThreadId);

            //线程池的使用：
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
            {
                Console.WriteLine("方法一：" + Thread.CurrentThread.ManagedThreadId);
                //这里的方法就是要进行异步执行的方法
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(".");
                    Thread.Sleep(300);
                }
            }));

            //线程池的使用：
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
            {
                Console.WriteLine("方法二：" + Thread.CurrentThread.ManagedThreadId);
                //这里的方法就是要进行异步执行的方法
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("=");
                    Thread.Sleep(300);
                }
            }));

            //线程池的使用：
            ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
            {
                Console.WriteLine("方法三：" + Thread.CurrentThread.ManagedThreadId);
                //这里的方法就是要进行异步执行的方法
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("*");
                    Thread.Sleep(300);
                }
            }));
            Console.WriteLine("主线程继续。。。。");
            Console.ReadKey();
            #endregion

            #region 并行计算

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.ReadKey();


            //Stopwatch watch = new Stopwatch();
            watch.Start();
            Parallel.For(0, 5, new Action<int>(i =>
            {
                Console.WriteLine("===" + Thread.CurrentThread.ManagedThreadId + "===");
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }));
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.ReadKey();
            ////Parallel.Invoke(


            #endregion

        }
    }
}
