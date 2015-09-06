using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _03DataTable与DataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from Customers where CustomerId=@cid", constr))
            {
                //当使用DataAdapter的时候会自动生成Connection，Command与DataReader所以我们什么都不用作。
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@cid", "ALFKI"));
                //adapter.DeleteCommand
                adapter.Fill(dt);
            }

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataSet就是一个临时数据库，内存数据库

            //DataTable就是临时数据库中的一个表。 

            //1.手动创建一个数据库
            DataSet ds = new DataSet("School");
            //ds.DataSetName
            //2.手动创建一个表，把该表加到数据库中
            //这个表的名称叫Student
            DataTable dt = new DataTable("Student");
            //把dt加到ds中
            ds.Tables.Add(dt);

            //3.手动创建一些列，把该列加到表中
            DataColumn dc1 = new DataColumn("AutoId");
            dc1.AutoIncrement = true;
            dc1.AutoIncrementSeed = 1000;
            dc1.AutoIncrementStep = 1;

            dt.Columns.Add(dc1);
            //dt.Constraints.Add()

            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("age", typeof(int));

            //4.创建一些数据行。

            DataRow dr = dt.NewRow();
            dr[1] = "黄林";
            dr[2] = 18;

            DataRow dr1 = dt.NewRow();
            dr1[1] = "黄林1";
            dr1[2] = 19;

            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);

            dataGridView1.DataSource = dt;

        }
    }
}
