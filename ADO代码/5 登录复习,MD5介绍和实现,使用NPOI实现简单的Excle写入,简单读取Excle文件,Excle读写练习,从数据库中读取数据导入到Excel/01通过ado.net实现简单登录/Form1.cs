using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _01通过ado.net实现简单登录
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from users where loginId=@id and loginpwd=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@id",textBox1.Text.Trim()),
            new SqlParameter("@pwd",textBox2.Text)
            };

            int r = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
            if (r > 0)
            {
                MessageBox.Show("登录成功！");
            }
            else
            {
                MessageBox.Show("失败！");
            }

        }
    }
}
