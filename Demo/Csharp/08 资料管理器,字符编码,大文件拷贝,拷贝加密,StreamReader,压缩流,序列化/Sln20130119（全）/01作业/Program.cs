using System.IO;
using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace _01压缩解压
{
    public class Program
    {
        public static void Main()
        {

            #region 压缩解压

            string directoryPath = @"C:\Users\Steve\Desktop\英语\新概念英语文本\nce2";

            //创建一个文件夹对象
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);


            //获取当前文件夹下的所有子文件
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                //对于每个子文件都调用Compress()压缩方法
                Compress(fileToCompress);
            }


            //解压。。
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Decompress(fileToDecompress);
            }
            Console.WriteLine("ok");
            Console.ReadKey();


            #endregion

            #region 对象初始化器-集合初始化器
            ////Person p = new Person();
            ////p.Name = "hl";
            ////p.Age = 18;
            ////p.Email = "hl@163.com";

            ////Person p1 = new Person("xzl", 20, "xzl@yahoo.com");

            ////对象初始化器
            //// Person p2 = new Person() { Name = "pdh", Age = 20, Email = "pdh@yahoo.com" };

            ////集合初始化器
            //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            //Console.ReadKey();

            #endregion

            #region 压缩

            ////1.读取源文件
            using (FileStream fsRead = File.OpenRead("1.txt"))
            {
                //写入新文件的文件流
                using (FileStream fsWrite = File.OpenWrite("yasuo.rar"))
                {
                    //创建压缩流
                    using (GZipStream zip = new GZipStream(fsWrite, CompressionMode.Compress))
                    {
                        byte[] buffer = new byte[1024 * 10];
                        int r;
                        while ((r = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            zip.Write(buffer, 0, r);
                        }
                    }
                }
            }
            //Console.WriteLine("ok");
            //Console.ReadKey();
            #endregion

            #region 解压

            ////1.读取压缩文件
            using (FileStream fsRead = File.OpenRead("yasuo.rar"))
            {
                //2.创建压缩流
                using (GZipStream zip = new GZipStream(fsRead, CompressionMode.Decompress))
                {
                    using (FileStream fsWrite = File.OpenWrite("jieya.txt"))
                    {
                        byte[] buffer = new byte[1024 * 10];
                        //解压读取
                        int r;
                        while ((r = zip.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //写入新文件
                            fsWrite.Write(buffer, 0, r);
                        }
                    }
                }
            }
            //Console.WriteLine("ok");
            //Console.ReadKey();
            #endregion

        }

        public static void Compress(FileInfo fileToCompress)
        {
            //创建一个指向当前文件fileToCompress的一个文件流。(读取当前文件)
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {

                    //创建了一个指向新文件的一个文件流
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            //将源文件的文件流直接拷贝到压缩流中compressionStream
                            originalFileStream.CopyTo(compressionStream);

                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
                        }
                    }
                }
            }
        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }
    }

    public class Person
    {
        public Person()
        {

        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

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

    }
}
