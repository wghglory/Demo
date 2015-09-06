using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace _01通过ado.net连接SqlExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            //string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";

            //string constr = "Data Source=STEVE-PC\\SQLEXPRESS;Initial Catalog=itcast2013;Integrated Security=True";

            //string constr = @"Data Source=STEVE-PC\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

            ////STEVE-PC\SQLEXPRESS
            //string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    con.Open();
            //    Console.WriteLine("打开");
            //}
            //Console.WriteLine("关闭");
            //Console.ReadKey();
        }
    }
}
