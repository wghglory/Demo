using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            M1(200);
            Console.ReadKey();
        }
        static void M1(string msg)
        {
            Console.WriteLine(msg);
        }

        static void M1(int m)
        {
            Console.WriteLine(m);
        }
    }
}
