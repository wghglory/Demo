using System;
using System.Collections.Generic;
using System.Text;

namespace Stu.Model
{
    [Serializable()]
    public class TSeats
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
