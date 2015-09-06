using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace _06把表中的数据绑定到一个控件上
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> list = new List<Person>();
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from TblPerson";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //需要先把数据加到一个集合中
                                Person model = new Person();
                                model.AutoId = reader.GetInt32(0);
                                model.UName = reader.GetString(1);
                                model.Age = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                                model.Height = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);
                                list.Add(model);
                            }
                        }
                    }
                }
            }

            dataGridView1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource = new int[] { 1, 2, 3, 4, 5 };
            // this.dataGridView1.DataSource = new ArrayList() { "a", "b", "c" };

            this.dataGridView1.DataSource = "aaaaaaa";
        }
    }
}
