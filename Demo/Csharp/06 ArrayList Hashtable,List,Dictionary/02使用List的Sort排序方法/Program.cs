using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02使用List的Sort排序方法
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            //list.Add(new Person() { Name = "TangSanZang", Age = 180, Email = "ts@163.com" });
            //list.Add(new Person() { Name = "huaguoshanSunWuKong", Age = 19, Email = "wk@163.com" });
            //list.Add(new Person() { Name = "tianpengdayuanshuaiZhuBaJie", Age = 20, Email = "wn@163.com" });

            list.Add(new Student() { Name = "TangSanZang", Age = 180, Email = "ts@163.com" });
            list.Add(new Student() { Name = "huaguoshanSunWuKong", Age = 19, Email = "wk@163.com" });
            list.Add(new Student() { Name = "tianpengdayuanshuaiZhuBaJie", Age = 20, Email = "wn@163.com" });


            //list.Sort(new PersonCompareByAgeAsc());
            list.Sort(new PersonCompareByNameLengthDesc());

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
            }
            Console.ReadKey();

        }
    }


    //public class MyClass<T> where T : Person
    //{

    //}


    public class Student : Person
    {

    }


    public class PersonCompareByAgeAsc : IComparer<Person>
    {

        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }

    public class PersonCompareByAgeAsc1<T> : IComparer<T> where T : Person
    {

        public int Compare(T x, T y)
        {
            return x.Age - y.Age;
        }
    }

    public class PersonCompareByNameLengthDesc : IComparer<Person>
    {

        public int Compare(Person x, Person y)
        {
            return y.Name.Length - x.Name.Length;
        }
    }

    public class Person
    {
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

    }
}
