using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04多态2通过抽象类实现多态
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass mc = new MyClass();
            MyClass mc = new MyClass1();
            mc.SayHi();   //子类中的SayHi方法.
            Console.ReadKey();
        }
    }

    //3.抽象成员必须包含在抽象类中。
    //4.抽象类不能用来实例化对象,既然抽象类不能被实例化，那么抽象类的作用就是用来被“继承”的。继承的主要目的就是用来实现多态。
    abstract class MyClass
    {
        //1.抽象类中可以有实例成员，也可以有抽象成员

        public int Age
        {
            get;
            set;
        }

        //2.抽象成员不能有任何实现
        //5.抽象成员子类继承以后必须“重写”override,除非子类也是一个抽象类
        public abstract void SayHi();
    }

    class MyClass1 : MyClass
    {
        public override void SayHi()
        {
            Console.WriteLine("子类中的SayHi方法.");
        }
    }
    abstract class MyClass2 : MyClass
    {

    }
}
