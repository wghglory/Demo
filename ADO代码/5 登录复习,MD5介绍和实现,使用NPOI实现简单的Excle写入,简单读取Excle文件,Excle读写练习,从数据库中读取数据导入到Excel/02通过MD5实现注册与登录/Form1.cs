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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //注册
        private void button1_Click(object sender, EventArgs e)
        {
            //
            string loginId = textBox1.Text.Trim();

            string pwd = textBox2.Text;//明文密码
            pwd = CommonHelper.GetMD5FromString(pwd);

            string name = textBox3.Text.Trim();

            //向数据库中插入一条记录
            string sql = "insert into T_Seats(CC_loginid,CC_loginpassword,CC_userName) values(@uid,@pwd,@name)";

            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",loginId),
            new SqlParameter("@pwd",pwd),
            new SqlParameter("@name",name)
            };

            int r = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pms);
            if (r > 0)
            {
                MessageBox.Show("注册成功！");
            }
            else
            {
                MessageBox.Show("注册失败！");
            }


        }

        //实现登录
        private void button2_Click(object sender, EventArgs e)
        {
            string uid = txtUid.Text.Trim();
            string pwd = txtPwd.Text;
            //在验证登录之前对密码进行md5处理
            pwd = CommonHelper.GetMD5FromString(pwd);

            string sql = "select count(*) from T_Seats where cc_loginId=@uid and cc_loginpassword=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",uid),
            new SqlParameter("@pwd",pwd)
            };

            int r = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pms);
            if (r > 0)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("failed");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = "123";
            MessageBox.Show(CommonHelper.GetSHA512FromString(msg));
        }
    }
}
