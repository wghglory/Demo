using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDay1
{
    class Person
    {
        public virtual void SayHi()
        {
            Console.WriteLine("Hi~~~");
        }

        public int Age { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

    }
}
