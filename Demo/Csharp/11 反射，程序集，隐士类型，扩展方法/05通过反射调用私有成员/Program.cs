using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace _05通过反射调用私有成员
{
    class Program
    {
        static void Main(string[] args)
        {
            //BindingFlags
            // Person p = new Person();

            //Type typePerson = typeof(Person);
            //MethodInfo method = typePerson.GetMethod("SayHi", BindingFlags.NonPublic | BindingFlags.Instance);
            //method.Invoke(Activator.CreateInstance(typePerson), null);
            //Console.WriteLine("ok");
            //Console.ReadKey();

            ////Gender gender = Gender.男;
            //Gender gender = Gender.女 | Gender.男;
            //Console.WriteLine(gender);
            //Console.ReadKey();

            //标志枚举（才能使用|来赋值，使用|赋值才有意义。）

            //FileInfo file = new FileInfo(@"d:\农大客服.txt");
            //Console.WriteLine(file.Attributes);
            //Console.ReadKey();

            //Console.WriteLine((int)Gender.男);
            //Console.WriteLine((int)Gender.女);
            //Console.WriteLine((int)Gender.人妖);
            //Console.ReadKey();


            Person p = new Person();
            p.Name = "黄林";
            p.Age = 18;
            p.Status = Friends.高 | Friends.富 | Friends.美;
            Console.WriteLine(p.Status);
            //Console.WriteLine((int)Friends.高);
            Console.ReadKey();



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

        public Friends Status
        {
            get;
            set;
        }
    }


    //而标志枚举则不是互斥的。
    [Flags]
    public enum Friends
    {
        高 = 1,
        富 = 2,
        帅 = 4,
        白 = 8,
        美 = 16,
        牛 = 32
    }

    //普通枚举是互斥的。
    public enum Gender //: int
    {
        男 = 10,
        女 = 20,
        人妖
    }

    //public class Person
    //{

    //    private void SayHi()
    //    {
    //        Console.WriteLine("hi~~能调到吗？");
    //    }
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


    //}
}
