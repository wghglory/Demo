using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02三层中的多条件搜索实现方式
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
