using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _04操作班级表
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            int r = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("insert into TblClass values('{0}','{1}')", txtName.Text.Trim(), txtDesc.Text.Trim());

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    r = cmd.ExecuteNonQuery();
                    //con.Close();

                }
            }
            MessageBox.Show("成功插入" + r + "条数据");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            int r = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("update TblClass set tclassname='{0}',tclassDesc='{1}' where tclassid={2}", txtName.Text.Trim(), txtDesc.Text, txtId.Text.Trim());

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    r = cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("成功更新了" + r + "行。");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //删除
            //根据用户输入的Id来删除

            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            int r = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("delete from TblClass where tclassId={0}", txtDelete.Text.Trim());
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.StatementCompleted += new StatementCompletedEventHandler(cmd_StatementCompleted);
                    con.Open();
                    r = cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("成功删除了" + r + "行。");

        }

        void cmd_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            //输出每条sql语句执行所影响的行数。
            //throw new NotImplementedException();
        }

        private void txtDelete_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //显示表中的记录的条数
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            int r = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(constr))//???
                {
                    string sql = "select count(*) from TblClass";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        try
                        {
                            con.Open();
                            // r = (int)cmd.ExecuteScalar();

                            //===============
                            r = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        catch (Exception ex1)
                        {
                            Console.WriteLine("发生了异常：" + ex1.Message);
                        }
                        finally
                        {
                            con.Close();
                            con.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生了异常：" + ex.Message);
                //=====================
            }
            MessageBox.Show("表中有" + r + "条记录。");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //显示表中的记录的条数
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            int tclassId = -1;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("insert into TblClass output inserted.tclassId values('{0}','{1}')", txtName.Text, txtDesc.Text);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    tclassId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            MessageBox.Show("插入成功，主键Id为：" + tclassId);
        }
    }
}
