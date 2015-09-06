using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _02ArrayList的Sort排序方法2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 1. 通过本类：IComparable, Arraylist.Sort();

            //ArrayList list = new ArrayList();
            //list.Add("abc");
            //list.Add("axy");
            //list.Add("acx");
            //list.Add(null);
            //list.Sort();
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            //Console.ReadKey();

            ArrayList arr = new ArrayList();

            Person p1 = new Person();
            p1.Name = "chenjinlin";
            p1.Age = 19;
            p1.Email = "cjl@yahoo.com";

            Person p2 = new Person();
            p2.Name = "zhengdd";
            p2.Age = 18;
            p2.Email = "zdd@yahoo.com";

            Person p3 = new Person();
            p3.Name = "zhubq";
            p3.Age = 17;
            p3.Email = "zbq@yahoo.com";

            Person p4 = new Person();
            p4.Name = "pdh";
            p4.Age = 16;
            p4.Email = "pdh@yahoo.com";

            arr.Add(p1);
            arr.Add(p2);
            arr.Add(p3);
            arr.Add(p4);
            arr.Add(null);

            //直接调用Sort()方法是使用Person类型实现了IComparable接口的默认方式来排序
            arr.Sort();

            #endregion

            #region 2. Create a new class:Icomparer, Arraylist.Sort(class)

            arr.Sort(new PersonSortByNameLengthAsc());

            //for (int i = 0; i < arr.Count; i++)
            //{
            //    Console.WriteLine(((Person)arr[i]).Name);
            //}
            //Console.ReadKey();

            #endregion

        }
    }

    public class Person : IComparable
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

        public int CompareTo(object obj)
        {
            Person p = obj as Person;
            return this.Age - p.Age;
        }
    }


    //这个类就是一个比较器
    public class PersonSortByNameLengthAsc : IComparer
    {

        public int Compare(object x, object y)
        {

            Person p1 = x as Person;
            Person p2 = y as Person;
            if (p1 != null && p2 != null)
            {
                return p2.Name.Length - p1.Name.Length;
            }
            else
            {
                throw new Exception("null无法比较。。。");
            }

        }
    }
}
