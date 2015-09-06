using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBLL;

namespace WCFClient1
{
    public partial class Form1 : Form
    {
        UserInfoServiceClient client = new UserInfoServiceClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            UserInfo userInfo = client.GetUserInfo(this.textBox1.Text);
            MessageBox.Show(userInfo.UName+ " " +userInfo.Id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Show();
        }
    }
}
