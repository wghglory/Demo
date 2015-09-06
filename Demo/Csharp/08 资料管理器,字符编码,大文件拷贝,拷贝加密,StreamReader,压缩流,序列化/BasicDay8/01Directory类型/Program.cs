using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _01Directory类型
{
    class Program
    {
        static void Main(string[] args)
        {
            ////如果有则干掉！
            //Directory.Delete(@"c:\hello", true);
            //Directory.Move(@"c:\hello", @"c:\hi");
            //Directory.GetFiles();
            //Directory.GetDirectories();
            //Console.WriteLine("ok");
            //Direcotry操作目录的类
            //if (Directory.Exists(@"c:\hello"))
            //{
            //    Console.WriteLine("存在该文件夹！");
            //    Directory.Move(@"c:\hello", @"c:\windows\hello");
            //    Console.WriteLine("移动完毕！！");
            //}
            //else
            //{
            //    Console.WriteLine("不存在该文件夹");
            //    //创建一个文件夹
            //    DirectoryInfo info = Directory.CreateDirectory(@"c:\hello\a\b\c\d");
            //    Console.WriteLine("文件夹已经创建完毕！！");

            //}
            //Console.ReadKey();

            #region 获取一个目录下的所有的子文件与子文件夹（子目录）

            //string path = @"C:\DRIVERS\TPBTooth";

            ////获取当前目录的所有子文件的路径（不包含后代文件）
            //string[] files = Directory.GetFiles(path,"*.ini",SearchOption.AllDirectories);
            //foreach (var item in files)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();



            ////获取当前目录下的所有子目录
            //string[] dirs = Directory.GetDirectories(path);
            //foreach (var item in dirs)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();
            #endregion
        }
    }
}
