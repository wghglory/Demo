using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09异常代码观察
{
    class Program
    {
        static void Main(string[] args)
        {
            // T1();

            //int r = GetNumber();
            //Console.WriteLine(r);
            //Console.ReadKey();

            //int n = M1();
            //Console.WriteLine(n);
            //Console.ReadKey();

            Person p = GetPerson();
            Console.WriteLine(p.Age);
            Console.ReadKey();
        }

        static Person GetPerson()
        {
            Person p = new Person();
            p.Age = 100;
            try
            {
                p.Age = p.Age + 1;
                //////======引发异常的代码==========
                ////int x = 10, y = 0;
                ////Console.WriteLine(x / y);
                //////======引发异常的代码==========
                return p;
            }
            catch (Exception)
            {
                p.Age = p.Age + 1;
                return p;
            }
            finally
            {
                p.Age = p.Age + 1;
                //fdsfdsfdsfdsafdsfasfs
            }
        }

        static int T10()
        {
            int x = 100;
            x++;
            return x;
        }

        static int T12()
        {
            return 1000;
        }

        static int M1()
        {
            int result = 100;
            try
            {
                result = result + 1;
                //======引发异常的代码==========
                int x = 10, y = 0;
                Console.WriteLine(x / y);
                //======引发异常的代码==========
                return result;
            }
            catch
            {
                Console.WriteLine("catch被执行了");
                result = result + 1;
                return result;
            }
            finally
            {
                Console.WriteLine("====finally被执行了=================");
                result = result + 1;
            }
        }

        static int GetNumber()
        {
            try
            {
                int n1 = 10;
                int n2 = 0;
                //======引发异常的代码==========
                int n3 = n1 / n2;
                //======引发异常的代码==========
                return 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("*******异常了*********");
                return 1000;
            }
            finally
            {
                Console.WriteLine("finally中的代码!!!!");
            }
        }

        static void T1()
        {
            try
            {
                Console.WriteLine("11111111111111111111");
                //====引发异常代码=====
                int n = 10, m = 0;
                Console.WriteLine(n / m);
                //====引发异常代码=====
                Console.WriteLine("★★★★★★★★★★★★★★");
                return;
                Console.WriteLine("22222222222222222222");
            }
            catch (Exception)
            {
                Console.WriteLine("33333333333333333333");
            }
            finally
            {
                Console.WriteLine("4444444444444444444444");
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
}
