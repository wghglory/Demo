using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _01定义接口
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlyable fly = new MyClass();

            fly.SayHi();
        }
    }

    //接口不能实例化
    //接口就是让子类来实现的。

    //1.接口可以实现“多继承”（多实现），一个类只能继承自一个父类，但是可以实现多个接口。
    //2.接口解决了不同类型之间的多态问题，比如鱼与船不是同一类型，但是都能在水里“游泳”，只是方式不一样，要对“游泳”实现多态，就只能考虑接口。

    //定义一个接口，建议：一定要以大写I开头
    public interface IFlyable
    {
        //接口里面能包含什么成员,接口里面只能包含【方法】
        //方法、属性、索引器、事件  →  “方法”

        //接口中的所有成员，都不能显示的 写任何访问修饰符
        //默认是public的访问修饰符

        void SayHi();

        void M1(string msg);

        //在接口中这样写表示是一个未实现的属性。
        string Name
        {
            get;
            set;
        }

        //索引器
        string this[int index]
        {
            get;
            set;
        }
    }

    //接口中的成员，子类必须实现
    public class MyClass : IFlyable
    {

        #region IFlyable 成员

        public void SayHi()
        {
            throw new NotImplementedException();
        }

        public void M1(string msg)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
