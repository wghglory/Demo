using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07抽象类练习2
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer dell = new Computer();

            UDisk sandisk = new UDisk();

            MobileDisk westData = new MobileDisk();

            Mp3 itouch = new Mp3();

            dell.Dev = itouch;

            dell.Pc_ReadData();
            dell.Pc_WriteData();

            Console.ReadKey();



            Duck duck = new RealDuck();//new RubberDuck();
            duck.Swim();
            duck.Bark();
            Console.ReadKey();
        }
    }

    class Computer
    {
        public MobileStorage Dev
        {
            get;
            set;
        }

        public void Pc_WriteData()
        {
            Dev.Write();
        }

        public void Pc_ReadData()
        {
            Dev.Read();
        }
    }



    /// <summary>
    /// 可移动存储设备
    /// </summary>
    abstract class MobileStorage
    {
        public abstract void Read();

        public abstract void Write();
    }

    /// <summary>
    /// U盘
    /// </summary>
    class UDisk : MobileStorage
    {

        public override void Read()
        {
            Console.WriteLine("U盘的读取数据.....");
        }

        public override void Write()
        {
            Console.WriteLine("U盘的写入数据......");
        }
    }

    /// <summary>
    /// 移动硬盘
    /// </summary>
    class MobileDisk : MobileStorage
    {

        public override void Read()
        {
            Console.WriteLine("移动硬盘读取数据.....");
        }

        public override void Write()
        {
            Console.WriteLine("移动硬盘写入数据.......");
        }
    }

    class Mp3 : MobileStorage
    {

        public override void Read()
        {
            Console.WriteLine("Mp3读取数据.....");
        }

        public override void Write()
        {
            Console.WriteLine("mp3写入数据......");
        }

        public void PlayMusic()
        {
            Console.WriteLine("Music播放中.....");
        }
    }
}
