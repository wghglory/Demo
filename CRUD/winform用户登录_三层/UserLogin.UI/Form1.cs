using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UersLogin.BLL;

namespace UserLogin.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLoginBll bll = new UserLoginBll();
            switch (bll.GetLoginInfo(txtUserName.Text, txtPwd.Text))
            {
                case UserLoginBll.LoginResult.LoginNonExistent:
                    MessageBox.Show("用户不存在");
                    break;
                case UserLoginBll.LoginResult.PasswordError:
                    MessageBox.Show("密码错误");
                    break;
                case UserLoginBll.LoginResult.Succeed:
                    MessageBox.Show("登录成功");
                    btnChangePwd.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            frmChangePwd fm = new frmChangePwd();
            fm.ShowDialog();
        }
    }
}
