using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _02使用事件实现登录控件
{
    public partial class UCLogin : UserControl
    {
        public UCLogin()
        {
            InitializeComponent();
        }

        public event ValidateEventDelegate LoginValidating;

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginValidating != null)
            {
                UserValidatingEventArgs eventObject = new UserValidatingEventArgs(txtUid.Text.Trim(), txtpwd.Text, false);

                LoginValidating(this, eventObject);
                if (eventObject.IsOk)
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

}
