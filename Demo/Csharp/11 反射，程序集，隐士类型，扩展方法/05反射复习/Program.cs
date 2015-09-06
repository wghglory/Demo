using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace _03反射复习
{
    class Program
    {
        static void Main(string[] args)
        {
            //反射
            //1.动态加载程序集
            Assembly ams = Assembly.LoadFile(@"c:\07TestDll.dll");


            //2.获取类型
            //获取所有类型
            //ams.GetTypes()
            //ams.GetExportedTypes();//获取所有public类型
            //获取Person的Type
            Type typePerson = ams.GetType("_07TestDll.Person");




            //3.获取类型中的成员
            //获取所有方法
            //typePerson.GetMethods();
            //typePerson.GetProperties();
            //typePerson.GetFields();
            //typePerson.GetEvents();
            //typePerson.GetMembers();

            //MethodInfo[] methods = typePerson.GetMethods();
            //for (int i = 0; i < methods.Length; i++)
            //{
            //    Console.WriteLine(methods[i].Name);
            //}

            ////调用SayHi方法
            //MethodInfo methodSayHi = typePerson.GetMethod("SayHi");
            ////创建对象。
            //object obj = Activator.CreateInstance(typePerson);
            //methodSayHi.Invoke(obj, null);

            //Console.ReadKey();





            //4.调用成员



        }
    }
}
