﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using _02对象序列化;

namespace _03反序列化
{
    class Program
    {
        static void Main(string[] args)
        {

            //二进制反序列化的时候注意：
            //1.必须获取被序列化的对象的类型所在的程序集，因为：反序列化要根据序列化文件重新还原该对象，而序列化文件中只包含哪些数据信息，并不包含该对象的类型相关的信息，比如：该对象是继承自哪个父类，实现了哪些接口，类型中包含哪些方法....，这些信息在对象序列化文件中都不包含，要获取这些信息必须通过该类型的程序集来获取。

            //1.创建序列化器
            BinaryFormatter bf = new BinaryFormatter();
            //1.1创建读取文件的文件流
            using (FileStream fsRead = new FileStream("person.bin", FileMode.Open))
            {
                //2.执行反序列化
                object obj = bf.Deserialize(fsRead);
                Person person = obj as Person;
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
                Console.WriteLine(person.Email);
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
