using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07抽象类练习2
{
    public abstract class Duck
    {
        public void Swim()
        {
            Console.WriteLine("鸭子水上漂....");
        }

        public abstract void Bark();
    }

    public class RubberDuck : Duck
    {

        public override void Bark()
        {
            Console.WriteLine("橡皮鸭子唧唧叫!!!");
        }
    }

    public class RealDuck : Duck
    {

        public override void Bark()
        {
            Console.WriteLine("真鸭子嘎嘎叫...");
        }
    }
}
