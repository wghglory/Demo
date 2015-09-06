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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            T_SeatsBll bll = new T_SeatsBll();
            ChangePasswordResult result = bll.ChangePassword(GlobalHelper._autoId, txtOld.Text, txtNew1.Text, txtNew2.Text);
            switch (result)
            {
                case ChangePasswordResult.DiffNewPwd:
                    MessageBox.Show("新密码不一致！");
                    break;
                case ChangePasswordResult.ErrorOldPwd:
                    MessageBox.Show("旧密码错误！！");
                    break;
                case ChangePasswordResult.OK:
                    MessageBox.Show("修改成功！");
                    break;
            }
        }
    }
}
