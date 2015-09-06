using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08类型转换
{
    class Program
    {
        static void Main(string[] args)
        {

            ////Cast
            //int n = 10;
            //double d = n;
            //int m = (int)d;

            //string s = "123";
            //int n = Convert.ToInt32(s);
            //Console.WriteLine(n);
            //Console.ReadKey();

            ////int,char,byte,short,long
            //char ch = 'B';
            //int n = ch;
            //Console.WriteLine(n);
            //Console.ReadKey();

            ////int n = 10;
            //Console.WriteLine(sizeof(bool));
            //Console.WriteLine(sizeof(byte));
            //Console.WriteLine(sizeof(char));
            //Console.WriteLine(sizeof(short));
            //Console.WriteLine(sizeof(int));
            //Console.WriteLine(sizeof(long));
            //Console.WriteLine(sizeof(float));
            //Console.WriteLine(sizeof(double));
            //Console.WriteLine(sizeof(decimal));
            //Console.ReadKey();
            //Console.ReadKey();

            //string s = "123";
            //int n = int.Parse(s);
            //n++;
            //double d = double.Parse(s);
            ////double.TryParse(
            //Console.WriteLine(d);
            //Console.WriteLine(n);
            //Console.ReadKey();
          
            //string[] names = new string[] { "乔丹", "科比", "加内特" };

            //Console.WriteLine(names.GetType().ToString());
            //Console.WriteLine(names.GetType().BaseType.ToString());
            //Console.WriteLine(names.GetType().BaseType.BaseType.ToString());
            //Console.WriteLine(names.GetType().BaseType.BaseType.BaseType.ToString());
            //Console.WriteLine(names.GetType().BaseType.BaseType.BaseType.BaseType.ToString());
            //Console.WriteLine(names.GetType().BaseType.BaseType.BaseType.BaseType.BaseType.ToString());
            //Console.WriteLine(names.GetType().BaseType.BaseType.BaseType.BaseType.BaseType.BaseType.ToString());
            //Console.ReadKey();

            Person p = new BestStudent();
            BestStudent bs = p as BestStudent;
            if (bs != null)
            {
                Console.WriteLine("ok");
            }

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

    public class Student : Person
    {

    }
    public class BestStudent : Student
    {

    }
}
