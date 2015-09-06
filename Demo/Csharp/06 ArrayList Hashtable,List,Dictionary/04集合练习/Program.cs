using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _04集合练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 案例：两个（ArrayList）集合{ “a”,“b”,“c”,“d”,“e”}和{ “d”, “e”, “f”, “g”, “h” }，把这两个集合去除重复项合并成一个。

            ArrayList arrList = new ArrayList(new string[] { "a", "b", "c", "d", "e" });
            ArrayList arrList2 = new ArrayList(new string[] { "d", "e", "f", "g", "h" });
            for (int i = 0; i < arrList2.Count; i++)
            {
                if (!arrList.Contains(arrList2[i]))
                {
                    arrList.Add(arrList2[i]);
                }
            }
            Console.WriteLine(arrList.Count);
            for (int i = 0; i < arrList.Count; i++)
            {
                Console.WriteLine(arrList[i]);
            }
            //Console.ReadKey();

            #endregion

            #region 案例：随机生成10个1-100之间的数放到ArrayList中，要求这10个数不能重复，并且都是偶数(添加10次，可能循环很多次。)

            //ArrayList arrList = new ArrayList();
            // Random random = new Random();
            //int count = 0;
            //while (arrList.Count < 10)
            //{
            //    //随即产生一个数字。
            //    int num = random.Next(1, 101);
            //    if (num % 2 == 0 && !arrList.Contains(num))
            //    {
            //        arrList.Add(num);
            //    }
            //    count++;

            //}
            //Console.WriteLine("执行完毕");
            //Console.WriteLine("总个数：{0}", arrList.Count);
            //for (int i = 0; i < arrList.Count; i++)
            //{
            //    Console.WriteLine(arrList[i]);
            //}
            //Console.WriteLine("==============={0}================", count);
            //Console.ReadKey();
            #endregion
  
            //Random random = new Random(88);
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(random.Next(1, 101));
            //}
            //Console.ReadKey();

            #region 练习：有一个字符串是用空格分隔的一系列整数，写一个程序把其中的整数做如下重新排列打印出来：奇数显示在左侧、偶数显示在右侧。比如”2 7 8 3 22 9 5 11”显示成”7 3 9 2 8 22….”。

            ArrayList arrayListOdd = new ArrayList();
            ArrayList arrayListEven = new ArrayList();
            string str = "2 7 8 3 22 9 5 11";
            string[] numbers = str.Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.Parse(numbers[i]) % 2 == 0)
                {
                    arrayListEven.Add(numbers[i]);
                }
                else
                {
                    arrayListOdd.Add(numbers[i]);
                }
            }

            arrayListOdd.AddRange(arrayListEven);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arrayListOdd.Count; i++)
            {
                sb.Append(arrayListOdd[i] + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
            Console.ReadKey();

            #endregion

        }
    }
}
