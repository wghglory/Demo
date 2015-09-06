using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08使用三层实现年龄长1岁.Model
{
    [Serializable()]
    public class T_Seat
    {
        public int CC_AutoId
        {
            get;
            set;
        }
        public string CC_LoginId
        {
            get;
            set;
        }
        public string CC_LoginPassword
        {
            get;
            set;
        }
        public string CC_UserName
        {
            get;
            set;
        }
        public int CC_ErrorTimes
        {
            get;
            set;
        }
        public DateTime? CC_LockDateTime
        {
            get;
            set;
        }
        public int? CC_TestInt
        {
            get;
            set;
        }
    }
}
