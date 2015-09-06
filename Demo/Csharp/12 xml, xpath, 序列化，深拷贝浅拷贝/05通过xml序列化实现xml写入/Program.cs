using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Xml;

namespace _05通过xml序列化实现xml写入
{
    class Program
    {
        static void Main(string[] args)
        {

            #region List集合的xml序列化。这样不用再像之前那样创建节点写入

            List<Person> list = new List<Person>();
            list.Add(new Person() { Name = "许万里", Age = 18, Email = "xwl@yahoo.com" });
            list.Add(new Person() { Name = "刘万仁", Age = 18, Email = "lwr@yahoo.com" });
            list.Add(new Person() { Name = "熊薇", Age = 18, Email = "xw@yahoo.com" });
            list.Add(new Person() { Name = "郎吉祥", Age = 18, Email = "ljx@yahoo.com" });


            //实现xml序列化
            XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = File.OpenWrite("list.xml"))
            {
                xml.Serialize(fs, list);
            }
            Console.WriteLine("ok");
            Console.ReadKey();

            //===========不能对dictionary序列化=================================================

            //List<Person> list = new List<Person>();
            //list.Add(new Person() { Name = "许万里", Age = 18, Email = "xwl@yahoo.com" });
            //list.Add(new Person() { Name = "刘万仁", Age = 18, Email = "lwr@yahoo.com" });
            //list.Add(new Person() { Name = "熊薇", Age = 18, Email = "xw@yahoo.com" });
            //list.Add(new Person() { Name = "郎吉祥", Age = 18, Email = "ljx@yahoo.com" });

            //Dictionary<string, Person> dict = new Dictionary<string, Person>();
            //dict.Add(list[0].Name, list[0]);
            //dict.Add(list[1].Name, list[1]);
            //dict.Add(list[2].Name, list[2]);
            //dict.Add(list[3].Name, list[3]);

            ////实现xml序列化
            //XmlSerializer xml = new XmlSerializer(typeof(Dictionary<string, Person>));
            //using (FileStream fs = File.OpenWrite("dict.xml"))
            //{
            //    xml.Serialize(fs, dict);
            //}
            //Console.WriteLine("ok");
            //Console.ReadKey();

            #endregion

        }

    }

    public class Person
    {
        public string Name
        {
            get;
            set;
        }

        //这个特性的作用就是打了个标记而已。
        [XmlIgnore]
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
