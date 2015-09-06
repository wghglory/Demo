using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace _01作业
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>() { 5, 6 };
            ////int r = list.Single(M1);
            //int r = list.Single(x => x > 5);
            //Console.WriteLine(r);
            //Console.ReadKey();

            ////int r = list.Single();
            ////list.sin
            ////Console.WriteLine(r);
            ////Console.ReadKey();

            ////XmlDocument xml = new XmlDocument();
            ////xml.va
            //XmlDocument document = new XmlDocument();
            //document.Load("UserData.xml");
            //XmlElement element = document.DocumentElement;
            //string v = element.SelectSingleNode("user/name").InnerText;
            //string v1 = element.SelectSingleNode("user/name").Value;
            //Console.WriteLine(v);
            //Console.WriteLine(v1);
            //Console.ReadKey(); 

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 78, 9 };
            IEnumerable<int> arr = list.Where(x => x % 2 == 0);
            
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();


        }

        static bool M1(int n)
        {
            return n > 5;
        }
    }
}