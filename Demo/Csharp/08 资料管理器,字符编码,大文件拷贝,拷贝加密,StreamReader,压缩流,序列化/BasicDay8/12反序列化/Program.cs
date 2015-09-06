using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using _11对象序列化;

namespace _12反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.反序列化步骤：
            //1.创建二进制序列化器
            BinaryFormatter bf = new BinaryFormatter();
            //2.创建文件流
            using (FileStream fsRead = new FileStream("hl.bin", FileMode.Open))
            {
                //3.进行反序列化
                object obj = bf.Deserialize(fsRead);
                Student s = obj as Student;
                Console.WriteLine(s.Name + "     " + s.Age + "    " + s.Email + "    " + s.Car.Name);
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
