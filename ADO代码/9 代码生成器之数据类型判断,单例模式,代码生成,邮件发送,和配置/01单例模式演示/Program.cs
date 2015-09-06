using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01单例模式演示
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton model = new Singleton();
            //Singleton m1 = new Singleton();
            Singleton m1 = Singleton.CreateInstance();
            Singleton m2 = Singleton.CreateInstance();
            Console.WriteLine(object.ReferenceEquals(m1, m2));
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 名字叫Singleton的这个类将来只能new一个对象
    /// </summary>
    public class Singleton
    {
        private static Singleton _instance;

        private static readonly object syn = new object();

        //1.当把类的构造函数设置为private的以后，则该类不能在外界被new了。
        private Singleton()
        {

        }
        //2.在当前类型中创建一个静态方法，用该静态方法来返回一个对象
        public static Singleton CreateInstance()
        {
            if (_instance == null)
            {
                lock (syn)
                {
                    if (_instance==null)
                    {
                        _instance = new Singleton();
                    }
                }
                
            }
            return _instance;
        }
    }
}
