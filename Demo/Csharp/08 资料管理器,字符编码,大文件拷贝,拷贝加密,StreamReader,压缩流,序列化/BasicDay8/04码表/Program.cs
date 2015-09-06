using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _04码表
{
    class Program
    {
        static void Main(string[] args)
        {
            //char ch = '黄';
            //char ch1 = '林';
            //Console.WriteLine((int)ch);
            //Console.WriteLine((int)ch1);
            //Console.ReadKey();


            //string msg = File.ReadAllText("a.txt", Encoding.GetEncoding("gbk"));
            //Console.WriteLine(msg);
            //Console.ReadKey();


            //string msg = File.ReadAllText("b.txt");
            //Console.WriteLine(msg);
            //Console.ReadKey();

            ////Encoding.Unicode


            EncodingInfo[] infos = Encoding.GetEncodings();
            using (StreamWriter w = new StreamWriter("encoding.txt"))
            {
                foreach (var item in infos)
                {
                    w.WriteLine(item.CodePage + "\t" + item.Name + "\t" + item.DisplayName);
                }
            }

            Console.WriteLine("ok");
            Console.ReadKey();

        }
    }
}
