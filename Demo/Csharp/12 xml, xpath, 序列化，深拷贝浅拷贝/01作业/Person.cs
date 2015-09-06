using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01作业
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name, int age, string email, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
            this.Id = id;
        }

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

        public string Id
        {
            get;
            set;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
