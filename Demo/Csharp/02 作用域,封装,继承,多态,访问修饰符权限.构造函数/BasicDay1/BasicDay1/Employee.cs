using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDay1
{
    class Employee : Person
    {
        private decimal _salary;
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public override void SayHi()
        {
            Console.Write("employee's method");
        }
    }
}
