using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _08通过文件流操作文本文件
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion

            string msg = "_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件_08通过文件流操作文本文件";

            using (FileStream fs = new FileStream("test.txt", FileMode.Create))
            {
                byte[] byts = System.Text.Encoding.UTF8.GetBytes(msg);
                fs.Write(byts, 0, byts.Length);
            }
            Console.WriteLine("ok");
            Console.WriteLine("读取：");
            using (FileStream fsRead = new FileStream("test.txt", FileMode.Open))
            {
                byte[] buffer = new byte[fsRead.Length];
                fsRead.Read(buffer, 0, buffer.Length);
                string s = System.Text.Encoding.UTF8.GetString(buffer);
                Console.WriteLine(s);
            }
            Console.ReadKey();


            #endregion

            #region 通过文件流操作文本文件StreamReader和StreamWriter

            //1.读取一个文本文件
            using (StreamReader reader = new StreamReader("火星文.txt"))
            {
                //1.方式一
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                //方式二：
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            Console.WriteLine("ok");
            //Console.ReadKey();

            #endregion


            #region StreamWriter写一个文本文件

            using (StreamWriter sw = new StreamWriter("t.txt", false, Encoding.UTF8))
            {
                for (int i = 0; i < 1000; i++)
                {
                    sw.WriteLine(i.ToString() + "传智播客.net");
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
            #endregion

        }
    }
}
