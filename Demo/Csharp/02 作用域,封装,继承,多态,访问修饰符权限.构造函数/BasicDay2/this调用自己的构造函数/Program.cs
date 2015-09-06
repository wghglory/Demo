using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace this调用自己的构造函数
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p=new Person(
            //string s = "";
            //string s1 = null;
        }
    }

    public class Person
    {

        //使用this来调用本类中的其他构造函数。
        public Person(string name, int age)
            : this(name, age, 0, string.Empty)
        {
            //this.Name = name;
            //this.Age = age;
        }

        ////这个构造函数与上面的那个构造函数重复了！！！！！！,参数列表相同，不叫重载，报错！！！
        //public Person(string name, int height)
        //    : this(name, 0, height, null)
        //{
        //    //this.Name = name;
        //    //this.Height = height;
        //}

        public Person(string name, string email)
            : this(name, 0, 0, email)
        {
            //this.Name = name;
            //this.Email = email;
        }

        public Person(string name, int age, int height, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Height = height;
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
        public int Height
        {
            get;
            set;
        }

    }
}
