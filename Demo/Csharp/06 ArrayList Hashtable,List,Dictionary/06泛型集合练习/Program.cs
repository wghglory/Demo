using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06泛型集合练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 案例：把分拣奇偶数的程序用泛型实现。List<int>


            //string str = "2 7 8 3 22 9 5 11";
            //string[] numbers = str.Split(' ');
            //List<string> listOdd = new List<string>();
            //List<string> listEven = new List<string>();
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    if (int.Parse(numbers[i]) % 2 == 0)
            //    {
            //        listEven.Add(numbers[i]);
            //    }
            //    else
            //    {
            //        listOdd.Add(numbers[i]);
            //    }
            //}

            //listOdd.AddRange(listEven);

            //string[] nums = listOdd.ToArray();
            //Console.WriteLine(string.Join(" ", nums));

            //Console.ReadKey();


            #endregion

            #region 练习1：将int数组中的奇数放到一个新的int数组中返回。
            //int[] arrInt = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //List<int> listOdd = new List<int>();
            //for (int i = 0; i < arrInt.Length; i++)
            //{
            //    if (arrInt[i] % 2 != 0)
            //    {
            //        listOdd.Add(arrInt[i]);
            //    }
            //}

            ////把List<T>集合转换为数组
            //int[] newArray = listOdd.ToArray();
            //for (int i = 0; i < newArray.Length; i++)
            //{
            //    Console.WriteLine(newArray[i]);
            //}
            //Console.ReadKey();


            #endregion

            #region 练习2：从一个整数的List<int>中取出最大数（找最大值）。别用max方法。

            //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 77, 88, 9, 11, };
            //int max = GetMax(list);//list.Max();
            //Console.WriteLine(max);
            //Console.ReadKey();

            #endregion

            #region 练习：把123转换为：壹贰叁。Dictionary<char,char>
            //string str = "1壹 2贰 3叁 4肆 5伍 6陆 7柒 8捌 9玖 0零";
            //Dictionary<char, char> dict = new Dictionary<char, char>();
            //string[] parts = str.Split(' ');
            //for (int i = 0; i < parts.Length; i++)
            //{
            //    dict.Add(parts[i][0], parts[i][1]);
            //}
            //Console.WriteLine("请输入一个整数：");
            //string number = Console.ReadLine();
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < number.Length; i++)
            //{
            //    sb.Append(dict[number[i]]);
            //}
            //Console.WriteLine(sb.ToString());
            //Console.ReadKey();

            #endregion

            #region 练习：计算字符串中每种字母出现的次数（面试题）。 “Welcome ,to Chinaworld”，不区分大小写，打印“W2”“e 2”“o 3”……

            //Dictionary<string, int> dict = new Dictionary<string, int>() { { "hl", 18 }, { "xzl", 19 } };
            //foreach (KeyValuePair<string, int> item in dict)
            //{
            //    Console.WriteLine(item.Key + "   " + item.Value);
            //}
            //Console.ReadKey();

            //string msg = "Welcome ,to China!!  world！dsjfdsl.jfdsf";
            ////msg = msg.ToLower();
            //Dictionary<char, int> dict = new Dictionary<char, int>();
            //for (int i = 0; i < msg.Length; i++)
            //{
            //    if (char.IsLetter(msg[i]))
            //    {
            //        //if (dict.ContainsKey(msg[i]))
            //        //{
            //        //    dict[msg[i]]++;
            //        //}
            //        //else
            //        //{
            //        //    //dict.Add(msg[i], 1);
            //        //    dict[msg[i]] = 1;
            //        //}

            //        if (dict.ContainsKey(char.ToLower(msg[i])))
            //        {
            //            dict[char.ToLower(msg[i])]++;
            //        }
            //        else if (dict.ContainsKey(char.ToUpper(msg[i])))
            //        {
            //            dict[char.ToUpper(msg[i])]++;
            //        }
            //        else
            //        {
            //            dict.Add(msg[i], 1);
            //        }

            //        //char.IsDigit

            //    }

            //}

            //foreach (KeyValuePair<char, int> keyValue in dict)
            //{
            //    Console.WriteLine("字母：{0}出现了：{1}次。", keyValue.Key, keyValue.Value);
            //}
            //Console.ReadKey();


            #endregion


            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("hl", 20);
            //如果字典中不存在该“键”，则获取时会报异常，最好先通过ConstainsKey()判断
            Console.WriteLine(dict["xzl"]);
            Console.ReadKey();
        }

        private static int GetMax(List<int> list)
        {
            int max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}
