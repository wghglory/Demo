using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _08三连击触发事件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userControlButton1.TripleClick = () =>
            {
                MessageBox.Show("click 3 times by delegate!");
            };

            //用事件实现的3连击
            //事件不能用=赋值，只能用+=或-=来赋值。
            userControlEvent1.TripleClick += () =>
            {
                MessageBox.Show("click 3 times by event!");
            };
        }
    }
}
