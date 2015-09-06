using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverrideAndNew
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = 10;

            //float f = 9.8F;

            //bool b = false;

            ////C#语言的整型
            //int n = 100;
            //n++;
            //Console.WriteLine(n);


            ////.net中的整型
            //Int32 x = 200;
            //x++;
            //Console.WriteLine(x);

            //string s;
            //String ss;


            //Console.ReadKey();

            ParentClass a = new A();
            a.M1();
            //((A)a).M1();
            Console.ReadKey();
        }
    }

    class ParentClass
    {
        public virtual void M1()
        {
            Console.WriteLine("爷爷类中的M1");
        }
    }

    class A : ParentClass
    {
        public override void M1()
        {
            Console.WriteLine("A类中的M1");
        }

        //这个表示子类全新的添加了一个M1方法，为什么可以添加一个和父类中的M1方法一模一样的方法呢？
        //因为这里用了new关键字，将从父类中继承下来的那个M1方法给隐藏掉了。
        //所以此时，这个类中只有一个M1方法.通过this.M1()调用的一定是子类中的全新的这个M1方法，
        //但是如果通过base.M1()则调用的是父类中原来的那个M1方法。

        //public new void M1()   //method hiding
        //{
        //    Console.WriteLine("A类中的new M1");
        //}
    }

    class B : A
    {
        public override void M1()  //override A中的M1,要求A的M1需要时override/virtual/abstract
        {
            Console.WriteLine("B类中的M1");
        }
    }
}

