using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01判断是否为同一个对象
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1

            Person p1 = new Person();
            p1.Name = "黄林";
            p1.Age = 18;
            p1.Email = "hl@yahoo.com";

            Person p2 = new Person();
            p2.Name = "黄林";
            p2.Age = 18;
            p2.Email = "hl@yahoo.com";

            //p2 = p1; 则以下都是true

            //Console.WriteLine(p1 == p2); //?????false
            //Console.WriteLine(p1.Equals(p2));//????false

            Console.WriteLine(object.ReferenceEquals(p1, p2));//???false
            Console.ReadKey();
            #endregion

            #region 2

            //这两个s1与s2是两个不同的对象，因为new了两次，在堆中确实存在两块不同的内存。
            string s1 = new string(new char[] { 'a', 'b', 'c' });
            string s2 = new string(new char[] { 'a', 'b', 'c' });

            //下面的s1与s2确实是同一个对象。
            //string s1 = "abc";
            //string s2 = "abc";

            //对于字符串类型来说，重载了Equals()方法，在这个重载的方法中其实是判断的两个字符串中的字符是否完全一样，如果一样就返回true，并不是判断两个对象是否为同一个对象。

            //并且字符串类也重写了object类中的Equals方法，在该方法中也是判断的两个字符串中的字符是否完全一样，如果一样就返回true，并不是判断两个对象是否为同一个对象。

            //在字符串类中，有一个操作符重载，对==这个操作符进行了重载，在该重在函数中也是对字符的内容作了判断，所以==表现出了与Equals()同样的效果。
            Console.WriteLine(s1 == s2);//???true
            Console.WriteLine(s1.Equals(s2));//??true

            //总结1：使用object.ReferenceEquals()可以始终准确验证两个变量是否为同一个对象。
            Console.WriteLine(object.ReferenceEquals(s1, s2));//???false
            Console.ReadKey();

            #endregion

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
        public virtual void SayHi()
        {
            Console.WriteLine("hi~~~");
        }
    }

    public class MyClass : Person
    {
        public sealed override void SayHi()
        {
            base.SayHi();
        }
    }

    public class MyClass1 : MyClass
    {
        //public override void SayHi()
        //{
        //    base.SayHi();
        //}
    }

    static class MyStaticClass
    {

    }

    //public sealed class Person
    //{
    //    public string Name
    //    {
    //        get;
    //        set;
    //    }
    //    public int Age
    //    {
    //        get;
    //        set;
    //    }
    //    public string Email
    //    {
    //        get;
    //        set;
    //    }
    //    public override bool Equals(object obj)
    //    {
    //        Person p = obj as Person;
    //        if (p == null)
    //        {
    //            return false;
    //        }
    //        else
    //        {
    //            if (this.Name == p.Name && this.Age == p.Age && this.Email == p.Email)
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }
    //    }

    //    public static bool Equals(Person p1, Person p2)
    //    {
    //        if (p1 == null || p2 == null)
    //        {
    //            return false;
    //        }
    //        if (p1.Name == p2.Name && p1.Age == p2.Age && p1.Email == p2.Email)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    //public static bool operator ==(Person a, Person b)
    //    //{
    //    //    return Equals(a, b);
    //    //}
    //    //public static bool operator !=(Person a, Person b)
    //    //{
    //    //    return !Equals(a, b);
    //    //}


    //}

    //class Student : Person
    //{

    //}
}
