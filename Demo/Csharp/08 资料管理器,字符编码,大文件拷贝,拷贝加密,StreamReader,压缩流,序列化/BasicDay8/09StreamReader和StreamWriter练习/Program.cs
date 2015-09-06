using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _09StreamReader和StreamWriter练习
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (StreamReader reader = new StreamReader("工资文件.txt", Encoding.GetEncoding("gbk")))
            {
                using (StreamWriter writer = new StreamWriter("工资文件1.txt", false, Encoding.UTF8))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        string[] parts = line.Split('|');
                        //Console.WriteLine("{0}|{1}", parts[0], (int.Parse(parts[1]) * 2).ToString());
                        writer.WriteLine(string.Format("{0}|{1}", parts[0], (int.Parse(parts[1]) * 2).ToString()));
                    }
                }

            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
