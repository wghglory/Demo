using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritancePractice
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Father
    {
        public Father(string lastName, double property, string bloodtype)
        {
            this.LastName = lastName;
            this.Property = property;
            this.BloodType = bloodtype;
        }
        public string LastName { get; set; }
        public double Property { get; set; }
        public string BloodType { get; set; }
    }
    class Son : Father
    {
        public Son(string lastName, double property, string bloodType)
            : base(lastName, property, bloodType)
        {

        }
        public void PlayGame()
        {
            Console.WriteLine("游戏中。。。。");
        }
    }

    class Daughter : Father
    {
        public Daughter(string lastName, double property, string bloodType)
            : base(lastName, property, bloodType)
        {

        }
        public void Dance()
        {
            Console.WriteLine("舞蹈中.....");
        }
    }

    class Vehicle
    {
        public string Brand { get; set; }
        public string Color { get; set; }

        public void Run()
        {
            Console.WriteLine("行驶。。。");
        }
    }

    class Truck : Vehicle
    {
        public int Weight { get; set; }

        public void LaHuo()
        {
            Console.WriteLine("拉货赚钱。。。。");
        }
    }

    class Car : Vehicle
    {
        public int Passenger { get; set; }

        public void ZaiKe()
        {
            Console.WriteLine("载客....");
        }
    }
}
