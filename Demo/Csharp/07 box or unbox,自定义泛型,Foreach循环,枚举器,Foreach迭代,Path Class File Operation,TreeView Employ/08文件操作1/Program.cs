using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _08文件操作1
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Path类基本操作

            //Directory.GetDirectories(
            string path = @"C:\Program Files\A大大大大\afds.txt";

            //1.获取文件名
            Console.WriteLine(Path.GetFileName(path));
            //2.获取文件的后缀
            Console.WriteLine(Path.GetExtension(path));
            //3.获取不带后缀的文件名
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            //4.获取该路径的目录部分。
            Console.WriteLine(Path.GetDirectoryName(path));
            //5.将路径中的文件名的后缀改为.exe
            Console.WriteLine(Path.ChangeExtension(path, ".exe"));
            //Console.ReadKey();


            string s1 = @"c:\abc\x\y\";
            string s2 = "hello.txt";
            //Console.WriteLine(s1 + s2);
            Console.WriteLine(Path.Combine(s1, s2));
            Console.ReadKey();

            //string path = "a.txt";
            Console.WriteLine(Path.GetFullPath(path));
            Console.WriteLine(File.ReadAllText(path));
            Console.ReadKey();

            Console.WriteLine(Path.GetTempPath());
            Console.WriteLine(Path.GetTempFileName());
            string aa = Path.GetRandomFileName();
            Console.WriteLine(aa);
            Console.ReadKey();

            //Guid.NewGuid().ToString();
            #endregion

            #region Directory类基本操作

            //1.创建一些目录
            for (int i = 0; i < 10; i++)
            {
                Directory.CreateDirectory(@"c:\" + i);
            }

            //2.删除一些目录
            for (int i = 0; i < 10; i++)
            {
                //删除目录的时候，如果给定的目录不存在则报异常。
                //Delete方法直接删除目录的时候，如果目录不为空，则报异常
                // Directory.Delete(@"c:\" + i);
                Directory.Delete(@"c:\" + i, true);
            }

            //3.移动（剪切）一些目录
            //移动不能跨磁盘操作
            //Directory.Move(@"c:\nihao", @"c:\yes\nihao");
            //相当于重命名
            //Directory.Move(@"c:\yes", @"c:\no");
            Directory.Delete(@"c:\no", true);
            //Directory.Exists(
            Console.WriteLine("ok");
            Console.ReadKey();


            //获取指定目录下的所有的子文件(直接子文件)
            //string path = @"C:\DRIVERS\WIN\DISPLAY3";
            string[] files = Directory.GetFiles(path, "*.*",SearchOption.AllDirectories);
            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

            //2获取指定目录下的所有的子目录
            //string path = @"C:\DRIVERS\WIN\DISPLAY3";
            string[] dirs = Directory.GetDirectories(path);
            foreach (var item in dirs)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();


            #endregion

        }
    }
}
