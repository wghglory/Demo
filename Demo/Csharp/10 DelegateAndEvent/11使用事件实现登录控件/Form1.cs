using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _02使用事件实现登录控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucLogin1.LoginValidating += new ValidateEventDelegate(ucLogin1_LoginValidating);
        }

        void ucLogin1_LoginValidating(object sender, UserValidatingEventArgs e)
        {
            if (e.Uid == "amdin" && e.Password == "8888")
            {
                e.IsOk = true;
            }
            else
            {
                e.IsOk = false;
            }
        }

        private void ucLogin1_Load(object sender, EventArgs e)
        {

        }
    }
}
