using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04鸭子接口演示
{
    class Program
    {
        static void Main(string[] args)
        {
            IBark duck = new RealDuck();//new RubberDuck();
            duck.Bark();
            Console.ReadKey();
        }
    }
    public class Duck
    {
        public void Swim()
        {
            Console.WriteLine("鸭子水上漂.....");
        }
    }
    public interface IBark
    {
        void Bark();
    }


    public class RealDuck : Duck, IBark
    {
        #region IBark 成员

        public void Bark()
        {
            Console.WriteLine("嘎嘎叫...");
        }

        #endregion
    }

    public class WoodDuck : Duck
    {

    }

    public class RubberDuck : Duck, IBark
    {

        #region IBark 成员

        public void Bark()
        {
            Console.WriteLine("唧唧叫...");
        }

        #endregion
    }
}
