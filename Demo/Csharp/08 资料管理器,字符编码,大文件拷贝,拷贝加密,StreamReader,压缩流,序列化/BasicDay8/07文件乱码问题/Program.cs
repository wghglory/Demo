using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _07文件乱码问题
{
    class Program
    {
        static void Main(string[] args)
        {
            ////string msg = File.ReadAllText("2.txt", Encoding.Default);
            ////Console.WriteLine(msg);
            ////Console.ReadKey();

            //// Encoding encoding = Encoding.GetEncoding("gb2312");
            //EncodingInfo[] infos = Encoding.GetEncodings();
            //foreach (var item in infos)
            //{
            //    //Console.WriteLine("{0},{1},{2}", item.CodePage, item.DisplayName, item.Name);
            //    File.AppendAllText("encodings.txt", string.Format("{0},{1},{2}\r\n", item.CodePage, item.DisplayName, item.Name));
            //}
            //Console.ReadKey();

            //通过指定一个文件路径，来创建一个对象
            FileInfo file = new FileInfo(@"encodings.txt");

            DirectoryInfo dirInfo = new DirectoryInfo(@"c:\a");

            string[] names = Directory.GetLogicalDrives();
            foreach (var item in names)
            {
                //DriveInfo driveInfo = new DriveInfo(item);
                //driveInfo.DriveType=DriveType.
                //DriveInfo.GetDrives(
            }
        }
    }
}
