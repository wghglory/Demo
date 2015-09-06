using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05List集合与Dictionary集合
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> list = new List<string>();
            //List<int> list1 = new List<int>();
            //Console.WriteLine(list.ToString());

            //List<int> list = new List<int>();
            //list.Add(100);
            //list.Add(999);
            //list.Add(889);

            ////list.ToArray();

            //Hashtable的泛型版本
            //Generic

            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict.Add("huanglin", 100);
            dict.Add("xuzhenglong", 98);

            //Console.WriteLine(dict["huanglin"]);

            //遍历“键”
            foreach (string item in dict.Keys)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=====================================");
            //遍历“值”
            foreach (int item in dict.Values)
            {
                Console.WriteLine(item);
            }
            //直接遍历“键值对”
            foreach (KeyValuePair<string, int> item in dict)
            {
                Console.WriteLine("键:{0}  →   值：{1}", item.Key, item.Value);
            }

            Console.ReadKey();

        }
    }
}
