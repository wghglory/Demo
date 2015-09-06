using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inheritance2
{
    class Program
    {
        static void Main(string[] args)
        {
            //object o = new object();
            //if (o is object)
            //{

            //}

            //Student stu = new Student("黄林", 18, 175, "001");
        }
    }

    class Person
    {
        public Person(string name, int age, int height)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
        }

        ////解决办法一：在父类中添加一个无参数的构造函数
        public Person()
        {

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }

    class Student : Person
    {
        //当一个子类继承父类以后，该子类中的所有构造函数默认情况下，在自己被调用之前都会先调用一次父类的无参数的构造函数，如果此时父类中没有无参数的构造函数，则提示报错！
        public Student(string name, int age, int height, string sid)
        {
            this.SId = sid;
            this.Name = name;
            this.Age = age;
            this.Height = height;
        }

        public string SId { get; set; }
    }

    class Teacher : Person
    {
        //public Teacher(string name, int age, int height, string empId)
        //{
        //    this.Name = name;
        //    this.Age = age;
        //    this.Height = height;
        //    this.EmpId = empId;
        //}

        //解决办法二：在子类的构造函数后面通过:base()的方式，明确指定要调用父类中的那个构造函数。
        public Teacher(string name, int age, int height, string empId)
            : base(name, age, height) //:base()表示调用父类的构造函数 ,//构造函数是不能被继承的。
        {
            this.EmpId = empId;
        }

        public string EmpId { get; set; }
    }
}
