using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace _01复习
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 工资翻倍

            //FileStream fs = new FileStream("",FileMode.Append,FileAccess.Write);

            //工资文件翻倍输出到新文件
            using (StreamReader reader = new StreamReader("工资文件.txt", Encoding.Default))
            {
                //创建一个写文件的文件流
                using (StreamWriter writer = new StreamWriter("工资文件（新）.txt", false, Encoding.Default))
                {

                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        string newLine = string.Format("{0}|{1}", parts[0], int.Parse(parts[1]) * 2);
                        //将新行写入
                        writer.WriteLine(newLine);
                        // File.AppendAllText("", "");//不要调这个方法，这样做每次都new一个StreamWriter.
                    }
                }

            }
            //Console.WriteLine("ok");
            //Console.ReadKey();
            #endregion
            
            string s = "杨中科";
            for (int i = 0; i < 25; i++)
            {
                s = s + s;
            }
            File.WriteAllText("test.txt", s);
            Console.WriteLine("ok");
            Console.ReadKey();


        }
    }
}
