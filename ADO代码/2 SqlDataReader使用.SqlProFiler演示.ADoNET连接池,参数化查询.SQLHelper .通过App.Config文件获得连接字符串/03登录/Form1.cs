using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _03登录
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region 通过拼接Sql语句实现验证用户登录

            ////连接数据库判断用户登录是否成功
            //string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            //int r = 0;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string sql = string.Format("select count(*) from users where loginId='{0}' and loginPwd='{1}'", txtId.Text.Trim(), txtPwd.Text);
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        con.Open();
            //        r = Convert.ToInt32(cmd.ExecuteScalar());
            //    }

            //}
            //if (r > 0)
            //{
            //    MessageBox.Show("登录成功！");
            //}
            //else
            //{
            //    MessageBox.Show("登录失败！");
            //}
            #endregion

            #region 通过带参数的Sql语句实现登录验证

            int r = 0;
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select count(*) from users where loginId=@uid and loginPwd=@pwd";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //在执行之前要做一些操作
                    //为Command对象添加参数
                    //SqlParameter puid = new SqlParameter("@uid", txtId.Text.Trim());
                    //cmd.Parameters.Add(puid);
                    //SqlParameter ppwd = new SqlParameter("@pwd", txtPwd.Text);
                    //cmd.Parameters.Add(ppwd);
                    cmd.Parameters.AddWithValue("@uid", txtId.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwd", txtPwd.Text);
                    //cmd.Parameters.AddRange(
                    //con.Open();
                    r = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            if (r > 0)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("failed");
            }
            #endregion

        }
    }
}
