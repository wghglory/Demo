using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _10压缩
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "杨中科";
            for (int i = 0; i < 25; i++)
            {
                msg += msg;
            }
            File.WriteAllText("yzk.txt", msg);
            Console.WriteLine(msg.Length);
            Console.WriteLine("ok");
            Console.ReadKey();

        }
    }
}
