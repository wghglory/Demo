using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace _02计算文件与字符串的Md5值
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 计算字符串的Md5值
            //Console.WriteLine("请输入一个字符串：");
            //string input = Console.ReadLine();
            //string encryptStr = GetMD5String(input);
            //Console.WriteLine(encryptStr);
            //Console.ReadKey();

            #endregion

            #region 计算一个文件的Md5值

            string path = @"c:\hello.txt";

            string md5String = EncyrptMd5FromFile(path);
            Console.WriteLine(md5String);
            Console.ReadKey();
            #endregion


            string md5 = "68d5b0923a8bb1387adfb044e105d512";
            for (int i = 0; i < 999999; i++)
            {
                string mm = GetMD5String(i.ToString());
                if (mm == md5)
                {
                    Console.WriteLine("破解成功！原文是：{0}", i);
                    break;
                }
            }
            Console.ReadKey();
        }

        private static string GetMd5FromFile(string path)
        {
            MD5 md5 = MD5.Create();
            using (FileStream fsRead = File.OpenRead(path))
            {
                //进行计算
                byte[] md5Buffer = md5.ComputeHash(fsRead);
                md5.Clear();
                return BitConverter.ToString(md5Buffer).Replace("-", "").ToLower();
            }


        }

        //计算字符串的md5值
        private static string GetMD5String(string input)
        {
            //1.创建一个md5对象
            MD5 md5Obj = MD5.Create();
            //1.1把字符串转换为byte[]
            byte[] buffer = System.Text.Encoding.Default.GetBytes(input);

            //2.通过md5对象计算给定值的md5
            byte[] md5Buffer = md5Obj.ComputeHash(buffer);
            //把byte[]数组转换为字符串
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < md5Buffer.Length; i++)
            //{
            //    sb.Append(md5Buffer[i].ToString("x2"));
            //}
            //3.释放资源
            md5Obj.Clear();
            // return sb.ToString();
            return BitConverter.ToString(md5Buffer).Replace("-", "").ToLower();
        }


        //计算文件的Md5值

    }
}
