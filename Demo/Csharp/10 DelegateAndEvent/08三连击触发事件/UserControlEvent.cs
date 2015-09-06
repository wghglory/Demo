using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _08三连击触发事件
{
    public partial class UserControlEvent : UserControl
    {
        public UserControlEvent()
        {
            InitializeComponent();
        }

        int count = 0;
        public event Action TripleClick;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            if (count >= 3)
            {
                //MessageBox.Show("usercontrol clicked 3 times");  //这样控件写死了。。。
                if (TripleClick != null)
                {
                    TripleClick();
                }
                count = 0;
            }
        }
    }
}
