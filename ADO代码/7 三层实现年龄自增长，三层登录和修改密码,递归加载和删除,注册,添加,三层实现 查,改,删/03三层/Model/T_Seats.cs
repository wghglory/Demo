using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01三层.Model
{
    public class T_Seats
    {
        public int AutoId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string CC_LoginId
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
