using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05显示实现接口    //一个类实现了多个接口，这些接口恰好有重名的方法
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student stu = new Student();
            //stu.Fly();
            //Console.ReadKey();

            //IFace2 face1 = new Student();
            //face1.Fly();
            //Console.ReadKey();

            //Teacher teacher = new Teacher();
            //teacher.Fly();//???????正常实现接口的Fly方法，显示实现的调不到，因为是private的。
            //Console.ReadKey();

            //IFace1 face1 = new Teacher();
            //face1.Fly();//????

            //IFace2 face2 = new Teacher();
            //face2.Fly();
            //Console.ReadKey();

            //MyClass mc = new MyClass();
            IFace1 face = new MyClass();
            face.Fly();

            IFace2 face2 = new MyClass();
            face2.Fly();
            Console.ReadKey();
        }
    }

    class Teacher : IFace1, IFace2
    {
        #region IFace1 成员

        public void Fly()
        {
            Console.WriteLine("Face1接口中的Fly方法");
        }

        #endregion
        #region IFace2 成员
        //显示实现接口没有访问修饰符，默认是私有的。
        //显示实现接口时，在方法名称前加了“接口名”，形如：  接口名.方法名
        //调用显示实现接口只能通过接口.方法，不能通过类.方法
        void IFace2.Fly()
        {
            Console.WriteLine("Face2中的Fly方法.");
        }

        #endregion
    }


    public interface IFace1
    {
        void Fly();
    }

    public interface IFace2
    {
        void Fly();
    }

    class Student : IFace1, IFace2
    {
        public void Fly()
        {
            Console.WriteLine("实现了IFace1接口中的fly方法。");
        }
    }

    class MyClass : IFace1, IFace2   //同时实现显示接口，只能通过接口访问，不能通过继承的类访问其中的方法
    {

        #region IFace1 成员

        void IFace1.Fly()
        {
            Console.WriteLine("face1中的fly");
        }

        #endregion

        #region IFace2 成员

        void IFace2.Fly()
        {
            Console.WriteLine("face2中的fly");
        }

        #endregion
    }


}
