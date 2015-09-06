using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06把表中的数据绑定到一个控件上
{
    //autoId, uname, uage, uheight
    public class Person
    {
        public Person()
        {

        }
        public int AutoId
        {
            get;
            set;
        }

        public string UName
        {
            get;
            set;
        }

        public int? Age
        {
            get;
            set;
        }
        public int? Height
        {
            get;
            set;
        }
    }
}
