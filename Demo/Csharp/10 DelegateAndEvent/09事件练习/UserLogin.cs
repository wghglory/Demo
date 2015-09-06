using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _09事件练习
{
    public partial class UserLogin : UserControl
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        //2. 定义事件
        public event Action<object, UserLoginEventArgs> UserLoginValidation;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //这里执行用户的校验
            if (UserLoginValidation != null)
            {
                //3.创建刚才写好的eventargs类
                UserLoginEventArgs eventObj = new UserLoginEventArgs();
                eventObj.IsOk = false;
                eventObj.Username = txtUsername.Text.Trim();
                eventObj.Password = txtPasssword.Text.Trim();
                UserLoginValidation(this, eventObj);  //4.调用event
                if(eventObj.IsOk)
                {
                    this.BackColor = Color.Green;
                }
                else
                {
                    this.BackColor = Color.Red; 
                }
            }
        }
    }

    //1. 写好eventargs类
    public class UserLoginEventArgs : EventArgs
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsOk { get; set; }
    }
}
