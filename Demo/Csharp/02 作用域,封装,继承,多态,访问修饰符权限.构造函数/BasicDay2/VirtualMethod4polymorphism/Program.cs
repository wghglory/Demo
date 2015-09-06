using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMethod4polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Chinese();//new American();//new Person();
            //p.SayNationality();

            Person[] pers = new Person[6];

            pers[0] = new American();
            pers[1] = new Chinese();
            pers[2] = new Japanese();
            pers[3] = new Chinese();
            pers[4] = new American();
            pers[5] = new British();

            //遍历pers数组
            for (int i = 0; i < pers.Length; i++)
            {
                #region 不能忍的代码

                //if (pers[i] is American)
                //{
                //    ((American)pers[i]).SayNationality();
                //}
                //else if (pers[i] is Chinese)
                //{
                //    ((Chinese)pers[i]).SayNationality();
                //}
                //else if (pers[i] is Japanese)
                //{
                //    ((Japanese)pers[i]).SayNationality();
                //}

                #endregion

                //希望这里只写一句话
                pers[i].SayNationality();//这句话就体现了多态
            }
            Console.ReadKey();
        }
    }
    public class Person
    {
        public string Name
        {
            get;
            set;
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

        //第一步：将父类中的对应方法前加virtual关键字。即：将对应的方法变为“虚方法”
        public virtual void SayNationality()
        {
            Console.WriteLine("地球人");
        }
    }

    public class American : Person
    {
        //通过使用override关键字将父类Person中的虚方法"SayNationality"重写为子类自己想要的。
        //说出自己的国籍
        public override void SayNationality()
        {
            Console.WriteLine("USA");
        }
    }

    public class Japanese : Person
    {
        public override void SayNationality()
        {
            Console.WriteLine("日本");
        }
    }

    public class Chinese : Person
    {
        public override void SayNationality()
        {
            Console.WriteLine("中国");
        }
    }

    public class British : Person
    {
        public override void SayNationality()
        {
            Console.WriteLine("英国");
        }
    }
}
