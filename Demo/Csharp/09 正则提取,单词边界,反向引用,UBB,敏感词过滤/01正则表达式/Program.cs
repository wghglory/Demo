using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 案例1

            //while (true)
            //{
            //    Console.WriteLine("请输入一个邮政编码：");
            //    string postcode = Console.ReadLine();
            //    //验证是否是合法的邮政编码
            //    //IsMatch()表示只要整个字符串中有任何一部分可以匹配，该正则表达式，则返回true.
            //    //bool b = Regex.IsMatch(postcode, "[0-9]{6}");
            //    //要求必须是6个数字开头，并且必须是6个数字结尾，所以说就是：必须完全匹配。
            //    //bool b = Regex.IsMatch(postcode, "^[0-9]{6}$");

            //    //由于.net默认采用unicode匹配方式所以\d也匹配全角的数字。
            //    // RegexOptions.ECMAScript表示按照ASCII的方式来匹配。
            //    bool b = Regex.IsMatch(postcode, @"^\d{6}$", RegexOptions.ECMAScript);
            //    Console.WriteLine(b);
            //}
            #endregion

            #region 案例2
            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();
            //    bool b = Regex.IsMatch(msg, "z|food");
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 案例3

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    string msg = Console.ReadLine();
            //    ^z|food$  表示z开头或者food结尾。或优先级低
            //    //^z$|^food$
            //    bool b = Regex.IsMatch(msg, "^(z|food)$");
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 案例4

            ////要求用户输入一个整数，匹配是否为>=10并且小于等于20的数组
            //while (true)
            //{
            //    Console.WriteLine("请输入一个10-20之间的数，含：10与20");
            //    string msg = Console.ReadLine();

            //    //bool b = Regex.IsMatch(msg,@"^[1-2][0-9]$"); 错误！

            //    bool b = Regex.IsMatch(msg, @"^(1[0-9]|20)$");

            //    Console.WriteLine(b);
            //}
            #endregion

            #region 匹配身份证号码：


            //while (true)
            //{
            //    Console.WriteLine("请输入身份证号码：");
            //    string id = Console.ReadLine();
            //    bool b = Regex.IsMatch(id, "^([1-9][0-9]{14}|[1-9][0-9]{16}[0-9xX])$");
            //    Console.WriteLine(b);
            //}
            #endregion

            #region 匹配邮箱

            //while (true)
            //{
            //    Console.WriteLine("请输入Email:");
            //    string email = Console.ReadLine();
            //    bool b = Regex.IsMatch(email, @"^[0-9a-zA-Z_.\-]+@[a-zA-Z\-0-9]+(\.[a-zA-Z]+){1,2}$");
            //    Console.WriteLine(b);
            //}
            #endregion

            ////我的邮箱yzk@itcast.cn吼吼！
            //Regex.IsMatch("", @"\w",RegexOptions.ECMAScript);

        }
    }
}
