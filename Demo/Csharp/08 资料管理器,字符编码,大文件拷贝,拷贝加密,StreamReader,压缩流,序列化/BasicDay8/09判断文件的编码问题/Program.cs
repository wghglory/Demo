using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _09判断文件的编码问题
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] bytes1 = File.ReadAllBytes("1GBK.txt");
            //byte[] bytes2 = File.ReadAllBytes("2GBK.txt");
            //byte[] bytes3 = File.ReadAllBytes("3GBK.txt");


            //byte[] bytes1 = File.ReadAllBytes("1utf8.txt");
            //byte[] bytes2 = File.ReadAllBytes("2utf8.txt");
            //byte[] bytes3 = File.ReadAllBytes("3utf8.txt");

            //FileStream fs = new FileStream();
            FileStream fsRead = File.OpenRead("a.txt");
            File.OpenWrite("aa.txt");
            Console.ReadKey();
        }
    }
}
