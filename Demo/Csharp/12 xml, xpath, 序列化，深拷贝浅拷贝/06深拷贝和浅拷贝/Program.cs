using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _06深拷贝和浅拷贝
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 深拷贝：不共享数据   浅拷贝：数据共享

            //Person llb = new Person() { Name = "llb", Age = 20, Email = "llb@yahoo.com" };
            ////这句话没有发生任何的对象拷贝。
            //Person zhm = llb;



            ////此时lll与llb是两个不同的对象。在内存中有两个对象内存，所以此时已经发生了对象的拷贝。
            ////===========================下面的代码实现对象的“浅拷贝”=============================
            //Person llb = new Person() { Name = "llb", Age = 20, Email = "llb@yahoo.com", Bike = new Bike() { Brand = "永久" } };
            //Person lll = new Person();
            //lll.Name = llb.Name;
            //lll.Age = llb.Age;
            //lll.Email = llb.Email;
            //lll.Bike = llb.Bike;



            ////此时lll与llb是两个不同的对象。在内存中有两个对象内存，所以此时已经发生了对象的拷贝。
            ////=================================深拷贝：拷贝过程中创建了新对象Bike==============================================
            //Person p1 = new Person();
            //p1.Name = "成先程";
            //p1.Age = 21;
            //p1.Email = "cxc@yahoo.com";
            //p1.Bike = new Bike() { Brand = "凤凰" };

            //Person p2 = new Person();
            //p2.Name = p1.Name;
            //p2.Age = p1.Age;
            //p2.Email = p1.Email;
            //p2.Bike = new Bike() { Brand = p1.Bike.Brand };   //就是这句话深拷贝

            #endregion

            #region 通过代码来实现深拷贝与浅拷贝

            //1.实现浅拷贝
            Person p1 = new Person();
            p1.Name = "杨硕";
            p1.Age = 18;
            p1.Email = "ys@163.com";
            p1.Bike = new Bike() { Brand = "捷安特" };

            //浅拷贝
            Person p2 = p1.QianKaobei();

            string sname = p1.Name;
            string sname1 = p2.Name;

            string semail = p1.Email;
            string semail1 = p2.Email;

            Bike b1 = p1.Bike;
            Bike b2 = p2.Bike;

            #endregion

            #region 通过二进制序列化实现深拷贝

            //2.实现深拷贝
            Person p1 = new Person();
            p1.Name = "杨硕";
            p1.Age = 18;
            p1.Email = "ys@163.com";
            p1.Bike = new Bike() { Brand = "捷安特" };
            
            //深拷贝
            Person p2 = p1.ShenKaoBei();

            string sname = p1.Name;
            string sname1 = p2.Name;

            string semail = p1.Email;
            string semail1 = p2.Email;

            Bike b1 = p1.Bike;
            Bike b2 = p2.Bike;

            #endregion

        }
    }

    [Serializable]
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

        public Bike Bike
        {
            get;
            set;
        }

        public Person QianKaobei()
        {
            //一句话实现浅拷贝
            return this.MemberwiseClone() as Person;

            //MemberwiseClone的作用就是把当前对象浅拷贝一份。
        }


        //通过序列化与反序列化会将当前对象实现一次深拷贝
        public Person ShenKaoBei()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, this);

                //紧接着就执行反序列化
                ms.Position = 0;
                return bf.Deserialize(ms) as Person;
            }
        }

    }

    [Serializable]
    public class Bike
    {
        public string Brand
        {
            get;
            set;
        }
    }
}
