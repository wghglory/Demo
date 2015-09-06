using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _05文件拷贝
{
    class Program
    {
        static void Main(string[] args)
        {
            //string source = @"D:\软件\开发工具\vs2010\cn_visual_studio_2010_ultimate_x86_dvd_532347.iso";
            //string target = @"d:\vs2012.iso";

            //CopyFile(source, target);
            //Console.WriteLine("ok");
            //Console.ReadKey();


            //string msg = "怒放的生命   汪峰   经典励志歌曲  曾经多少次 跌倒在路上 曾经多少次 折断过翅膀 如今我已不 再感到彷徨 我想超越这 平凡的生活  我想要怒放的生命 就像飞翔在辽阔天空 就像穿行在无边的旷野 拥有挣脱一切的力量  曾经多少次 失去了方向 曾经多少次 破灭了梦想 如今我已不再感到迷茫 我要我的生命得到解放 我想要怒放的生命 就像飞翔在辽阔天空 就象穿行在无边的旷野 拥有挣脱一切的力量  我想要怒放的生命 就像矗立在彩虹之颠 就像穿行在璀璨的星河 拥有超越平凡的力量      曾经多少次失去了方向 曾经多少次破灭了梦想 如今我已不再感到迷茫 我要我的生命得到解放  我想要怒放的生命 就像飞翔在辽阔天空 就像穿行在无边的旷野 拥有挣脱一切的力量 我想要怒放的生命 就像矗立在彩虹之颠 就像穿行在璀璨的星河 拥有超越平凡的力量  我想要怒放的生命 就像飞翔在辽阔天空 就像穿行在无边的旷野 拥有挣脱一切的力量 我想要怒放的生命 就像矗立在彩虹之颠 就像穿行在璀璨的星河 拥有超越平凡的力量";
            //FileStream fsWrite = new FileStream(@"d:\a.txt", FileMode.Create, FileAccess.ReadWrite);
            //string msg = "12345";
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            //fsWrite.Write(buffer, 0, buffer.Length);
            //fsWrite.Flush();
            //fsWrite.Close();
            //fsWrite.Dispose();
            //Console.WriteLine("ok");
            //Console.ReadKey();

            //FileStream fsWrite = new FileStream(@"d:\a.txt", FileMode.Create, FileAccess.ReadWrite);
            //using (fsWrite)
            //{
            //    string msg = "12345";
            //    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
            //    fsWrite.Write(buffer, 0, buffer.Length);
            //}


            //Console.WriteLine("ok");
            //Console.ReadKey();

            using (Person p = new Person())
            {

            }
            //Person p = new Person();
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    p.Dispose();
            //}
            Console.WriteLine("ok");
            Console.ReadKey();

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


            public void Dispose()
            {
                Console.WriteLine("Person类中的Dispose()方法。");
            }
        }

        private static void CopyFile(string source, string target)
        {
            using (FileStream fsRead = new FileStream(source, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(target, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024 * 35];
                    int r;
                    while ((r = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //将读取到的内容写入到文件
                        fsWrite.Write(buffer, 0, r);
                        //输出拷贝进度。。
                        double d = fsWrite.Position / (double)fsRead.Length;
                        Console.WriteLine("拷贝进度：{0}%", d * 100);
                    }
                }
            }
        }
    }
}
