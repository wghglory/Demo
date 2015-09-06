using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace _05数据导入导出到文本文件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //把TblArea中的数据导出到文本文件
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from TblArea";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            //创建一个StreamWriter用来写数据
                            using (StreamWriter sw = new StreamWriter("area.txt", false, Encoding.UTF8))
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string city = reader.GetString(1);
                                    int pid = reader.GetInt32(2);
                                    sw.WriteLine(string.Format("{0},{1},{2}", id, city, pid));
                                }
                                this.Text = "导出成功！";
                            }


                        }
                        else
                        {
                            this.Text = "没有查询到任何数据";
                        }
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //导入
            //1.读取文本文件
            using (StreamReader reader = new StreamReader("area.txt"))
            {
                string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = "insert into NewArea1 values(@name,@pid)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        //建议每次都设置设置参数的数据类型，更保险。
                        SqlParameter pname = new SqlParameter("@name", SqlDbType.NVarChar, 50);
                        SqlParameter pid = new SqlParameter("@pid", SqlDbType.Int);

                        cmd.Parameters.Add(pname);
                        cmd.Parameters.Add(pid);

                        con.Open();
                        string line;
                        //循环读取每一行
                        while ((line = reader.ReadLine()) != null)
                        {
                            //Console.WriteLine(line);
                            //把每行数据按照","分割，提取每一列的信息
                            string[] columns = line.Split(',');
                            cmd.Parameters[0].Value = columns[1];
                            cmd.Parameters[1].Value = columns[2];

                            cmd.ExecuteNonQuery();
                        }
                    }


                }


            }
            MessageBox.Show("导入完毕！");

        }
    }
}
