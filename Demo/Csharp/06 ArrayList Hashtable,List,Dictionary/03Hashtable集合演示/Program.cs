using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _03Hashtable集合演示
{
    class Program
    {
        static void Main(string[] args)
        {

            Hashtable hash = new Hashtable();

            hash.Add("hl", "黄林");

            hash.Add("xzl", new Person() { Name = "许正龙" });

            //键值对集合的“键”一定不能重复。（唯一）
            hash.Add("huanglei", "huanglei");

            //判断一个集合中是否存在某个键
            if (!hash.ContainsKey("hl"))
            {

            }
            //hash.ContainsValue();//判断键值对中是否存在某个值。
            //hash.Contains()

            //通过键获取值
            Console.WriteLine(hash["hl"].ToString());

            Person pp = hash["xzl"] as Person;
            Console.WriteLine(pp.Name);

            //遍历Hashtable
            //1.遍历键
            foreach (object item in hash.Keys)
            {
                Console.WriteLine("键：{0}  →   值：{1}", item, hash[item]);
            }
            Console.WriteLine("=========直接遍历值===========");
            foreach (object item in hash.Values)
            {
                Console.WriteLine("值：{0}", item);
            }
            Console.WriteLine("======直接遍历“键值对”===========");
            foreach (DictionaryEntry kv in hash)
            {
                Console.WriteLine("键：{0}    值：{1}", kv.Key, kv.Value);
            }


            int[] arr = { 15, 175, 264, 359, 401, 598 };

            int number = 359;
            int index = number / 100;
            if (index >= 0 && index < arr.Length)
            {
                Console.WriteLine("存在这个值，索引位置是：{0},对应的值是：{1}", index, arr[index]);
            }
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
    }


}
