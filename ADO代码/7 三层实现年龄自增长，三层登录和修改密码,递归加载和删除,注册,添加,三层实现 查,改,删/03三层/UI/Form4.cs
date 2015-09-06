using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _01三层.Model;
using _01三层.BLL;

namespace _01三层.UI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPwd1.Text != txtpwd2.Text)
            {
                MessageBox.Show("两次输入密码不一致！");
            }
            else
            {
                T_Seats model = new T_Seats();
                model.CC_LoginId = txtUid.Text.Trim();
                model.Password = txtpwd2.Text;
                model.UserName = txtUserName.Text;
                T_SeatsBll bll = new T_SeatsBll();
                int autoId;
                AddUserState state = bll.Add(model, out autoId);
                switch (state)
                {
                    case AddUserState.LoginIdExists:
                        MessageBox.Show("用户名存在！");
                        break;
                    case AddUserState.OK:
                        MessageBox.Show("注册成功！autoId是：" + autoId);
                        break;

                }
            }

        }
    }
}
