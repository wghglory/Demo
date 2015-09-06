using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace _03异步调用委托
{
    class Program
    {
        static void Main(string[] args)
        {

            //正常的方法调用, 主方法被阻塞，等待委托里面方法完成
            //MyDelegate md = new MyDelegate(GetSum);
            //int sum = md(1, 30);
            //Console.WriteLine("主方法中输出的Sum：{0}", sum);
            //Console.ReadKey();


            //1.异步调用委托不需要返回值============================================
            MyDelegate md1 = new MyDelegate(GetSum);
            md1.BeginInvoke(1, 30, null, null);//AsyncCallBack委托接受回调方法，object为回调方法参数
            Console.WriteLine("主线程继续........");
            Console.ReadKey();

            //2.异步调用委托并获取方法的返回值======================================
            MyDelegate md2 = new MyDelegate(GetSum);
            //开始异步调用委托
            //BeginInvoke()返回值就是返回了一个对象，这个对象实现了IAsyncResult接口，并且该对象中封装了一些关于当前异步执行的委托的一些状态信息。
            IAsyncResult asyncResult = md2.BeginInvoke(1, 30, null, null);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("主线程继续执行.." + i);
            }

            //调用EndInvoke会阻塞线程，等待异步委托执行完毕。
            int sum = md2.EndInvoke(asyncResult);
            Console.WriteLine("方法执行的返回值为：{0}", sum);
            Console.WriteLine("主线程继续........");
            Console.ReadKey();
       

            //3.异步调用委托使用回调函数避免EndInvoke阻塞线程=========================
            Console.WriteLine("===================主线程Id:{0}", Thread.CurrentThread.ManagedThreadId);
            MyDelegate md3 = new MyDelegate(GetSum);
            IAsyncResult result = md3.BeginInvoke(1, 30, new AsyncCallback(Callback), "Test");

            Console.WriteLine("主线程继续执行。。。。。");
            Console.ReadKey();
        }

        //该回调函数有系统自动调用，当指定的异步委托调用完毕后，自动调用该方法
        static void Callback(IAsyncResult syncResult)
        {

            Console.WriteLine("===================回调函数中的线程Id:{0}", Thread.CurrentThread.ManagedThreadId);
            //syncResult.AsyncState获取的就是BeginInvoke()中的最后一个参数。
            Console.WriteLine("回调函数的参数：{0}", syncResult.AsyncState);
            //在回调函数中调用EndInvoke()方法就可以获取返回值。

            //需要把接口类型转换为具体的对象
            AsyncResult ar = syncResult as AsyncResult;
            int sum = ((MyDelegate)ar.AsyncDelegate).EndInvoke(ar);
            Console.WriteLine("返回值是：{0}", sum);
        }

        static int GetSum(int n1, int n2)
        {
            Console.WriteLine("===================异步调用的函数GetSum中的线程Id:{0}", Thread.CurrentThread.ManagedThreadId);

            int sum = 0;
            for (int i = n1; i <= n2; i++)
            {
                sum += i;
                Thread.Sleep(100);
            }
            Console.WriteLine("方法中输出的结果：{0}", sum);
            return sum;
        }
    }

    public delegate int MyDelegate(int n1, int n2);

}
