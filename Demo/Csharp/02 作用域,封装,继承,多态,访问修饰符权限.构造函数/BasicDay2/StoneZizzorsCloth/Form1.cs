using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoneZizzorsCloth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //石头
        private void button1_Click(object sender, EventArgs e)
        {
            //把sender显示类型转换为button

            //this

            Button btn = (Button)sender;
            if (btn != null)
            {
                UserPlayer u1 = new UserPlayer();
                int userFist = u1.ShowFist(btn.Text);
                lblUserInput.Text = u1.FistName;

                ComputerUser pc1 = new ComputerUser();
                int computerFist = pc1.ShowFist();
                lblComputerInput.Text = pc1.FistName;

                CaiPan cp = new CaiPan();
                lblResult.Text = cp.IsUserWin(userFist, computerFist);
            }

        }

        //DRY原则：Don't Repeat Yourself

        ////点击剪刀
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    UserPlayer u1 = new UserPlayer();
        //    int userFist = u1.ShowFist(button2.Text);
        //    lblUser.Text = u1.FistName;

        //    ComputerUser pc1 = new ComputerUser();
        //    int computerFist = pc1.ShowFist();
        //    lblComputer.Text = pc1.FistName;

        //    CaiPan cp = new CaiPan();
        //    lblResult.Text = cp.IsUserWin(userFist, computerFist);
        //}

        ////布
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    UserPlayer u1 = new UserPlayer();
        //    int userFist = u1.ShowFist(button3.Text);
        //    lblUser.Text = u1.FistName;

        //    ComputerUser pc1 = new ComputerUser();
        //    int computerFist = pc1.ShowFist();
        //    lblComputer.Text = pc1.FistName;

        //    CaiPan cp = new CaiPan();
        //    lblResult.Text = cp.IsUserWin(userFist, computerFist);

        //}

    }
}
