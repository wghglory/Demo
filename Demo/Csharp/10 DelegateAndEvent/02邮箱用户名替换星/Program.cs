using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02邮箱用户名替换星
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("please input an email:");
                string email = Console.ReadLine();
                email = Regex.Replace(email, @"(\w+)(@\w+\.\w+)", ReplaceMethod, RegexOptions.ECMAScript);   //3rd argument: public delegate string MatchEvaluator(Match match);
                Console.WriteLine(email);
                Console.ReadKey();
            }
        }

        static string ReplaceMethod(Match match) 
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
