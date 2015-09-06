using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04反射动态加载程序集01
{
    class Program
    {
        static void Main(string[] args)
        {
            //反射：没有像02一样添加01项目的引用，而这里通过反射动态加载

            //根据程序路径动态加载程序集
            Assembly asm = Assembly.LoadFile(@"\\psf\Home\Documents\Visual Studio 2013\Projects\AssemblyReflection\01TestDll\bin\Debug\01TestDll.dll");

            //1.1.获得该程序集中的所有类型：
            Type[] types = asm.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].FullName);
            }
            //1.2.获得public类型
            Type[] types2 = asm.GetExportedTypes();
            for (int i = 0; i < types2.Length; i++)
            {
                Console.WriteLine(types2[i].FullName);
            }
            //1.3.获取指定类型
            Type typePerson = asm.GetType("_01TestDll.Person");


            //2.获取某个类型中的成员，调用
            //2.1调用person类中方法：
            //2.2调用SayHi方法
            MethodInfo method = typePerson.GetMethod("SayHi");
            //创建person类型对象
            object obj = Activator.CreateInstance(typePerson);
            method.Invoke(obj, null);

            //调用无参数的sayhello
            MethodInfo m2 = typePerson.GetMethod("SayHello", new Type[] { });
            m2.Invoke(Activator.CreateInstance(typePerson), null);
            //调用有参数的sayhello
            MethodInfo m3 = typePerson.GetMethod("SayHello", new Type[] { typeof(string) });
            //调用该重载方法就是根据后面type[]：        
            m3.Invoke(Activator.CreateInstance(typePerson), new object[] { "welcome!" });

            //调用又返回值的就是invoke接受他
            MethodInfo m4 = typePerson.GetMethod("Add", new Type[] { typeof(int), typeof(int) });
            int result = (int)m4.Invoke(Activator.CreateInstance(typePerson), new object[] { 1, 2 });
            Console.WriteLine(result);

            //===================通过Type创建对象=============
            //获取参数类型
            Type paraType = typePerson.GetMethod("SayHello", new Type[] { typeof(string) }).GetParameters()[0].ParameterType;

            object o = Activator.CreateInstance(typePerson);
            Console.WriteLine(o);

            //通过调用指定的构造函数创建对象
            ConstructorInfo info = typePerson.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });
            //调用构造函数来创建对象
            object o2 = info.Invoke(new object[] { "guanghui", 18, "wgh@gmail.com" });
            
            //获取对象属性的值：
            PropertyInfo prop = typePerson.GetProperty("Name");
            string name = prop.GetValue(o2, null).ToString();


            Console.WriteLine(name);

            Console.ReadKey();
        }
    }
}
