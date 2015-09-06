using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 委托;

namespace ChangeName
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomething ds = new DoSomething();
            string[] names = new string[] { "mike", "john", "leonard", "guanghui" };
            ds.ChangeStrings(names, ChangeString);    //2把方法传递给委托
            ds.ChangeStrings(names, ChangeToStar);

            foreach (string item in names)
            {
                Console.WriteLine(item);
            }  
            Console.ReadKey();
        }

        public static string ChangeString(string str)
        {
            return str.ToUpper();
        }

        public static string ChangeToStar(string str)
        {
            return "*" + str + "*";
        }
    }
}
