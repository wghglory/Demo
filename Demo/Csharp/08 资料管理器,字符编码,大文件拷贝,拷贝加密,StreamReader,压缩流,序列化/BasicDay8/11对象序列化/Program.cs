using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _11对象序列化
{
    class Program
    {
        static void Main(string[] args)
        {

            //1.JavaScript序列化(json)

            Person p = new Person();
            p.Name = "黄林";
            p.Age = 19;
            p.Email = "huanglin@yahoo.com";

            List<Person> list = new List<Person>();
            list.Add(p);
            list.Add(new Person() { Name = "杨硕", Age = 20, Email = "ys@yahoo.com" });
            list.Add(new Person() { Name = "何红卫", Age = 21, Email = "hhw@yahoo.com" });

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string str = jsSerializer.Serialize(list);
            Console.WriteLine(str);
            Console.ReadKey();

            //2.xml序列化
            //Person p = new Person();
            p.Name = "黄林";
            p.Age = 19;
            p.Email = "huanglin@yahoo.com";

            //List<Person> list = new List<Person>();
            list.Add(p);
            list.Add(new Person() { Name = "杨硕", Age = 20, Email = "ys@yahoo.com" });
            list.Add(new Person() { Name = "何红卫", Age = 21, Email = "hhw@yahoo.com" });


            XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream("person.xml", FileMode.Create))
            {
                xml.Serialize(fs, list);
            }
            Console.WriteLine("ok");
            Console.ReadKey();



            //3.实现二进制序列化
           // Person p = new Person();
            p.Name = "黄林";
            p.Age = 19;
            p.Email = "huanglin@yahoo.com";
            p.Car = new Car() { Name = "保时捷" };

            Student hl = new Student();
            hl.Name = "黄林";
            hl.Age = 20;
            hl.Email = "hl@yahoo.com";
            hl.Car = new Car() { Name = "保时捷" };

            //1.创建一个二进制序列化器
            BinaryFormatter bf = new BinaryFormatter();
            //2.创建文件流4
            using (FileStream fsWrite = new FileStream("hl.bin", FileMode.Create))
            {
                //3.执行序列化
                //注意1：.在二进制序列化中，要求被序列化的对象的类型必须标记为可序列化
                //注意2：.并且该类型中所有字段的类型也必须标记为可序列化的
                //注意3：并且该类型的所有父类也必须标记为可序列化的。
                bf.Serialize(fsWrite, hl);
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }

    [Serializable] //特性 Attribute              【Property 属性】
    public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private Car _car;

        public Car Car
        {
            get { return _car; }
            set { _car = value; }
        }
    }

    [Serializable]
    public class Car
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    [Serializable]
    public class Student : Person
    {

    }
}

