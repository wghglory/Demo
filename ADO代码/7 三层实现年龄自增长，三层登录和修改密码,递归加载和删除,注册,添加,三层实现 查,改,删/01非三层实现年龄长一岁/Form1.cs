using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Itcast.Cn;

namespace _07非三层实现年龄长一岁
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update MyStudent set fage=fage+1";
            SqlHelper.ExecuteNonQuery(sql, CommandType.Text);
            MessageBox.Show("ok");
        }
    }
}
