using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 通过this与base来调用类中成员
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("张三", 18, "zs@163.com");
            s1.SayHello();
            Console.ReadKey();
        }
    }
    public class Person
    {
        public Person()
        {
            this.Name = "黄林";
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
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

        public void SayHi()
        {
            Console.WriteLine("Say Hi~~");
        }
    }

    public class Student : Person
    {
        public Student(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public void SayHello()
        {
            Console.WriteLine(this.Name); // "张三"
            //Console.WriteLine(this.Sid);

            Console.WriteLine(base.Name); // "黄林"
            Console.WriteLine(base.Email);  //
        }

        public string Sid
        {
            get;
            set;
        }
    }
}
