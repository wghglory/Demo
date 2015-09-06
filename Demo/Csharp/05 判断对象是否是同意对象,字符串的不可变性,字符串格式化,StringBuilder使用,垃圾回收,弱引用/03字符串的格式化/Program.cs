using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _03字符串的格式化
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("你好呀，我叫{0},今年{1}岁了。现在时间是：{2:d}，这个月工资发了：{3,50:C3}.", "黄林", 18, System.DateTime.Now, 800);
            string s = string.Format("你好呀，我叫{0},今年{1}岁了。现在时间是：{2:d}，这个月工资发了：{3,50:C3}.", "黄林", 18, System.DateTime.Now, 800);
            Console.WriteLine("==============");
            Console.WriteLine(s);
            Console.WriteLine("=================");
            Console.ReadKey();

            //字符串格式化
            //{0[,缩进][:格式/货币][小数位数]}
            //[,缩进]表示  宽度+对齐 ，正整数表示右对齐，负整数表示左对齐
            //Console.WriteLine("=========我叫:{0,-10},发了{1,20:f2}多工资。========", "黄林", 809.1254);
            Console.WriteLine("=========我叫:{0,-10},发了{1,20:C2}多工资。========", "黄林", 809.1254);
            //string s = string.Format(CultureInfo.CreateSpecificCulture("en-us"), "=========我叫:{0,-10},发了{1,20:C2}多工资。========", "黄林", 809.1254);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
