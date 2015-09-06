using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _05字符串练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 课上练习1：接收用户输入的字符串，将其中的字符以与输入相反的顺序输出。"abc"→"cba“.

            //string msg = "我爱你";
            //char[] ch = msg.ToCharArray();
            //for (int i = 0; i < ch.Length / 2; i++)
            //{
            //    char chTmp = ch[ch.Length - 1 - i];
            //    ch[ch.Length - 1 - i] = ch[i];
            //    ch[i] = chTmp;
            //}
            //string s = new string(ch);
            //Console.WriteLine(s);
            //Console.ReadKey();

            #endregion

            #region 课上练习2：接收用户输入的一句英文，将其中的单词以反序输出。      “I love you"→“I evol uoy"

            //Array.Reverse
            string msg = "I love you so so so much";
            string[] words = msg.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = MyReverse(words[i]);
            }
            msg = string.Join(" ", words);
            Console.WriteLine(msg);
            Console.ReadKey();

            #endregion

            #region 课上练习3：”2012年12月21日”从日期字符串中把年月日分别取出来，打印到控制台
            //string date = "2012年12月21日";
            //string[] parts = date.Split('年', '月', '日');
            //Console.WriteLine("年份：{0}月份：{1}天：{2}", parts[0], parts[1], parts[2]);
            //Console.ReadKey();

            #endregion

            #region 课上练习4：把csv文件中的联系人姓名和电话显示出来。简单模拟csv文件，csv文件就是使用,分割数据的文本,输出：


            ////  姓名：张三  电话：15001111113
            ////string[] lines = File.ReadAllLines(“1.csv”,Encoding.Default);//读取文件中的所有行，到数组中。
            //string[] lines = File.ReadAllLines("info.csv", Encoding.Default);

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    lines[i] = lines[i].Replace("\"", string.Empty);
            //    string[] parts = lines[i].Split(',');
            //    string name = parts[0] + parts[1];
            //    string phone = parts[2];
            //    Console.WriteLine("姓名：{0}  电话：{1}", name, phone);
            //}
            //Console.ReadKey();

            #endregion

            //char[] chs = new char[] { 'a', 'b', 'c' };
            //IEnumerable<char> ie = chs.Reverse();
            //foreach (char item in ie)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            #region 练习5：123-456---7---89-----123----2把类似的字符串中重复符号”-”去掉，既得到123-456-7-89-123-2.

            //string msg = "123-456---7---89-----123----2";
            //string[] parts = msg.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            //msg = string.Join("-", parts);
            //Console.WriteLine(msg);
            //Console.ReadKey();

            #endregion

            #region 练习6：从文件路径中提取出文件名(包含后缀) 。比如从c:\a\b.txt中提取出b.txt这个文件名出来。

            //string path = @"c:\a\b.txt";
            //for (int i = 0; i < 15; i++)
            //{
            //    Console.WriteLine("\a");
            //}
            //Console.ReadKey();

            //string path = @"c:\a\b.txt";
            //path = path.Substring(path.LastIndexOf('\\') + 1);
            //Console.WriteLine(path);
            //Console.ReadKey();

            #endregion

            #region 练习7：“192.168.10.5[port=21,type=ftp]”，这个字符串表示IP地址为192.168.10.5的服务器的21端口提供的是ftp服务，其中如果“,type=ftp”部分被省略，则默认为http服务。请用程序解析此字符串，然后打印出“IP地址为***的服务器的***端口提供的服务为***” line.Contains(“type=”)。192.168.10.5[port=21]
            ////Path.GetFileName(

            ////"192.168.10.5[port=21]" http
            ////string message = "192.168.10.5[port=21,type=ftp]";
            //string message = "192.168.10.5[port=21]";
            //string[] parts = message.Split(new string[] { "[port=", ",type=", "]" }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("ip:{0}", parts[0]);
            //Console.WriteLine("port:{0}", parts[1]);
            //Console.WriteLine("service:{0}", parts.Length > 2 ? parts[2] : "http");
            //Console.ReadKey();


            #endregion

            #region 计算工资,练习8：求员工工资文件中，员工的最高工资、最低工资、平均工资

            //string[] lines = File.ReadAllLines("salary.txt", Encoding.Default);

            ////假设第一个人的工资即是最低工资又是最高工资。
            //double min = double.Parse(lines[0].Split('=')[1]);
            //double max = double.Parse(lines[0].Split('=')[1]);

            //double sum = 0;
            //int count = 0;
            //for (int i = 1; i < lines.Length; i++)
            //{
            //    if (lines[i].Length != 0)
            //    {
            //        count++;
            //        double money = double.Parse(lines[i].Split('=')[1]);
            //        sum += money;
            //        if (money > max)
            //        {
            //            max = money;
            //        }
            //        if (money < min)
            //        {
            //            min = money;
            //        }
            //    }

            //}

            //Console.WriteLine("最高工资：{0}", max);
            //Console.WriteLine("最低工资：{0}", min);
            //Console.WriteLine("平均工资：{0}", sum / count);
            //Console.ReadKey();


            #endregion

            #region “北京传智播客软件培训，传智播客.net培训，传智播客Java培训。传智播客官网：http://www.itcast.cn。北京传智播客欢迎您。”。在以上字符串中请统计出”传智播客”出现的次数。找IndexOf()的重载。

            //string msg = "北京传智播客软件培训，传智播客.net培训，传智播客Java培训。传智播客官网：http://www.itcast.cn。北京传智播客欢迎您。";

            //int count = 0;
            //int index = 0;

            //while ((index = msg.IndexOf("传智播客", index)) != -1)
            //{
            //    count++;
            //    index = index + "传智播客".Length;
            //}
            //Console.WriteLine("{0}",count);
            //Console.ReadKey();


            #endregion
        }

        private static string MyReverse(string p)
        {
            char[] chs = p.ToCharArray();
            for (int i = 0; i < chs.Length / 2; i++)
            {
                char ch = chs[i];
                chs[i] = chs[chs.Length - 1 - i];
                chs[chs.Length - 1 - i] = ch;
            }
            return new string(chs);
        }
    }
}
