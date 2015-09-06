using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace _02xpath演示
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load("xmlfile1.xml");
            XmlNodeList nodeList = document.SelectNodes("//student[@position='1']");
            foreach (XmlNode item in nodeList)
            {
                Console.WriteLine(item.Name + "     " + item.Attributes["id"].Value);
            }
            Console.ReadKey();         
        }
    }
}
