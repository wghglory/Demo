using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _01Ado.net入门
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 通过ado.net连接数据库

            ////1.编写连接字符串
            ////连接字符串的作用就是告诉连接对象，要连接哪个服务器的哪个数据库，用户名是多少密码是多少
            ////Data Source="";指定 服务器Ip(计算机名)   或者  服务器\实例名
            ////string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;User Id=sa;Password=sa";

            ////Data Source=steve-pc;Initial Catalog=Itcast2013;Integrated Security=True

            ////使用windows身份验证方式
            //string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=true";

            ////"server=.;database=itcast2013;uid=sa;pwd=sa"
            ////2.创建连接对象
            //SqlConnection con = new SqlConnection(constr/*这里需要一个连接字符串*/);

            ////3.打开连接
            //con.Open();
            //Console.WriteLine("使用连接对象");


            ////4.关闭连接
            //con.Close();

            ////5.释放资源
            //con.Dispose();
            //Console.WriteLine("连接关闭，并释放资源");
            //Console.WriteLine("ok");
            //Console.ReadKey();


            //string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    con.Open();
            //    //con.Close();
            //}

            //Data Source=DENGJIANJUN;Initial Catalog=GzItcast2;User ID=sa


            //1.数据库连接不能重复打开。
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                Console.WriteLine("第一次打开数据库连接。");
                ////数据库连接不能重复打开。
                //con.Open();
                //Console.WriteLine("第二次打开数据库连接。");

                //判断数据库连接是否已经打开
                if (con.State==System.Data.ConnectionState.Closed)
                {
                    con.Open();//如果当前数据库连接已经关闭，则再次打开。
                }
                //con.Close();

                //con.Close();
                //con.Close();
                //con.Close();
                //con.Close();
                //con.Close();
                //con.Close();
                //con.Close();
            }




            #endregion
        }
    }
}
