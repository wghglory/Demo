using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace _06StringBuilder类的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 使用string来拼接字符串

            //string[] lines = File.ReadAllLines("sbtest.txt", Encoding.Default);
            //string msg = string.Empty;
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    msg = msg + lines[i];
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //Console.WriteLine("ok");
            //Console.ReadKey();

            #endregion

            #region StringBuilder

            //string[] lines = File.ReadAllLines("sbtest.txt", Encoding.Default);
            //StringBuilder msg = new StringBuilder();
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    msg.Append(lines[i]);
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //Console.WriteLine("ok");
            //Console.ReadKey();

            #endregion
        }
    }
}
