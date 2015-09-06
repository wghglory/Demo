using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06抽象类练习
{
    class Program
    {
        static void Main(string[] args)
        {
            //练习1：动物Animal   都有吃Eat的方法和Bark()叫，狗Dog和猫Cat叫的方法不一样.父类中没有默认的实现所哟考虑用抽象方法。
            Animal animal = new Cat();//new Dog();
            animal.Eat();
            animal.Bark();
            Console.ReadKey();

            //练习2：计算形状Shape(圆Circle，矩形Square ，正方形Rectangle)的面积、周长

            Shape shape = new Rectangle(100, 20);//new Circle(20);
            Console.WriteLine("周长：{0}", shape.GetGirth());

            Console.WriteLine("面积：{0}", shape.GetArea());
            Console.ReadKey();

        }
    }

    //class A
    //{
    //    public int L1 { get; set; }
    //    public int L2 { get; set; }
    //    public int L3 { get; set; }
    //    public int L4 { get; set; }
    //}

    abstract class Shape
    {
        public abstract double GetArea();

        public abstract double GetGirth();
    }

    class Circle : Shape
    {
        public Circle(double r)
        {
            this.R = r;
        }

        public double R
        {
            get;
            set;
        }

        public override double GetArea()
        {
            return Math.PI * this.R * this.R;
        }

        public override double GetGirth()
        {
            return 2 * Math.PI * this.R;
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }
        public double Length
        {
            get;
            set;
        }
        public double Width
        {
            get;
            set;
        }


        public override double GetArea()
        {
            return Length * Width;
        }

        public override double GetGirth()
        {
            return 2 * (Length + Width);
        }
    }

    //==============================================================================
    abstract class Animal
    {
        public abstract void Eat();

        public abstract void Bark();
    }

    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("狗吃骨头!");
        }

        public override void Bark()
        {
            Console.WriteLine("汪汪！");
        }
    }

    class Cat : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("猫吃鱼！！！");
        }

        public override void Bark()
        {
            Console.WriteLine("喵喵叫！！！");
        }
    }
}
