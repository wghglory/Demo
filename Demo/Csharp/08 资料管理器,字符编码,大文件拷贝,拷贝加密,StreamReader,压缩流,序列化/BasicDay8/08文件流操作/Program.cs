using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _08文件流操作
{
    class Program
    {
        static void Main(string[] args)
        {
            ////文件流的使用方式
            //string msg = "苏坤蒋坤杨中科";

            ////把字符串转换成byte数组。
            //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(msg);

            ////怎么把一个byte数组转换为一个字符串
            //string newmsg = System.Text.Encoding.UTF8.GetString(bytes);
            //Console.WriteLine(newmsg);
            //Console.ReadKey();


            //流操作的都是字节，不能直接操作字符串


            #region 1.通过FileStream来写文件
            //文件流的使用步骤
            //1.创建文件流
            FileStream fsWrite = new FileStream("first.txt", FileMode.Create, FileAccess.Write);
            //2.使用文件流，执行读写操作
            string msg = "今天是个好日子。lalalalalaalal...";
            byte[] byts = System.Text.Encoding.UTF8.GetBytes(msg);
            //写
            //参数1：表示将指定的字节数组中的内容写入到文件
            //参数2：参数1的数组的偏移量，一般为0.
            //参数3：本次文件写入操作要写入的实际的字节个数。
            fsWrite.Write(byts, 0, byts.Length);

            //3.清空缓冲区、关闭文件流、释放资源
            //fsWrite.Flush();
            //fsWrite.Close();
            //fsWrite.Dispose();
            fsWrite.Dispose();
            Console.WriteLine("ok");
            Console.ReadKey();

            //using (FileStream fs = new FileStream())
            //{
            //    //fs.Dispose();
            //}


            #endregion

            #region 2.通过FileStream来读文件
            //1.创建文件流
            using (FileStream fsRead = new FileStream("first.txt", FileMode.Open, FileAccess.Read))//使用FileStream文件流读取文本文件的时候，不需要指定编码，因为编码是在将byte数组转换为字符串的时候才需要使用编码，而这里是直接读取到byte[]，所以无需使用编码
            {
                //根据文件的总字节数，创建一个byte数组，这种方式会将文件内容一次性读取出来，读取到byte[]中。
                byte[] bytes = new byte[fsRead.Length];
                //2.读取文件
                fsRead.Read(bytes, 0, bytes.Length);

                //将byte数组转换为字符串
                //string msg = System.Text.Encoding.UTF8.GetString(bytes);
                //Console.WriteLine(msg);
            }
            Console.ReadKey();

            #endregion

            #region 通过文件流实现大文件的拷贝

            string source = @"c:\a.rmvb";
            string target = @"d:\a.rmvb";
            BigFileCopy(source, target);
            Console.WriteLine("ok");
            #endregion


            ////Person p = new Person();
            ////p.Dispose();
            //using (Person p = new Person())
            //{

            //}
            //Console.ReadKey();

            //double d = 10;
            //int n = (int)d;

            //byte b = 9;
            //byte s = (byte)(255 - b);


        }

        /// <summary>
        /// 通过文件流实现将source中的文件拷贝到target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private static void BigFileCopy(string source, string target)
        {
            //1.创建一个读取源文件的文件流
            using (FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                //2.创建一个写入新文件的文件流
                using (FileStream fsWrite = new FileStream(target, FileMode.Create, FileAccess.Write))
                {
                    //byte[] bytes = new byte[5242880];
                    //拷贝文件的时候，创建的一个中间缓冲区
                    byte[] bytes = new byte[1024 * 1024 * 10];
                    //返回值表示本次实际读取到的字节个数。
                    int r = fsRead.Read(bytes, 0, bytes.Length);
                    while (r > 0)
                    {
                        //将读取到的内容写入到新文件中。
                        //第三个参数应该是实际读取到的字节数，而不是数组的长度.
                        fsWrite.Write(bytes, 0, r);
                        //Console.Write(". ");
                        double d = (fsWrite.Position / (double)fsRead.Length) * 100;
                        Console.WriteLine("{0}%", d);
                        r = fsRead.Read(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }

    public class Person : IDisposable
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            Console.WriteLine("。。。。。。。。。。。。。。。。。。。。。");
        }

        #endregion
    }
}
