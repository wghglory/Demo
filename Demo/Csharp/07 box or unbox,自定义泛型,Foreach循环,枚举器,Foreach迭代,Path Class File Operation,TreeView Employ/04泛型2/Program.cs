using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _04泛型2
{
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
    class Program
    {
        static void Main(string[] args)
        {
            #region 泛型1
            //MyClass<string> mc = new MyClass<string>();
            //mc[0] = "黄林";
            //mc[1] = "杨硕";

            //Console.WriteLine(mc[0]);
            //Console.WriteLine(mc[1]);
            //Console.ReadKey();


            //MyClass<int> mc = new MyClass<int>();
            //mc[0] = 1000;
            //mc[1] = 2000;

            //Console.WriteLine(mc[0]);
            //Console.WriteLine(mc[1]);
            //Console.ReadKey();

            ////List<Person> list;
            ////list.Sort(
            //Dictionary<int,string>

            #endregion

            //逆变，协变

            MyClass<int, Stream, int, FileStream, Person, int, int> mm = new MyClass<int, Stream, int, FileStream, Person, int, int>();
            mm[0] = 100;
            Console.ReadKey();

        }
    }

    //使用泛型可以是“算法”重用。只是数据类型发生了改变。
    public class MyClass<T, K, V, W, X, Y, Z>
        where T : struct //约束T必须是值类型
        where K : class//约束K必须是引用类型。
        where V : IComparable
        where W : K //要求W必须是K类型那个或者K类型的子类
        where X : class, new() //对于一个类型有多个约束必须使用“逗号隔开”，当有多个类型约束与new()一起使用时，new()约束必须写在最后。
    {
        private T[] _data = new T[5];

        public T this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }
    }


    //public class MyClass
    //{
    //    private string[] _data = new string[5];

    //    public string this[int index]
    //    {
    //        get
    //        {
    //            return _data[index];
    //        }
    //        set
    //        {
    //            _data[index] = value;
    //        }
    //    }
    //}
}
