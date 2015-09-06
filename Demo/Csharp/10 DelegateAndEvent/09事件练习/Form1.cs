using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _09事件练习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //6.注册事件
            userLogin1.UserLoginValidation += new Action<object, UserLoginEventArgs>(ValidateUser);
        }

        // 5.写好自定义的方法
        void ValidateUser(object sender, UserLoginEventArgs e)
        {
            //要获取用户输入的内容，然后校验。
            if (e.Username == "admin" && e.Password == "8888")
            {
                e.IsOk = true;
            }
        }

    }


}
