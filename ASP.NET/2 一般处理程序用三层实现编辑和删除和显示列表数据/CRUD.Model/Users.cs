using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Model
{
    public class Users
    {
        public int AutoId { get; set; }
        public string LoginId { get; set; }
        public string LoginPwd { get; set; }
        public int ErrorCount { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
