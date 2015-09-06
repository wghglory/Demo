using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _01通过存储过程实现增删改查
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //insert
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "usp_insertToPerson"; //这里不再是sql语句了，而是存储过程名称
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //===========告诉Command对象，现在执行的是存储过程
                    cmd.CommandType = CommandType.StoredProcedure;

                    //如果这个存储过程有参数，则还需要为该Command对象增加参数
                    cmd.Parameters.AddWithValue("@uname", "王杨武");
                    cmd.Parameters.AddWithValue("@uage", 21);
                    cmd.Parameters.AddWithValue("@uheight", 170);
                    con.Open();
                    n = (int)cmd.ExecuteScalar();

                }
            }
            MessageBox.Show("ok" + n);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "usp_deletePerson";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@autoId", 52);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("ok");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //更新
            //usp_updatePerson
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "usp_updatePerson";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@autoId", 51);
                    cmd.Parameters.AddWithValue("@uname", "杨鹏立1.0");
                    cmd.Parameters.AddWithValue("@uage", 23);
                    cmd.Parameters.AddWithValue("@uheight", 189);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //select
        private void button4_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "usp_selectAllPerson";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    //reader.GetDataTypeName();
                                    Console.Write(reader[i] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //调用分页存储过程并且获取输出参数
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "usp_getDataByPage";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    #region MyRegion
                    //cmd.Parameters.AddWithValue("@pageSize", 5);
                    //cmd.Parameters.AddWithValue("@pageIndex", 1);
                    //SqlParameter pageCount = new SqlParameter("@pageCount", SqlDbType.Int);
                    ////告诉ado.net当前参数是一个输出参数
                    //pageCount.Direction = ParameterDirection.Output;
                    #endregion

                    #region MyRegion

                    SqlParameter[] pms = new SqlParameter[] {
                    new SqlParameter("@pageSize",5),
                    new SqlParameter("@pageIndex",1),
                    new SqlParameter("@pageCount",SqlDbType.Int)
                    };
                    //设置最后一个参数是输出参数
                    pms[2].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddRange(pms);
                    #endregion

                    con.Open();
                    //cmd.ExecuteNonQuery();
                    //cmd.ExecuteScalar();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0]);
                            }
                        }
                    }
                    Console.WriteLine("==========================================");
                    //获取输出参数的返回值
                    Console.WriteLine(pms[2].Value);
                }
            }
        }
    }
}
