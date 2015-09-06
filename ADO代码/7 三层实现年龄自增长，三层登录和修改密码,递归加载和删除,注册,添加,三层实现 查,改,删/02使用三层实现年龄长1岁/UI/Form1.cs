using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _08使用三层实现年龄长1岁.BLL;

namespace _08使用三层实现年龄长1岁.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyStudentBll bll = new MyStudentBll();
            int r = bll.AgeInc();
            MessageBox.Show("成功更新了" + r + "多条记录！！！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TSeatsBll bll = new TSeatsBll();
            if (bll.ValidUserLogin(txtUid.Text.Trim(), txtPwd.Text))
            {
                MessageBox.Show("登录成功！");
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TSeatsBll bll = new TSeatsBll();
            string userName;
            int autoId;
            LoginResult result = bll.CheckUserLogin(txtUid.Text.Trim(), txtPwd.Text, out userName, out autoId);
            switch (result)
            {
                case LoginResult.UserNotExists:
                    MessageBox.Show("用户名不存在！");
                    break;
                case LoginResult.ErrorPassword:
                    MessageBox.Show("密码错误！");
                    break;
                case LoginResult.Ok:
                    lblMsg.Text = "欢迎" + userName;
                    GlobalHelper._autoId = autoId;
                    button4.Enabled = true;
                    MessageBox.Show("登录成功！~");
                    break;
            }
        }
    }
}
