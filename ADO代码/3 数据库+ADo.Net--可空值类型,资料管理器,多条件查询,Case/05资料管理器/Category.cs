using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05资料管理器
{
    public class Category
    {
        public Category()
        {

        }
        public Category(int id, string name)
        {
            this.TId = id;
            this.TName = name;
        }
        public int TId { get; set; }

        public string TName { get; set; }
    }
}
