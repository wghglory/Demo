using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08日期转换
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 案例：编写一个函数进行日期转换，将输入的中文日期转换为阿拉伯数字日期，比如：二零一二年十二月月二十一日要转换为2012-12-21。(处理“十”的问题：1.*月十日；2.*月十三日；3.*月二十三日；4.*月三十日；)4中情况对“十”的不同翻译。1→10；2→1；3→不翻译；4→0【年部分不可能出现’十’，都出现在了月与日部分。】测试数据：二零一二年十二月二十一日(2012年12月21日)、二零零九年七月九日、二零一零年十月二十四日、二零一零年十月二十日

            string date = "二零一零年十月二十日";
            date = ConvertDate(date);
            Console.WriteLine(date);
            Console.ReadKey();

            #endregion
        }

        private static string ConvertDate(string date)
        {
            #region 初始化一个 键值对 集合

            Dictionary<char, char> dict = new Dictionary<char, char>();
            string ziDian = "零0 一1 二2 三3 四4 五5 六6 七7 八8 九9";
            string[] parts = ziDian.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                dict.Add(parts[i][0], parts[i][1]);
            }

            #endregion

            StringBuilder sbDate = new StringBuilder();

            //遍历字符串中的每个字符。
            for (int i = 0; i < date.Length; i++)
            {
                //1.判断该字符是否是'十'
                if (date[i] == '十')
                {
                    //做特殊判断处理。
                    //处理“十”的问题：1.*月十日；2.*月十三日；3.*月二十三日；4.*月三十日；
                    if (!dict.ContainsKey(date[i - 1]) && !dict.ContainsKey(date[i + 1]))
                    {
                        sbDate.Append("10");
                    }
                    else if (!dict.ContainsKey(date[i - 1]) && dict.ContainsKey(date[i + 1]))
                    {
                        sbDate.Append("1");
                    }
                    else if (dict.ContainsKey(date[i - 1]) && dict.ContainsKey(date[i + 1]))
                    {

                    }
                    else if (dict.ContainsKey(date[i - 1]) && !dict.ContainsKey(date[i + 1]))
                    {
                        sbDate.Append("0");
                    }
                }
                else if (dict.ContainsKey(date[i]))
                {
                    sbDate.Append(dict[date[i]]);
                }
                else
                {
                    sbDate.Append("-");
                }
            }

            return sbDate.Remove(sbDate.Length - 1, 1).ToString();
        }
    }
}
