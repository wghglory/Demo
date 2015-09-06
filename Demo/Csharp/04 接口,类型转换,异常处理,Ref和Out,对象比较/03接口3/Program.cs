using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03接口3
{
    class Program
    {

        //虚方法是父类有实现，有一个方法有内容，这个父类需要被实例化，子类override父类方法

        //抽象方法，父类中有方法，但不能有实现，父类以及父类中方法标记abstract，不需要被实例化。子类override父类方法

        //接口是多个不相关的类比如车和人，但是具有通用的能力（登记车辆和人），接口有方法，不能被实现。继承接口的类必须实现方法！

        static void Main(string[] args)
        {
            Chinese cn = new Chinese();
            American am = new American();
            //DengJi(cn);
            Car lbjn = new Car();

            DengJi(cn);
            Console.ReadKey();
        }

        public static void DengJi(IShowInfo dengJiObj)
        {
            dengJiObj.Show();
        }

        //public static void DengJi(Person person)
        //{
        //    person.Show();
        //}

        //public static void DengJi(Chinese cn)
        //{
        //    cn.Show();
        //}
        //public static void DengJi(American usa)
        //{
        //    usa.Show();
        //}
    }

    public interface IShowInfo
    {
        void Show();
    }

    public abstract class Person : IShowInfo
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        public abstract void Show();
    }

    class Chinese : Person
    {
        public override void Show()
        {
            Console.WriteLine("中国，18岁，。。。。");
        }

    }

    class American : Person
    {
        public override void Show()
        {
            Console.WriteLine("美国，19岁，。。。。");
        }
    }


    class German : Person
    {
        public override void Show()
        {
            Console.WriteLine("德国，29岁，。。。。");
        }
    }

    class Car : IShowInfo
    {

        #region IShowInfo 成员

        public void Show()
        {
            Console.WriteLine("兰博基尼,6.0,。。。。。。");
        }
        #endregion
    }
}
