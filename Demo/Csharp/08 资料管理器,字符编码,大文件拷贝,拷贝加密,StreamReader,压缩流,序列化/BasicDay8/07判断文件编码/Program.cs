using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _07判断文件编码
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] b1 = File.ReadAllBytes("1.txt");
            byte[] b2 = File.ReadAllBytes("2.txt");
            byte[] b3 = File.ReadAllBytes("3.txt");
            byte[] b4 = File.ReadAllBytes("a.txt");
            Console.WriteLine("ok");
            Console.ReadKey();

            
            //Bom
            //string msg = "你好吗？？？";
            //File.WriteAllText("a.txt", msg);
            //Console.WriteLine("ok");
            //Console.ReadKey();
        }
    }
}
