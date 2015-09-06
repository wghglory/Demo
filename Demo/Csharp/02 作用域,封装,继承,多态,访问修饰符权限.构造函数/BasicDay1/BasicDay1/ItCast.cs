using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicDay1
{
    class ItCast
    {

        private string[] _names = { "苏坤", "蒋坤", "杨中科", "马伦", "赵剑宇" };

        public int Count
        {
            get { return _names.Length; }
        }

        //索引器其实就是一个属性，是一个非常特殊的属性，常规情况下索引器其实都是一个名字叫Item的属性
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= _names.Length)
                {
                    throw new ArgumentException();
                }
                return _names[index];
            }
            set
            {
                _names[index] = value;
            }
        }

        public string this[string username]
        {
            get
            {
                return "";
            }
            set
            {

            }
        }

        //wrong!!!!!!!!!!!!!!
        //public string Item
        //{
        //    get;
        //    set;
        //}
    }
}
