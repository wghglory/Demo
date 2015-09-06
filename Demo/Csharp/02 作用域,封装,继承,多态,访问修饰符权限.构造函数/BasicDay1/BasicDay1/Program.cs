using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 声明两个变量：int n1 = 10, n2 = 20;要求将两个变量交换，最后输出n1为20,n2为10。扩展（*）：不使用第三个变量如何交换？
            int n1 = 10, n2 = 20;

            //int tmp = n1;
            //n1 = n2;
            //n2 = tmp;

            n1 = n1 + n2;
            n2 = n1 - n2;
            n1 = n1 - n2;

            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.ReadKey();

            #endregion

            #region 用方法来实现：将上题封装一个方法来做，方法有两个参数分别为num1,num2,将num1与num2交换。提示：方法有两个参数n1,n2,在方法中将n1与n2进行交换，使用ref。（*）

            int x1 = 10;
            int x2 = 20;

            Swap(ref x1, ref x2);

            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.ReadKey();

            #endregion

            #region 请用户输入一个字符串，计算字符串中的字符个数，并输出。

            while (true)
            {
                Console.WriteLine("请输入一个字符串：");
                string msg = Console.ReadLine();
                Console.WriteLine("字符串的长度是：{0}", msg.Length);
            }
            #endregion

            #region 用方法来实现：计算两个数的最大值。思考：方法的参数？返回值？扩展（*）：计算任意多个数间的最大值（提示：使用可变参数，params）。

            Console.WriteLine("请输入两个值：");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            //ctrl + alt + F10     ctrl + .
            //ctrl + K + U 取消选中代码的注释
            int max = GetMaxNumber(num1, num2);
            Console.WriteLine("最大值是：{0}", max);
            Console.ReadKey();

            //可变参数
            int max1 = GetMaxNumbers(101, 30, 99, 11);
            Console.WriteLine("最大值是：{0}", max1);
            Console.ReadKey();

            #endregion

            #region 用方法来实现：计算1-100之间的所有整数的和。

            //int r = GetSum();
            //Console.WriteLine(r);
            //Console.ReadKey();

            #endregion

            #region 用方法来实现：计算1-100之间的所有奇数的和。

            //int r = GetOddSum();
            //Console.WriteLine(r);
            //Console.ReadKey();

            //int r = GetEvenSum();
            //Console.WriteLine(r);
            //Console.ReadKey();
            #endregion

            #region 用方法来实现：判断一个给定的整数是否为“质数”。

            //while (true)
            //{
            //    //Math.Sqrt(

            //    //Math.

            //    Console.WriteLine("请输入一个整数");
            //    int number = Convert.ToInt32(Console.ReadLine());
            //    bool b = IsZhiShu(number);
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 用方法来实现：计算1-100之间的所有质数（素数）的和。

            //int r = GetZhiShuSum();
            //Console.WriteLine(r);
            //Console.ReadKey();

            #endregion

            #region 用方法来实现：有一个整数数组：{ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 },找出其中最大值，并输出。不能调用数组的Max()方法。

            //int[] arrInt = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
            //int maxValue = GetMaxFromArray(arrInt);
            //Console.WriteLine(maxValue);
            //Console.ReadKey();

            #endregion

            #region 用方法来实现：有一个字符串数组：{ "马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特" },请输出最长的字符串。

            //string[] names = { "马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特" };
            //string maxName = GetMaxName(names);
            //Console.WriteLine(maxName);
            //Console.ReadKey();

            //int[] arr = new int[10];

            //int[] arr1 = new int[] { 10, 20, 30 };
            //int[] arr1 = new int[3] { 10, 20, 30 };
            //int[] arr2 = { 11, 22, 33 };

            #endregion

            #region 用方法来实现：请计算出一个整型数组的平均值。{ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 }。要求：计算结果如果有小数，则显示小数点后两位（四舍五入）。Math.Round()

            //int[] arrInt = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10, 1 };
            //double avg = GetAvg(arrInt);
            //Console.WriteLine("平均值是：{0}", avg);
            //Console.ReadKey();

            ////int n = 10;
            ////int m = 3;
            ////int w = (double)n / m;
            ////Console.WriteLine(w);
            ////Console.ReadKey();

            #endregion

            /*冒泡*/
            #region 请通过冒泡排序法对整数数组{ 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 }实现降序排序。

            int[] arrInt = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
            for (int i = 0; i < arrInt.Length - 1; i++)
            {
                for (int j = 0; j < arrInt.Length - 1 - i; j++)
                {
                    if (arrInt[j] < arrInt[j + 1])
                    {
                        int temp = arrInt[j];
                        arrInt[j] = arrInt[j + 1];
                        arrInt[j + 1] = temp;
                    }
                }
            }
            //for (int i = 0; i < arrInt.Length - 1; i++)
            //{
            //    for (int j = arrInt.Length - 1; j > i; j--)
            //    {
            //        if (arrInt[j] > arrInt[j - 1])
            //        {
            //            int tmp = arrInt[j];
            //            arrInt[j] = arrInt[j - 1];
            //            arrInt[j - 1] = tmp;
            //        }
            //    }
            //}
            for (int n = 0; n < arrInt.Length; n++)
            {
                Console.WriteLine(arrInt[n]);
            }
            Console.ReadKey();

            #endregion

            #region 有如下字符串：【"患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     患者：“七十五岁。”     大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     大夫：“那现在不咳嗽，还要等到什么时咳嗽？”"】。需求：①请统计出该字符中“咳嗽”二字的出现次数，以及每次“咳嗽”出现的索引位置。②扩展（*）：统计出每个字符的出现次数。

            string kesou = "患者：“大夫，我咳嗽得很重。”     大夫：“你多大年记？”     患者：“七十五岁。”     大夫：“二十岁咳嗽吗”患者：“不咳嗽。”     大夫：“四十岁时咳嗽吗？”     患者：“也不咳嗽。”     大夫：“那现在不咳嗽，还要等到什么时咳嗽？”";
            ////IndexOf()
            //msg.IndexOf("咳嗽"@
            //msg.LastIndexOf(""
            //msg.IndexOf("咳嗽",0)

            //记录“咳嗽”出现的次数
            int count = 0;
            int index = 0;
            string keyword = "咳嗽";
            while (index != -1)
            {
                index = kesou.IndexOf("咳嗽", index);
                Console.WriteLine("第{0}次出现【咳嗽】的索引位置为：{1}", count, index);
                if (index == -1) break;
                index += keyword.Length;
                count++;
            }

            //while ((index = kesou.IndexOf("咳嗽", index)) != -1)//while的条件就是查找时返回的值不是-1
            //{
            //    count++;
            //    Console.WriteLine("第{0}次出现【咳嗽】的索引位置为：{1}", count, index);
            //    index = index + "咳嗽".Length;
            //}
            Console.WriteLine("【咳嗽】总共出现了{0}次。", count);
            Console.ReadKey();

            //=================================================
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < kesou.Length; i++)
            {
                if (!dict.ContainsKey(kesou[i]))
                {
                    dict.Add(kesou[i], 1);
                }
                else
                {
                    dict[kesou[i]]++;
                }
            }

            foreach (KeyValuePair<char, int> item in dict)
            {
                Console.WriteLine("字符{0}出现了{1}次。", item.Key, item.Value);
            }
            Console.ReadKey();
            //================================================

            #endregion

            #region 将字符串"  hello      world,你  好 世界   !    "两端空格去掉，并且将其中的所有其他空格都替换成一个空格，输出结果为："hello world,你 好 世界 !"。
            ////int[] a = { };

            //string msg = "  hello      world,你  好 世界   !      ";
            ////msg = msg.Trim();//这样表示去掉两边空格
            //string[] words = msg.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //msg = string.Join(" ", words);

            //Console.WriteLine("==========" + msg + "===================");
            //Console.ReadKey();

            #endregion

            #region 制作一个控制台小程序。要求：用户可以在控制台录入每个学生的姓名，当用户输入quit（不区分大小写）时，程序停止接受用户的输入，并且显示出用户输入的学生的个数，以及每个学生的姓名。效果如图：
            //string name = string.Empty;
            //int count = 0;

            //List<string> list = new List<string>();
            //do
            //{
            //    Console.WriteLine("请输入姓名：");
            //    name = Console.ReadLine();
            //    if (name.IndexOf('王') == 0)
            //    {
            //        count++;
            //    }
            //    list.Add(name);
            //} while (name.ToLower() != "quit");


            ////除去集合中的最后一个元素。
            //list.RemoveAt(list.Count - 1);

            //Console.WriteLine("共输入学生个数：{0}", list.Count);
            //Console.WriteLine("分别是：");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            //Console.WriteLine("姓王的同学的个数是：{0}", count);
            //Console.ReadKey();


            #endregion

            #region 将普通日期格式：“2011年6月4日” 转换成汉字日期格式：“二零一一年六月四日”。暂时不考虑10日、13日、23日等“带十”的问题。

            //string msg = "1992年5月1日";

            //msg = ConvertToDate(msg);

            //Console.WriteLine(msg);
            //Console.ReadKey();

            #endregion

            #region 请将字符串数组{ "中国", "美国", "巴西", "澳大利亚", "加拿大" }中的内容反转。然后输出反转后的数组。不能用数组的Reverse()方法。

            string[] countries = { "中国", "美国", "巴西", "澳大利亚", "加拿大" };

            //所有数组都是引用类型。
            //int[] arr;

            //反转该数组
            MyReverse(countries);


            for (int i = 0; i < countries.Length; i++)
            {
                Console.WriteLine(countries[i]);
            }
            Console.ReadKey();

            #endregion

            #region 索引器
            ItCast ic = new ItCast();
            ////Console.WriteLine(ic._names[0]);
            //for (int i = 0; i < ic._names.Length; i++)
            //{
            //    Console.WriteLine(ic._names[i]);
            //}

            for (int i = 0; i < ic.Count; i++)
            {
                Console.WriteLine(ic[i]);
            }
            ic[0] = "sk";
            Console.ReadKey();
            #endregion
        }

        private static void MyReverse(string[] msg)
        {
            for (int i = 0; i < msg.Length / 2; i++)
            {
                string tmp = msg[i];
                msg[i] = msg[msg.Length - 1 - i];
                msg[msg.Length - 1 - i] = tmp;
            }
        }

        private static string ConvertToDate(string msg)
        {
            //不能这么做，因为字符串具有不可变性。
            //msg[0] = '二';
            char[] chs = msg.ToCharArray();

            for (int i = 0; i < chs.Length; i++)
            {
                switch (chs[i])
                {
                    case '0':
                        chs[i] = '零';
                        break;
                    case '1':
                        chs[i] = '一';
                        break;
                    case '2':
                        chs[i] = '二';
                        break;
                    case '3':
                        chs[i] = '三';
                        break;
                    case '4':
                        chs[i] = '四';
                        break;
                    case '5':
                        chs[i] = '五';
                        break;
                    case '6':
                        chs[i] = '六';
                        break;
                    case '7':
                        chs[i] = '七';
                        break;
                    case '8':
                        chs[i] = '八';
                        break;
                    case '9':
                        chs[i] = '九';
                        break;

                    default:
                        break;
                }
            }

            //把一个char数组转换为字符串
            return new string(chs);
        }

        private static double GetAvg(int[] arrInt)
        {
            int sum = 0;
            for (int i = 0; i < arrInt.Length; i++)
            {
                sum += arrInt[i];
            }
            return Math.Round(sum / (double)arrInt.Length, 2);
            //return sum / (double)arrInt.Length;
        }

        private static string GetMaxName(string[] names)
        {
            string maxName = names[0];
            for (int i = 1; i < names.Length; i++)
            {
                if (names[i].Length > maxName.Length)
                {
                    maxName = names[i];
                }
            }
            return maxName;
        }

        private static int GetMaxFromArray(int[] arrInt)
        {
            int max = arrInt[0];
            for (int i = 1; i < arrInt.Length; i++)
            {
                if (arrInt[i] > max)
                {
                    max = arrInt[i];
                }
            }
            return max;
        }

        private static int GetZhiShuSum()
        {
            int sum = 0;
            for (int i = 2; i <= 100; i++)
            {
                if (IsZhiShu(i))
                {
                    sum += i;
                }
            }
            return sum;
        }

        private static bool IsZhiShu(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int GetEvenSum()
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        private static int GetOddSum()
        {
            int sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        static int GetSum()
        {
            int result = 0;
            for (int i = 1; i <= 100; i++)
            {
                result = result + i;
            }
            return result;
        }

        static int GetMaxNumbers(params int[] pms)
        {
            int max = pms[0];
            for (int i = 1; i < pms.Length; i++)
            {
                if (pms[i] > max)
                {
                    max = pms[i];
                }
            }
            return max;
        }

        private static int GetMaxNumber(int num1, int num2)
        {
            return (num1 > num2) ? num1 : num2;
        }

        private static void Swap(ref int n1, ref int n2)
        {
            int tmp = n1;
            n1 = n2;
            n2 = tmp;
        }
    }
}
