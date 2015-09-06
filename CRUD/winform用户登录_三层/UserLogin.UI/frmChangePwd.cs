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
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UserLoginBll bll = new UserLoginBll();
            switch (bll.ChangePassword(txtOldPwd.Text, txtNewPwd1.Text, txtNewPwd2.Text))
            {
                case UserLoginBll.ChangePasswordResult.newPasswordDissimilarity:
                    MessageBox.Show("两次密码输入不一致");
                    break;
                case UserLoginBll.ChangePasswordResult.oldPasswordError:
                    MessageBox.Show("旧密码不正确");
                    break;
                case UserLoginBll.ChangePasswordResult.Succeed:
                    MessageBox.Show("修改成功");
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                default:
                    break;
            }
        }
    }
}
