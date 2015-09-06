using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _03窗体传值
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnForm1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(txtInput1.Text, PassVal);  //3.编写form2的构造函数把方法传递过去
            frm2.Show();
        }

        public void PassVal(string val)  //2.想要把这个方法传递给form2
        {
            this.txtInput1.Text = val;
        }
    }

    public delegate void PassMethodDelegate(string input);  //1.定义delegate
}
