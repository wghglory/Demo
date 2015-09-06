using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03自定义泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass<string> mc = new MyClass<string>();
            MyClass<string, int, double, string, bool, int> mc = new MyClass<string, int, double, string, bool, int>();
            mc.SayHi("你们好吗？同学们。");
            Console.ReadKey();

            //Class3<int> c3 = new Class3<int>();
            //c3.SayHello(
        }
    }

    //泛型类
    public class MyClass<HL, K, V, W, Y, Z>
    {
        public void SayHi(HL arg)
        {
            Console.WriteLine(arg);
        }
    }

    public class Class1
    {
        //这是一个泛型方法
        public void SayHello<T>(T msg)
        {
            Console.WriteLine(msg);
        }
    }

    public interface IFace<T>
    {
        T SayHi();
        void SayHello(T msg);
    }

    //实现泛型接口的时候有两种情况：
    //1。普通类来实现泛型接口
    public class Class2 : IFace<string>
    {
        #region IFace<string> 成员

        public string SayHi()
        {
            throw new NotImplementedException();
        }

        public void SayHello(string msg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    //2.泛型类，实现泛型接口
    public class Class3<U> : IFace<U>
    {
        #region IFace<U> 成员

        public U SayHi()
        {
            throw new NotImplementedException();
        }

        public void SayHello(U msg)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
