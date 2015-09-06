using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07接口练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //IFlyable fly = new Student();
            //fly.Fly();
            //fly.Swim();
            //Console.ReadKey();
        }
    }

    public interface IFlyable
    {
        void Fly();

        void Swim();
    }

    public class Person : IFlyable
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

        #region IFlyable 成员

        public void Fly()
        {
            Console.WriteLine("飞...");
        }

        public void Swim()
        {
            Console.WriteLine("游...");
        }

        #endregion
    }

    //public class Student : Person, IFlyable
    //{

    //}


}
