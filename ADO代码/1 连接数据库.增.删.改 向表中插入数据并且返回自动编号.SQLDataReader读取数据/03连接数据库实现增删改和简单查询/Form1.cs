using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _03连接数据库实现增删改和简单查询
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //向TblPerson表插入一条记录
            //1.连接数据库

            //连接字符串
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";

            //创建连接对象
            using (SqlConnection con = new SqlConnection(constr))
            {
                //打开数据连接
                //如果con对象是其他地方传递过来的一个对象，则在打开之前最好做判断con.State
                con.Open();

                //向表中插入一条数据
                //先构建一个sql语句
                string sql = string.Format("insert into TblPerson(uname, uage, uheight) values('{0}',{1},{2})", "黄林", 18, 175);

                //执行sql语句需要一个"命令对象"
                //创建一个命令对象
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    //这里要执行insert语句所以用ExecuteNonQuery()方法。
                    //通过调用该方法就会将insert语句交给数据库引擎来执行
                    //这个方法的返回值是一个int类型，表示当前Sql语句执行后所影响的行数。
                    int r = cmd.ExecuteNonQuery();
                    Console.WriteLine("成功插入了{0}", r);
                    

                    #region SqlCommand对象常用的3个方法。

                    //执行sql语句
                    //cmd.ExecuteNonQuery() //当执行insert,delete,update语句时，一般使用该方法


                    //当执行返回单个值的sql语句时使用该方法。
                    //cmd.ExecuteScalar()


                    //当执行Sql语句返回多行多列时，一般使用该方法。
                    //cmd.ExecuteReader()
                    #endregion

                }


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //把Id是41的删除
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("delete from TblPerson where autoId={0}", 41);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //尽可能晚的打开连接
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    //使用完毕后尽可能早的关闭连接
                    con.Close();
                    Console.WriteLine("删除了{0}行。", r);
                }
            }
            MessageBox.Show("ok");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //更新操作
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("update TblPerson set uname='{0}' where autoId={1}", "许正龙", 40);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("更新了" + r + "行。");
                }
            }
        }
    }
}
