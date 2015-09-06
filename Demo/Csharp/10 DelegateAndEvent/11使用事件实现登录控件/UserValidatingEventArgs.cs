using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02使用事件实现登录控件
{
    public class UserValidatingEventArgs : EventArgs
    {
        public UserValidatingEventArgs(string uid, string pwd, bool isok)
        {
            this.Uid = uid;
            this.Password = pwd;
            this.IsOk = isok;
        }
        public string Uid
        {
            get;
            set;
        }

        public string Password { get; set; }

        public bool IsOk { get; set; }
    }
}
