using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _02对象序列化
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 序列化介绍
            //Person p1 = new Person();
            //p1.Name = "杨中科";
            //p1.Age = 19;
            //p1.Email = "yzk@itcast.cn";

            //2.序列化只序列化数据，（比如字段的值，属性的值，其实也是字段的值。）
            //1.序列化后，只是把对象的存储格式改变了，对于对象的实际存储内容并没有改变。
            //3.有序列化就有反序列化。
            ////xml序列化
            //XmlSerializer xml = new XmlSerializer(typeof(Person));
            //using (FileStream fs = new FileStream("person.xml", FileMode.Create))
            //{
            //    xml.Serialize(fs, p1);
            //}
            //Console.WriteLine("ok");
            //Console.ReadKey();




            ////json序列化
            //JavaScriptSerializer jsSer = new JavaScriptSerializer();
            //string msg = jsSer.Serialize(p1);
            //Console.WriteLine(msg);
            //Console.ReadKey();

            #endregion

            #region 二进制序列化
            Person p1 = new Person();
            p1.Name = "杨中科";
            p1.Age = 19;
            p1.Email = "yzk@itcast.cn";
            p1.BenChi = new Car();



            //二进制序列化就是把对象变成流的过程，就是把对象变成byte[]

            //将Person对象序列化后保存到磁盘上，要操作磁盘文件所以需要使用文件流(FileStream)

            //二进制序列化注意点：
            //1.被序列化的对象的类型必须标记为“可序列化”
            //2.被序列化的类的所有父类也必须标记为“可序列化”
            //3.要求被序列化的对象的类型中的所有字段(属性)的类型也必须标记为“可序列化的”


            //1.二进制序列化步骤：
            //1.创建序列化器
            BinaryFormatter bf = new BinaryFormatter();
            //1.1创建一个文件流
            using (FileStream fsWrite = new FileStream("person.bin", FileMode.Create))
            {
                //2.开始执行序列化
                bf.Serialize(fsWrite, p1);
            }
            Console.WriteLine("序列化完毕！");
            Console.ReadKey();

            #endregion

        }

    }

    [Serializable]
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("吃东西。");
        }
    }



    [Serializable]
    public class Person : Animal
    {
        public Car BenChi
        {
            get;
            set;
        }

        [NonSerialized]
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
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

        public void Say()
        {
            Console.WriteLine("ok");
        }

        public MyClass SayHello(MyClass mc)
        {
            return new MyClass();
        }
    }

    public class MyClass
    {

    }

    [Serializable]
    public class Car
    {

    }
}
