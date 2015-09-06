using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace _06抓取职位信息
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient wc = new WebClient();
            //string html = wc.DownloadString("http://localhost:8080/【上海,IT-管理,计算机软件招聘，求职】-前程无忧.htm");

            ////提取职位信息的超链接
            ////<a href="http://search.51job.com/job/46614662,c.html" onclick="zzSearch.acStatRecJob( 1 );" class="jobname" target="_blank">软件开发经理</a>


            //MatchCollection match = Regex.Matches(html, "<a href=\"http://search.51job.com/job/[0-9]+,c.html\".+?>(.+?)</a>");

            //foreach (Match item in match)
            //{
            //    Console.WriteLine(item.Groups[1].Value);
            //}
            //Console.WriteLine("共{0}条。", match.Count);
            //Console.ReadKey();

            ////Regex
            //Regex regex = new Regex(@"\d{5}");


            //regex.IsMatch(

        }
    }
}
