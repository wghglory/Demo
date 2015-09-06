using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _02登录验证用户名是否存在以及密码是否正确
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool b = false;
            string msg = string.Empty;
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {

                //只有返回一行一列的数据时，才用ExecuteScalar()
                string sql = string.Format("select autoid,loginPwd from Users where loginId='{0}'", txtId.Text.Trim());
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                string pwd = reader.GetString(1);
                                if (txtPwd.Text == pwd)
                                {
                                    b = true;
                                    msg = "登录成功！";
                                    button2.Enabled = true;
                                }
                                else
                                {
                                    msg = "密码错误！";
                                }
                            }
                        }
                        else
                        {
                            msg = "用户名不存在！";
                        }
                    }
                }

            }

            if (b)
            {
                MessageBox.Show("ok，【消息】" + msg);
            }
            else
            {
                MessageBox.Show("failed,【消息】" + msg);
            }
        }
    }
}
