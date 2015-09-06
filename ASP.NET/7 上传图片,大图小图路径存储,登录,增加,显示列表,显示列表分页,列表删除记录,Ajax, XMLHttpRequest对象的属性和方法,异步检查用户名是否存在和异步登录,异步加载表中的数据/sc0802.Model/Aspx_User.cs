using System;
using System.Collections.Generic;
using System.Text;

namespace Stu.Model
{
    [Serializable()]
    public class Aspx_User
    {
        public int AutoId
        {
            get;
            set;
        }
        public string LoginId
        {
            get;
            set;
        }
        public string LoginPwd
        {
            get;
            set;
        }
        public DateTime? LastLoginTime
        {
            get;
            set;
        }
        public string LoginIp
        {
            get;
            set;
        }
    }
}