using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 委托;
using System.IO;

namespace WriteTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething ds = new DoSomething();

            WriteTimeDelegate write = PrintTimeToConsole;  //2把方法传递给委托
            ds.Write(write);

            //or
            ds.Write(PrintTimeToConsole);   //2把方法传递给委托

            ds.Write(PrintTimeToFile);  //调用另一种方法

            Console.ReadKey();
        }

        static void PrintTimeToConsole()
        {
            Console.WriteLine(System.DateTime.Now.ToShortDateString());
        }

        static void PrintTimeToFile()
        {
            File.WriteAllText("text.txt", System.DateTime.Now.ToShortDateString());
        }
    }
}
