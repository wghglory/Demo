using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Xml;


namespace _06自己实现序列化
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<Person> list = new List<Person>();
            //list.Add(new Person() { Name = "许万里", Age = 18, Email = "xwl@yahoo.com" });
            //list.Add(new Person() { Name = "刘万仁", Age = 18, Email = "lwr@yahoo.com" });
            //list.Add(new Person() { Name = "熊薇", Age = 18, Email = "xw@yahoo.com" });
            //list.Add(new Person() { Name = "郎吉祥", Age = 18, Email = "ljx@yahoo.com" });

            //MySerialize(list, typeof(List<Person>));

            //Console.WriteLine("ok");

            //Person p = new Person() { Name = "赵辉猛", Age = 18, Email = "zhm@yahoo.com" };

            //MySerialize(p, typeof(Person));
            //Console.WriteLine("ok");
            //Console.ReadKey();

            Car car = new Car() { Brand = "兰博基尼", Number = "京A888888", PaiLiang = "600" };
            MySerialize(car, typeof(Car));
            Console.WriteLine("ok");
            Console.ReadKey();



            //==================================================
            //Car car = new Car() { Brand = "兰博基尼", Number = "京A888888", PaiLiang = "600" };
            //XmlSerializer xml = new XmlSerializer(typeof(Car));
            //using (FileStream fs = File.OpenWrite("MyCar.xml"))
            //{
            //    xml.Serialize(fs, car);

            //}
            //Console.WriteLine("ok");
            //Console.ReadKey();
            //XmlReader
            //using (XmlTextReader reader = new XmlTextReader(""))
            //{
            //    while (reader.Read())
            //    {
            //        reader.ReadElementContentAs
            //    }
            //}

        }


        //自己写一个序列化方法，把一个对象序列化到一个xml文件中
        private static void MySerialize(object obj, Type type)
        {

            Type ilistType = typeof(IList<Person>);
            //1.判断当前这个类型是否实现了IList<T>接口。
            if (ilistType.IsAssignableFrom(type))
            {
                //按照集合的方式来序列化
            }
            else
            {
                //按照对象的方式来序列化
                //把当前对象写入到xml文件
                //写入xml文件，把类名作为根节点
                XDocument document = new XDocument();
                string nsStr = type.ToString();  //命名空间.类名
                string className = nsStr.Substring(nsStr.LastIndexOf('.') + 1);
                //写入一个根节点
                XElement rootElement = new XElement(className);
                //获取当前类型中的所有的属性
                PropertyInfo[] properties = type.GetProperties();
                //遍历当前类型中的每个属性
                foreach (PropertyInfo item in properties)
                {

                    //现在该如何获取这个属性是否被标记了MyXmlIgnore标记呢？
                    object[] objsAttr = item.GetCustomAttributes(typeof(MyXmlIgnoreAttribute), false);
                    if (objsAttr.Length > 0)
                    {
                        continue;   //跳过当前循环实现忽略
                    }

                    //将当前属性写到xml文件中（其实就是序列化到了该文件中）
                    rootElement.SetElementValue(item.Name, item.GetValue(obj, null));
                }
                document.Add(rootElement);
                document.Save(className + ".xml");

            }

            //2.如果实现了该接口则把当前对象当做集合来进行序列话

            //3.如果没有实现该接口，则把当前对象当做一个普通的对象来序列化。
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

    public class Car
    {
        //[XmlIgnore]
        public string Brand
        {
            get;
            set;
        }

        [MyXmlIgnore]
        public string Number
        {
            get;
            set;
        }
        [MyXmlIgnore]
        public string PaiLiang
        {
            get;
            set;
        }
    }

    public class MyXmlIgnoreAttribute : Attribute
    {

    }
}
