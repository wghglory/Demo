using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _01ArrayList演示
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ArrayList的常用方法1


            ArrayList arrayList = new ArrayList();

            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);
            ////向集合中增加元素
            //arrayList.Add(10);

            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);
            //arrayList.Add("10");

            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);
            //arrayList.Add("黄林");
            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);
            //Person xzl = new Person();
            //xzl.Name = "许正龙";
            //arrayList.Add(xzl);
            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);
            //arrayList.Add(true);
            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);
            //arrayList.AddRange(new int[] { 1, 3, 5, 7, 8, 10, 12 });
            //Console.WriteLine("集合中元素的个数为：{0}", arrayList.Count);
            //Console.WriteLine("集合现在的容量是：{0}", arrayList.Capacity);

            ////通过下标获取集合中的元素
            //Console.WriteLine(arrayList[0]);
            //Console.WriteLine(arrayList[5]);
            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.WriteLine(arrayList[i]);
            //}

            ////向指定的位置插入一个元素
            arrayList.Insert(0, "石国庆");
            //Console.WriteLine("=========================================");

            arrayList.InsertRange(5, new string[] { "a", "b", "b" });
            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    Console.WriteLine(arrayList[i]);
            //}


            //ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new int[] { 1, 3, 4, 5, 6, 7, 8, 9 });

            //Console.WriteLine("============删除结果是：=============================");
            //////删除元素,这样不能将ArrayList中的元素都删除掉。
            arrayList.RemoveAt(0);
            ////for (int i = 0; i < arrayList.Count; i++)
            ////{
            ////    arrayList.RemoveAt(i);
            ////}
            arrayList.Clear();   //这样来清空元素
            //Console.WriteLine(arrayList.Count);//???????

            //ArrayList arrayList = new ArrayList();
            Person p1 = new Person();
            //p1.Name = "马毅";
            //p1.Age = 18;
            //p1.Email = "my@yahoo.com";

            arrayList.Add(p1);
            //arrayList.Add(99);
            //arrayList.Add("黄林");

            //Person p2 = new Person();
            //p2.Name = "马毅";
            //p2.Age = 18;
            //p2.Email = "my@yahoo.com";

            //arrayList.Add(p2);

            //arrayList.Remove(99);

            //Person p3 = new Person();
            //p3.Name = "马毅";
            //p3.Age = 18;
            //p3.Email = "my@yahoo.com";

            //p3 = p1;

            //arrayList.Remove(p3);
            string name = new string(new char[] { '黄', '林' });
            arrayList.Remove(name);

            //Console.WriteLine(arrayList.Count);
            //Console.ReadKey();

            #endregion

            #region MyRegion
            //ArrayList arrayList = new ArrayList();

            //Person p1 = new Person();
            //p1.Name = "马毅";
            //p1.Age = 18;
            //p1.Email = "my@yahoo.com";

            //arrayList.Add(p1);
            //arrayList.Add(99);
            //arrayList.Add("黄林");

            //Person p2 = new Person();
            //p2.Name = "马毅";
            //p2.Age = 18;
            //p2.Email = "my@yahoo.com";

            //arrayList.Add(p2);
            //string s = new string(new char[] { '黄', '林' });
            //Console.WriteLine(arrayList.Contains(s));


            ////把集合转换为数组的一般方法：
            arrayList.ToArray(); 
            #endregion

            #region ArrayList的Sort方法
            //ArrayList arr = new ArrayList(new int[] { 1, 32, 87, 48, 2, 5 });

            ////默认sort()方法是升序排序。
            //arr.Sort();
            ////没有降序排序的方法,但是有一个反转的方法。
            //arr.Reverse();
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            //Console.ReadKey();

            ////=========================================================
            //ArrayList arrlist = new ArrayList(new string[] { "hl", "xzl", "yzk", "fxh", "sr", "yhb", "abm","xyz","xay" });
            //arrlist.Sort();
            //for (int i = 0; i < arrlist.Count; i++)
            //{
            //    Console.WriteLine(arrlist[i]);
            //}
            //Console.ReadKey();

            //===========================================================================
            ArrayList arr = new ArrayList();
            //Person p1 = new Person();
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
            Console.WriteLine(arr.Count);
            arr.Sort();
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(((Person)arr[i]).Name);
            }
            Console.ReadKey();


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
            if (p != null)
            {
                //return p.Age - this.Age;
                return p.Name.Length - this.Name.Length;//this.Name.Length - p.Name.Length;
            }
            return 0;
        }
    }
}
