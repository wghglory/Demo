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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string n, PassMethodDelegate passval)   //3.这里有哪个delegate接受传来的方法
            : this()
        {
            txt2.Text = n;
            _passmethod = passval;   //4.把方法存储到这里定义的delegate字段
        }

        private PassMethodDelegate _passmethod;   //4.定义delegate字段

        private void btnForm2_Click(object sender, EventArgs e)
        {
            _passmethod(txt2.Text);   //5.调用delegate中的方法
            this.Close(); //关闭窗体2
        }
    }
}
