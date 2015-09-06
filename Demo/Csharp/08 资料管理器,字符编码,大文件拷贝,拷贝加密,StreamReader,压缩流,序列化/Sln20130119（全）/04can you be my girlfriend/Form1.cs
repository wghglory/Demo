using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _04can_you_be_my_girlfriend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "当我女朋友是可以还是没问题";  
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("来，让小杜同学抱一个");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("来让小杜同学亲一个");
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            int maxHeight = this.ClientSize.Height - button3.Height;
            int maxWidth = this.ClientSize.Width - button3.Width;
            Random r = new Random();
            int x = r.Next(0,maxWidth+1);
            int y = r.Next(0,maxHeight);
            button3.Location = new Point(x,y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你不是我的菜");
        }
    }
}
