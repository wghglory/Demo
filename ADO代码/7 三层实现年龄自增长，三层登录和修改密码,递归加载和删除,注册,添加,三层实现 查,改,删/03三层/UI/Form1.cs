using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _01三层.BLL;

namespace _01三层.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //校验登录
            //1.采集数据
            string loginId = txtLoginId.Text.Trim();
            string pwd = txtPwd.Text;
            T_SeatsBll bll = new T_SeatsBll();
            string userName;
            int autoId;
            LoginResult result = bll.CheckUserLogin(loginId, pwd, out userName, out autoId);
            switch (result)
            {
                case LoginResult.UserNotExists:
                    MessageBox.Show("用户名不存在！");
                    break;
                case LoginResult.ErrorPassword:
                    MessageBox.Show("密码错误！");
                    break;
                case LoginResult.OK:
                    //成功！
                    label3.Text = userName;
                    GlobalHelper._autoId = autoId;
                    button2.Enabled = true;
                    MessageBox.Show("登录成功！");
                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
