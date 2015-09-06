using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _02模拟连接池的使用
{
    class Program
    {
        static void Main(string[] args)
        {

            //假设一个池
            MyConnection[] conPool = new MyConnection[100];
            //声明一个变量来维护当前池中的对象的个数。
            int _count = 0;

            object sync = new object();


            //生产者,假设5个线程同时在进行“生产”→创建对象并加入到conPool池中
            for (int i = 0; i < 5; i++)
            {
                //没循环一次创建一个线程
                Thread t = new Thread(new ThreadStart(() =>
                {
                    //不断的生产对象并加入到conPool池中
                    while (true)
                    {
                        lock (sync)
                        {
                            if (_count < conPool.Length)
                            {
                                //创建一个Connection对象并把该对象加到conPool池中
                                MyConnection connection = new MyConnection();
                                conPool[_count] = connection;
                                _count++;
                                Console.WriteLine("生产了一个对象。");
                            }
                        }
                        Thread.Sleep(300);
                    }
                }));
                t.IsBackground = true;
                t.Start();
            }

            //消费者假设有10个消费者
            //从池中获取对象并使用
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        lock (sync)
                        {
                            //在消费对象前，要判断一下池中是否有可用对象
                            if (_count > 0)
                            {
                                MyConnection con = conPool[_count - 1];
                                Console.WriteLine("使用该对象：" + con.ToString());
                                conPool[_count - 1] = null;
                                _count--;
                            }
                        }
                        Thread.Sleep(50);
                    }
                }));
                t.IsBackground = true;
                t.Start();
            }
            Console.ReadKey();

        }
    }

    //假设这个类型的对象创建起来比较耗时
    public class MyConnection
    {

    }
}
