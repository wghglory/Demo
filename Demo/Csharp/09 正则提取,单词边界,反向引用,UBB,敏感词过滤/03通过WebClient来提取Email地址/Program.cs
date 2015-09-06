using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace _03通过WebClient来提取Email地址
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 通过WebClient下载
            //////1.下载字符串
            ////WebClient client = new WebClient();
            ////string html = client.DownloadString("http://localhost:8080/留下你的Email.htm");

            //////从html字符串中提取邮件地址
            ////MatchCollection matches = Regex.Matches(html, @"[-a-zA-Z0-9_.]+@[-a-zA-Z0-9]+(\.[a-zA-Z]+){1,2}");
            ////foreach (Match item in matches)
            ////{
            ////    Console.WriteLine(item.Value);
            ////}
            ////Console.WriteLine("共{0}个邮箱地址。", matches.Count);
            ////Console.ReadKey();


            //string s = "abcccc";
            //bool f = Regex.IsMatch(s, @"^abc*?$");
            //Console.WriteLine(f);
            //Console.ReadKey();


            #endregion

            #region 提取网页的图片

            //WebClient wb = new WebClient();
            ////1.下载html
            //string html = wb.DownloadString("http://localhost:8080/%E7%BE%8E%E5%A5%B3%E5%9B%BE%E7%89%87/%E7%BE%8E%E5%A5%B3%E4%BB%AC.htm");


            ////2提取里面的<img/>标签
            /*           @已经使用了，那么"""" 表示“” ；没用@可以\"表示“             */
            ////<img alt="" src="hotgirls/00_00.jpg" />
            //MatchCollection matches = Regex.Matches(html, @"<img\s+alt="""" src=""(.+)"" />", RegexOptions.IgnoreCase);


            ////3.通过“提取组”获取img的src属性
            //foreach (Match item in matches)
            //{
            //    //Console.WriteLine(item.Value + "      " + item.Groups[1].Value);
            //    string pathImg = "http://localhost:8080/%E7%BE%8E%E5%A5%B3%E5%9B%BE%E7%89%87/" + item.Groups[1].Value;

            //    //下载图片
            //    wb.DownloadFile(pathImg, @"d:\" + System.DateTime.Now.ToFileTime() + ".jpg");
            //}
            ////4.通过拼接路径实现下载图片 
            //Console.ReadKey();
            #endregion

            #region 提取超链接
            //WebClient wb = new WebClient();
            //string html = wb.DownloadString("http://localhost:8080/test1.htm");
            ////<a href="www.baidu.com">baidu</a>
            //MatchCollection matches = Regex.Matches(html, @"<a\s*href="".+?"">.+?</a>", RegexOptions.IgnoreCase);
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();

            //string s = "\"";
            //Console.WriteLine(s);
            //Console.ReadKey();

            //string s = @"""";
            //Console.WriteLine(s);
            //Console.ReadKey();

            #endregion

            #region 字符串替换

            //string msg = "你aaa好aa哈哈a你";
            //msg=msg.Replace("a", "A");

            //Console.WriteLine(msg);
            //Console.ReadKey();

            //string msg = "你aaa好aa哈哈a你";
            //msg = Regex.Replace(msg, "a+", "A");
            //Console.WriteLine(msg);
            //Console.ReadKey();


            ////=================提取组=====================
            ////将hello ‘welcome’ to ‘China’   替换成 hello 【welcome】 to 【China】
            ////hello 【welcome】 to 【China】
            //string msg = "hello 'welcome' to 'China'  'lss'   'ls'   'szj'   ";
            //msg = Regex.Replace(msg, "'(.+?)'", "【$1】);    //$$1结果为$1
            //Console.WriteLine(msg);
            //Console.ReadKey();


            ////隐藏手机号码
            //string msg = "杨中科13409876543黄林18276354908杨硕87654321345何红卫98761234654";

            //msg = Regex.Replace(msg, @"([0-9]{3})[0-9]{4}([0-9]{4})", "$1****$2");
            //Console.WriteLine(msg);
            //Console.ReadKey();


            ////======隐藏邮箱名=====================
            string email = "我的邮箱steve_zhao@163.com他的邮箱zxh@itcast.cn某某的邮箱mmmmmm@163.com";
            email = Regex.Replace(email, @"(\w+)(@\w+\.\w+)", ReplaceMethod, RegexOptions.ECMAScript);   //3rd argument: public delegate string MatchEvaluator(Match match);
            Console.WriteLine(email);
            Console.ReadKey();

            #endregion

            #region 字符串替换 \b 的使用  ^ $

            //string msg = "The day after tomorrow is my wedding day.The row we are looking for is .row. number 10.";

            ////\b :表示单词的边界。
            ////什么叫做“单词”? [a-zA-Z0-9_]
            ////welcome come come come hello.
            ////love evol 
            ////hello.
            ////msg = msg.Replace("row", "line");
            //msg = Regex.Replace(msg, @"\brow\b", "line");
            //Console.WriteLine(msg);
            //Console.ReadKey();


            //=======================================
            //请提取出3个字母的单词。

            //string msg = "Hi,how are you?Welcome to our country!";
            //MatchCollection matches = Regex.Matches(msg, @"\b[a-z]{3}\b", RegexOptions.IgnoreCase);
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();


            #endregion
            //string msg = "# ## ### #### ## ### # ###.";
            ////MatchCollection matches = Regex.Matches(msg, @"\b###\b");  //wrong!
            //MatchCollection matches = Regex.Matches(msg, @"(?<= )###(?= )");
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();

            //while (true)
            //{
            //    //杨杨杨杨杨中中中中科科科科科
            //    Console.WriteLine("请输入叠词：");
            //    //string msg = Console.ReadLine();
            //    string msg = "你们喜欢杨杨杨杨杨中中中中科科科科科";
            //    msg = Regex.Replace(msg, @"(.)\1+", "$1");
            //    Console.WriteLine(msg);
            //    Console.ReadKey();
            //}


            #region 练习1：将一段文本中的MM/DD/YYYY格式的日期转换为YYYY-MM-DD格式 ，比如“我的生日是05/21/2010耶”转换为“我的生日是2010-05-21耶”。

            //string msg = "我的生日是05/21/2010耶我的生日是05/21/2010耶";
            ////msg = Regex.Replace(msg, @"(\d{2})/(\d{2})/(\d{4})", "$3-$1-$2", RegexOptions.ECMAScript);
            //msg = Regex.Replace(msg, @"(.+)(\d+)/(\d+)/(\d{4})", "$1$4-$2-$3");

            //Console.WriteLine(msg);
            //Console.ReadKey();


            #endregion


            #region 练习2：给一段文本中匹配到的url添加超链接，比如把http://www.test.com替换为<a href="http://www.test.com"> http://www.test.com</a>。参考代码见备注。因为这个是整体做为一个组，比较特殊，难以理解，先把日期转换的理解了就好理解了。
            //string msg = "给一段文本中匹配到的url添加超链接，比如把http://www.test.com替换http://www.sina.com.cn哈哈http://www.google.com";

            //msg = Regex.Replace(msg, @"[a-zA-Z0-9]+://[-a-zA-Z0-9.?&=#%\/_]+", "<a href=\"$0\">$0</a>");
            //Console.WriteLine(msg);
            //Console.ReadKey();

            #endregion


            #region 提取单词反向引用
            //string txt = File.ReadAllText("1.txt", Encoding.Default);

            //MatchCollection matches = Regex.Matches(txt, @"[a-zA-Z]*([a-zA-Z])\1+[a-zA-Z]*");
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();
            #endregion


            #region 提取叠词

            //string msg = File.ReadAllText("2.txt", Encoding.Default);
            ////AABB
            //MatchCollection matches = Regex.Matches(msg, @"(.)\1(.)\2");
            //foreach (Match item in matches)
            //{
            //    Console.WriteLine(item.Value);
            //}
            //Console.ReadKey();
            #endregion
        }

        public static string ReplaceMethod(Match match)
        {
            string emailName = match.Groups[1].Value;
            string emailDomain = match.Groups[2].Value;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < emailName.Length; i++)
            {
                sb.Append("*");
            }
            return sb.ToString() + emailDomain;
        }
    }
}
