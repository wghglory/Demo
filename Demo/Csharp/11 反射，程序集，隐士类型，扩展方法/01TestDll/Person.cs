using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01TestDll
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public void SayHi()
        {
            Console.WriteLine("hi!");
        }

        public void SayHello()
        {
            Console.WriteLine("hello");
        }

        public void SayHello(string msg)
        {
            Console.WriteLine(msg);
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
    }

    public delegate void MyDelegate();
    public interface IFlyable
    {
        void Fly();
    }
    public class Teacher : Person
    {

    }
    internal class Student: Person
    {

    }
    public class Myclass : IFlyable
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }

    struct MyStruct
    {

    }

    public enum MyEnum
    {

    }
}
