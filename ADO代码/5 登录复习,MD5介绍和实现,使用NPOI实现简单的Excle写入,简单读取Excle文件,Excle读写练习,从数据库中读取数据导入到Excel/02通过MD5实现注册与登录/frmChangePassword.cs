using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using _01通过ado.net实现简单登录;

namespace _02通过MD5实现注册与登录
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.验证用户两次输入的新密码是否一致
            if (txtPwd.Text != txtPwd1.Text)
            {
                //表示两次输入新密码不一致
                MessageBox.Show("两次输入新密码不一致，请重新输入");
            }
            else
            {
                //2.验证用户输入的旧密码是否正确
                //验证旧密码
                if (CheckOldPassword(CommonHelper.GetMD5FromString(txtOld.Text), GlobalHelper._autoId))
                {
                    //表示验证旧密码正确
                    //3.执行修改密码
                    int r = ChangePassword(CommonHelper.GetMD5FromString(txtPwd.Text), GlobalHelper._autoId);
                    MessageBox.Show("成功修改了" + r + "条数据。");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("旧密码不正确！");
                }



            }


        }

        //修改密码
        private int ChangePassword(string newpwd, int autoId)
        {
            string sql = "update T_Seats set cc_loginpassword=@pwd where cc_autoId=@autoId";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@pwd",newpwd),
            new SqlParameter("@autoId",autoId),
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
        }

        //验证旧密码是否正确
        private bool CheckOldPassword(string oldpwd, int autoId)
        {
            string sql = "select count(*) from T_Seats where cc_autoId=@autoId and cc_loginpassword=@old";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@autoId",autoId),
            new SqlParameter("@old",oldpwd),
            };
            return ((int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms)) > 0;
        }
    }
}
