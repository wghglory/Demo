using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student s1 = new Student();
            //Teacher t1 = new Teacher();
            //Person p = new Person();

            //1.继承的好处
            //1>代码重用
            //2>多态。

            //LSP//里氏替换原则

            //Student s1 = new Student();
            //Teacher t1 = new Teacher();


            //多态  → 增加程序的可扩展性、灵活性。
            //需要一个父类类型时，给一个子类类型对象是可以的。这个就叫做里氏替换原则
            Person p1 = new Student();

            Person p2 = new Teacher();

            Animal a1 = new Student();

            //这样做不行！！！！！！！
            //Teacher t1 = new Student();

            Student s1 = (Student)p1;
            Student s2 = (Student)p2;

        }
    }

    class Animal : Object
    {
        public void Bark()
        {
            Console.WriteLine("叫...");
        }
    }
    //继承的“单根性”
    //“传递性”
    class Person : Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public void Eat()
        {
            Console.WriteLine("eat");
        }
        public void Sleep()
        {
            Console.WriteLine("sleep");
        }
    }

    class Student : Person
    {
        //public string Name { get; set; }
        //public int Age { get; set; }
        //public int Height { get; set; }

        public void SayHi()
        {
            Console.WriteLine("hi~~~");
        }

    }

    class Teacher : Person
    {
        //public string Name { get; set; }
        //public int Age { get; set; }
        //public int Height { get; set; }

        public double Salary { get; set; }

    }
}
