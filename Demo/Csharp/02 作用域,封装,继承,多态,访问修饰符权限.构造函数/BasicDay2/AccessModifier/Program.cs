using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccessModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //public
            //protected internal
            //internal
            //protected
            //private

            MyClass mc = new MyClass();
            //mc.

        }
    }

    //直接定义在命名空间中的类型的访问修饰符只能是public 或者 internal
    //private class MyClass2
    //{


    //}

    class MyClass
    {
        //类的成员变量，如果不写访问修饰符默认是private

        int ww = 10;

        void SayHi()
        {
            Console.WriteLine("fdsfds");
        }

        //类本身如果不写访问修饰符则默认为internal


        //只有在当前类内部可以访问
        private int n = 10;

        //1.当前类内部以及所有的子类的内部。
        protected int m = 100;

        //当前程序集内部
        internal int x = 1000;

        //同时具有protected与internal的访问权限
        protected internal int y = 10000;

        //任何地方都能访问
        public int w = 100000;

        public void M1()
        {
            Console.WriteLine(n);
        }
    }

    class MyClass1 : MyClass
    {
        public void M2()
        {
            Console.WriteLine(m);
        }
    }
}
