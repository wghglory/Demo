using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03Reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //1.怎么获取一个类型的元数据Type，2种办法。
            MyClass m = new MyClass();
            Type t1 = m.GetType(); //获取了MyClass的type
            Type t2 = typeof(MyClass); //通过typeof，无需获取MyClass对象就可以获得type

            t1.BaseType.ToString();  //获取当前类型父类

            //获得当前类型所有字段信息
            //这里只能获得非私有字段
            FieldInfo[] fields = t2.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i].Name);
            }

            //获得属性
            PropertyInfo[] props = t2.GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                Console.WriteLine(props[i].Name);
            }

            Console.ReadKey();
        }
    }

    class MyClass
    {
        public string[] _bfs;
        private string[] _gfs;
        public string Name { get; set; }

        public void Say()
        {
            Console.Write("hello world");
        }

        private void SayHello()
        {
            Console.Write("this is private!");
        }
    }
}
