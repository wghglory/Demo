using System;
using System.Collections.Generic;
namespace MongoDbDemo
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public int CusId { get; set; }
        public DateTime Subtime { get; set; }
        public List<Order> Orders { get; set; }
        public string Demo { get; set; }
        public string Shit { get; set; }
        public string Demo2 { get; set; }

        public string Date
        {
            get;
            set;
        }

        public Customer()
        {
            Demo2 = DateTime.Now.ToString();
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Content { get; set; }
    }
}