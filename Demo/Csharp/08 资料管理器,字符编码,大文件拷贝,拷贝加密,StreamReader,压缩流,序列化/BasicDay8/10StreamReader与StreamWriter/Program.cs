using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _10StreamReader与StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {

            #region StreamWriter
            using (StreamWriter writer = new StreamWriter("test.txt", true, Encoding.Default))
            {
                for (int i = 0; i < 100; i++)
                {
                    writer.WriteLine(i);
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
            #endregion

            #region StreamReader
            //用来逐行读取文本文件。
            using (StreamReader reader = new StreamReader("1.txt", Encoding.Default))
            {
                //StreamReader是逐行读取文本文件
                //直到文件的末尾
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }

                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                Console.ReadKey();
            }
            #endregion


        }
    }
}
