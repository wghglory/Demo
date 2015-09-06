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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //登录
        private void button2_Click(object sender, EventArgs e)
        {
            //
            string uid = txtUid.Text.Trim();
            string pwd = txtPwd.Text;
            //处理，把密码转成md5格式
            pwd = CommonHelper.GetMD5FromString(pwd);

            //执行验证登录的操作、
            string sql = "select * from T_Seats where CC_LoginId=@uid and CC_LoginPassword=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",uid),
            new SqlParameter("@pwd",pwd)
            };

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    MessageBox.Show("登录成功！");
                    //如果登录成功则，获取当前登录用户的主键Id与真实姓名
                    if (reader.Read())
                    {
                        //CC_AutoId, CC_LoginId, CC_LoginPassword, CC_UserName, CC_ErrorTimes, CC_LockDateTime, CC_TestInt
                        GlobalHelper._autoId = reader.GetInt32(0);
                        GlobalHelper._userName = reader.GetString(3);
                        button1.Enabled = true;
                        this.label1.Text = "欢迎：" + GlobalHelper._userName;
                    }
                }
                else
                {
                    MessageBox.Show("登录失败！");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
        }
    }
}
