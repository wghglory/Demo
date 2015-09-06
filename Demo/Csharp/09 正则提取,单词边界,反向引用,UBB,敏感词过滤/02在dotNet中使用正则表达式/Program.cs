using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace _02在dotNet中使用正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            //Regex.IsMatch();//用来判断给定的字符串是否匹配某个正则表达式
            //Regex.Match();//用来从给定的字符串中按照正则表达式的要求提取【一个】匹配的字符串
            //Regex.Matches();//用来从给定的字符串中按照正则表达式的要求提取【所有】匹配的字符串
            //Regex.Replace(); //替换所有正则表达式匹配的字符串为另外一个字符串。


            while (true)
            {
                Console.WriteLine("请输入一个字符串：");
                string str = Console.ReadLine();
                //验证给定的字符串是否为一个合法的邮政编码
                //注意，要想完全匹配，必须要加^和$。否者只要字符串中有一部分与给定的正则表达式匹配，就返回true了。
                bool b = Regex.IsMatch(str, "^[0-9]{6}$");
                Console.WriteLine("给定的字符串是一个合法的邮政编码吗？{0}", b);
            }


            //while (true)
            //{
            //    string msg = File.ReadAllText("1.txt");//"1\r\n1\r\n1\r\n";
            //    bool b = Regex.IsMatch(msg, "(^[0-9]$){3}");
            //    Console.WriteLine(b);
            //}


            ////10-25 ,找规律写正则表达式，不能用大于小于等方法。只能找规律。
            //while (true)
            //{
            //    Console.WriteLine("请用户输入一个10（含）-25（含）之间的任何一个数字。");
            //    string n = Console.ReadLine();
            //    bool b = Regex.IsMatch(n, "^(1[0-9]|2[0-5])$");
            //    Console.WriteLine(b);
            //}
           

            ////验证是否是合法的手机号。
            //while (true)
            //{
            //    Console.WriteLine("手机号：");
            //    string num = Console.ReadLine();
            //    Console.WriteLine(Regex.IsMatch(num, @"^\d{11}$"));
            //}

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();
            //    Console.WriteLine(Regex.IsMatch(msg, "z|food"));
            //}

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();
            //    Console.WriteLine(Regex.IsMatch(msg, "(z|f)ood"));
            //}

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();
            //    //要么是以z开头的，要么是以food结尾的都认为是true
            //    Console.WriteLine(Regex.IsMatch(msg, "^z|food$"));
            //}

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();
            //    //要么匹配字符串z,要么匹配字符串food
            //    Console.WriteLine(Regex.IsMatch(msg, "^(z|food)$"));
            //}

            //163.com
            //    yahoo.com
            //        www.action-a.com

            #region 判断一个字符串是不是身份证号码。
            //1.长度为15位或者18位的字符串，首位不能是0。
            //2.如果是15位，则全部是数字。
            //3.如果是18位，则前17位都是数字，末位可能是数字也可能是X。


            //while (true)
            //{
            //    Console.WriteLine("输入身份证号：");
            //    string idNo = Console.ReadLine();
            //    //[1-9]\d{14}
            //    //Console.WriteLine(Regex.IsMatch(idNo, @"^([1-9]\d{16}[0-9xX]|[1-9]\d{14})$"));
            //    //Console.WriteLine(Regex.IsMatch(idNo, @"^[1-9]\d{16}[0-9xX]$|^[1-9]\d{14}$"));
            //    Console.WriteLine(Regex.IsMatch(idNo, @"(^[1-9][0-9]{14}$)|(^[1-9][0-9]{16}[0-9Xx]$)"));
            //}


            #endregion

            //zxh   @    itcast.cn
            //132333    @    vip.qq.com
            //aaa   @         sina.com.cn
            #region 验证是否为合法的邮件地址

            //            while (true)
            //            {
            //                Console.WriteLine("请输入一个Email地址：");
            //                string email = Console.ReadLine();
            //Console.WriteLine(Regex.IsMatch(email, @"^[-0-9a-zA-Z_\.]+@[a-zA-Z0-9]+(\.[a-zA-Z]+){1,2}$"));
            //            }
            #endregion

            #region .net默认使用的是Unicode匹配模式

            //string msg = "１２３";//123   １２３
            //bool b = Regex.IsMatch(msg, @"\d+",RegexOptions.ECMAScript);
            ////bool b = Regex.IsMatch(msg, @"[0-9]+"); //这个可以准确判断是ASCII字符123，不包含unicode字符１２３，其实就是在输入法中使用“全角”输出１２３
            //Console.WriteLine(b);
            //Console.ReadKey();


            //string msg = "abd097776_432ERWEWR__你好你好你好你好你好";
            //bool b = Regex.IsMatch(msg, @"^\w+$", RegexOptions.ECMAScript);
            //Console.WriteLine(b);
            //Console.ReadKey();

            #endregion

            #region 判断字符串是否为正确的国内电话号码，不考虑分机。

            ////010-8888888或010-88888880或010xxxxxxx
            ////0335-8888888或0335-88888888（区号-电话号）03358888888
            ////10086、10010、95595、95599、95588（5位）
            ////13888888888（11位都是数字）

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string number = Console.ReadLine();
            //    //\d{3,4}-?\d{7,8}
            //    //\d{5}
            //    //\d{11}
            //    //[a\-z]
            //    bool b = Regex.IsMatch(number, @"^(\d{3,4}-?\d{7,8}|\d{5})$");
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 1、匹配IP地址，4段用.分割的最多三位数字。


            //while (true)
            //{
            //    Console.WriteLine("请输入ip:");
            //    string ip = Console.ReadLine();
            //    bool b = Regex.IsMatch(ip, @"^([0-9]{1,3}\.){3}[0-9]{1,3}$");
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 判断是否是合法的日期格式“2008-08-08”。四位数字-两位数字-两位数字。

            //while (true)
            //{
            //    Console.WriteLine("输入日期：");
            //    string date = Console.ReadLine();
            //    //bool b = Regex.IsMatch(date, @"^[0-9]{4}-[0-9]{2}-[0-9]{2}$");

            //    //限制月份只能是1-12月
            //    //01-9
            //    //0[1-9]
            //    //1[0-2]
            //    bool b = Regex.IsMatch(date, @"^[0-9]{4}-(0[1-9]|1[0-2])-[0-9]{2}$");
            //    Console.WriteLine(b);

            //}

            #endregion

            #region 判断是否是合法的url地址，http://www.test.com/a.htm？id=3&name=aaa、ftp://127.0.0.1/1.txt。字符串序列://字符串序列。http、https、ftp、file、thunder、ed2k

            //while (true)
            //{
            //    Console.WriteLine("输入一个url:");
            //    string url = Console.ReadLine();
            //    //http://.....................
            //    bool b = Regex.IsMatch(url, @"^[a-zA-Z0-9]+://.+$");
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 字符串提取


            //大家好呀，hello,2010年10月10日是个好日子。恩，9494.吼吼！886.
            // string msg = "大家好呀，hello,2010年10月10日是个好日子。恩，9494.吼吼！886.";

            ////Regex.IsMatch()

            ////一般字符串提取不加^ 和 $
            ////Regex.Match只能提取一个匹配。
            //Match match = Regex.Match(msg, "[0-9]+");
            //Console.WriteLine(match.Value);


            ////Regex.Matches()提取字符串中的所有匹配。
            //MatchCollection matches = Regex.Matches(msg, "[0-9]+");
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();



            #endregion

            #region 提取html网页中的邮箱地址


            //string html = File.ReadAllText("1.htm");

            ////从字符串中提取子字符串。
            ////如果想要对已经匹配的字符串再进行分组提取，就用到了“提取组”的功能
            ////通过添加()就能实现提取组。
            ////在正则表达式中只要出现了()就表示进行了分组。小括号既有改变优先级的作用又具有提取组的功能。
            //MatchCollection matches = Regex.Matches(html, @"([-a-zA-Z_0-9.]+)@([-a-zA-Z0-9_]+(\.[a-zA-Z]+)+)");
            //foreach (Match item in matches)
            //{
            //    //item.Value表示本次提取到的字符串
            //    //item.Groups集合中存储的就是所有的分组信息。
            //    //item.Groups[0].Value与item.Value是等价的都表示本次提取到的完整的字符串，表示整个邮箱字符串，而item.Groups[1].Value则表示第一组的字符串。
            //    //Console.WriteLine(item.Value);
            //    Console.WriteLine("第0组：{0}", item.Groups[0].Value);
            //    Console.WriteLine("第1组：{0}", item.Groups[1].Value);
            //    Console.WriteLine("第2组：{0}", item.Groups[2].Value);
            //    Console.WriteLine("===============================================");
            //}
            //Console.WriteLine("ok");
            //Console.WriteLine(matches.Count);
            //Console.ReadKey();

            #endregion

            #region 关于C#字符串中的\转义问题 与  正则表达式中的\的转义问题。

            //////string reg = "\d"; //此时c#会认为\是一个字符串的转义符。

            //////此时运行完毕后其实就是  \d
            ////string reg = "\\\\d"; //此时c#会认为\是一个字符串的转义符。

            ////bool b = Regex.IsMatch(@"\d", reg);  //msg →  \\d
            ////Console.WriteLine(b);
            ////Console.ReadKey();

            //Console.WriteLine("a\\\\tb");
            //Console.ReadKey();


            #endregion

            #region 提取文件中的文件名

            ////Path.GetFileName
            //string path = @"C:\DRIVERS\WIN\4IN1_W7\83x32\rimmptsk.cat";

            ////此处因为有“贪婪模式”的存在，所以正则表达式中的 \\ 肯定匹配的是文件路径中的最后一个 \
            //Match match = Regex.Match(path, @".+\\(.+)");
            //Console.WriteLine(match.Groups[1].Value);
            //Console.ReadKey();
            #endregion

            #region 从“June         26       ,        1951    ”中提取出月份June、26、1951来。@"^([a-zA-Z]+)\s*(\d{1,2})\s*,\s*(\d{4})\s*$"进行匹配。月份和日之间是必须要有空格分割的，所以使用空白符号“\s”匹配所有的空白字符，此处的空格是必须有的，所以使用“+”标识为匹配1至多个空格。之后的“，”与年份之间的空格是可有可无的，所以使用“*”表示为匹配0至多个

            //string date = "June26     ,        1951    ";
            //Match match = Regex.Match(date, @"([a-zA-Z]+)\s*([0-9]{2})\s*,\s*([0-9]{4})\s*");
            //for (int i = 0; i < match.Groups.Count; i++)
            //{
            //    Console.WriteLine(match.Groups[i].Value);
            //}
            //Console.ReadKey();



            //string date = "June         26       ,        1951    ";
            //MatchCollection matches = Regex.Matches(date, "[a-zA-Z0-9]+");
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();

            #endregion

            #region 从Email中提取出用户名和域名，比如从test@163.com中提取出test和163.com。


            //while (true)
            //{
            //    Console.WriteLine("请输入Email:");
            //    string email = Console.ReadLine();
            //    Match match = Regex.Match(email, @"(.+)@(.+)");
            //    Console.WriteLine("用户名：{0}，域名：{1}", match.Groups[1].Value, match.Groups[2].Value);
            //}
            //zxh@itcast.cn
            #endregion

            #region “192.168.10.5[port=21,type=ftp]”，这个字符串表示IP地址为192.168.10.5的服务器的21端口提供的是ftp服务，其中如果“,type=ftp”部分被省略，则默认为http服务。请用程序解析此字符串，然后打印出“IP地址为***的服务器的***端口提供的服务为***”

            //// string msg = "192.168.10.5[port=21,type=ftp]";
            //string msg = "192.168.10.5[port=21]";
            //Match match = Regex.Match(msg, @"(.+)\[port=([0-9]{2,5})(,type=(.+))?\]");
            //Console.WriteLine("ip:{0}", match.Groups[1].Value);
            //Console.WriteLine("port:{0}", match.Groups[2].Value);
            //Console.WriteLine("services:{0}", match.Groups[4].Value.Length == 0 ? "http" : match.Groups[4].Value);
            //Console.ReadKey();

            //string str = "192.168.10.5[port=21,type=ftp]";
            //MatchCollection matches = Regex.Matches(str, @"[^(\[port=)(,type=)\]]+", RegexOptions.ECMAScript);
            //foreach (var item in matches)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();
            #endregion

        }
    }
}