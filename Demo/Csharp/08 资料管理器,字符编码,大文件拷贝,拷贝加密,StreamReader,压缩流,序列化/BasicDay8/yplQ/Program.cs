using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace yplQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadKey();
            //string s = @"a";
            //Console.WriteLine(Path.GetFullPath(s));
            //Console.ReadKey();

            ////File.rea
            string source = @"C:\Users\Steve\Desktop\讲课\讲课视频\03_20130601Net基础加强\视频\01静态成员静态类.avi";

            string target = @"d:\db.avi";

            CopyFile(source, target);
        }

        private static void CopyFile(string source, string target)
        {
            //1.需要创建两个文件流
            //1.1一个用来读取
            using (FileStream fsSource = new FileStream(source, FileMode.Open))
            {
                //fsSource.Length
                //1.2一个用来写入
                using (FileStream fsTarget = new FileStream(target, FileMode.Create))
                {
                    //1.3通过fsSource读取一部分文件，然后通过fsTarget写入一部分文件

                    //1.4声明一个缓冲区
                    byte[] buffer = new byte[1024 * 1024 * 10];//10MB

                    //1.4.2从fsSource文件流中读取一部分字节到buffer这个缓冲区中
                    //返回值r表示本次读取实际读取到的字节数
                    //第一个参数：表示本次将读取到的字节保存到哪个字节数组中
                    //第二个参数：表示将字节存到该字节数组中的时候，从第几个索引开始存储，一般都是0
                    //第三个参数：本次最多需要读取的字节个数，一般就是数组的Length
                    int r = fsSource.Read(buffer, 0, buffer.Length);


                    while (r > 0)
                    {
                        //1.5将缓冲区中的内容写入到fsTarget文件流中
                        //参数1：要将那个缓冲区的内容写入到数组中
                        //参数2：从这个缓冲区数组的第几个索引开始写入，
                        //参数3：本次要将数组中的那些字节写入文件中（本次要写入的字节个数。）
                        fsTarget.Write(buffer, 0, r);
                        //fsTarget.Position
                        Console.Write(" .");
                        r = fsSource.Read(buffer, 0, buffer.Length);
                    }

                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
