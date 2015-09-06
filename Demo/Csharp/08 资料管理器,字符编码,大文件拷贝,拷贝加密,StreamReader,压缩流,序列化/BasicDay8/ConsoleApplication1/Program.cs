using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread tt = new Thread(Do);
            //tt.IsBackground = true;
            tt.Start();
            Console.WriteLine("==========================================");
            Console.WriteLine("==========================================");
            Console.WriteLine("==========================================");
            Console.ReadLine();

        }

        static void Do()
        {
            while (true)
            {
                Console.WriteLine("111");
            }
        }
    }
}
