using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        private static void Test1()
        {
            Person p = new Person();
            p.Age = 2500;
            Console.WriteLine(p.Age);
            Console.ReadKey();


            //Record("黄林", 19, "男", "15210000000");
            //Record(new Student() { Name = "黄林", Age = 19, Gender = "男", Phone = "1311111111" });
        }


        static void Record(Student student)
        {
            WriteToFile(student);
        }

        private static void WriteToFile(Student student)
        {
            throw new NotImplementedException();
        }

        static void Record(string name, int age, string gender, string phone)
        {
            //....
            WriteToFile(name, age, gender, phone);
        }

        private static void WriteToFile(string name, int age, string gender, string phone)
        {

        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
    }

    class Person
    {
        private int _nianLin;

        public int Age
        {
            get { return _nianLin; }
            set
            {
                if (value < 0 || value >= 120)
                {
                    throw new Exception("年龄错误！");
                }
                else
                {
                    _nianLin = value;
                }
            }
        }

        // public int Age;
    }
}
