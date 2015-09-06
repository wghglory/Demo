using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDay2
{
    public class Student
    {
        //定义好一个类以后，不写构造函数会有一个默认的无参数的构造函数

        //当为类手动编写一个构造函数后，会覆盖默认的那个构造函数。
        //只要手动添加了构造函数就把默认的构造函数覆盖了。
        public Student(string name, int age, string gender, string sid)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.SId = sid;
        }

        //public Student(string name)
        //{
        //    this.Name = name;
        //}

        public string Name { get; set; }
        public string Gender { get; set; }
        public string SId { get; set; }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { this._age = value; }
        }

        public void SayHi()
        {
            Console.WriteLine("hi!!");
        }

    }
}
