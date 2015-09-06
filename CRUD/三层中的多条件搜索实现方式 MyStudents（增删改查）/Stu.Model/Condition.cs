using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stu.Model
{
    public class Condition
    {
        /// <summary>
        /// 属性名或者数据库中的列名
        /// </summary>
        public string PropertyName
        {
            get;
            set;
        }

        //属性对应的值
        public object Value
        {
            get;
            set;
        }


        public Opt Operation
        {
            get;
            set;
        }



    }

    public enum Opt
    {
        Equal,
        NotEqual,
        GreaterThan,
        LessThan,
        Like
    }
}
