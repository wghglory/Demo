using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;

namespace _04Ado.net连接池
{
    class Program
    {
        static void Main(string[] args)
        {
            //默认情况下ado.net启用了连接池
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {

                //1.当第一次创建一个连接对象调用Open()操作的时候，该连接对象会向数据库发出一个连接请求，并且进行连接。

                //2.当调用该对象的Close()方法是，并没有真的关闭该连接对象，而是将该连接对象放入了“连接池”中。
                //3.当下次再创建一个连接对象的时候，如果该链接对象所使用的连接字符串与池中现有的连接对象所使用的连接字符串【一模一样】（注：大小写，空格等什么都必须一样），这时，当调用con.Open()方法时，并不会真正的再次创建一个连接，而是会使用“池”中现有的连接对象。

                //4.如果再次创建的连接对象所使用的连接字符串与池中的对象的连接字符串不一样，此时，则会创建一个新的连接。

                //5.特别注意：只有当调用了连接对象的Close()方法后，当前连接才会放入到池中。
                //6.如果当创建一个新的连接对象时，即便连接字符串和上一次创建的连接对象一模一样，但是如果上一次的连接对象并没有Close()（即：并没有放入到池中，则本次操作依然会创建一个新的连接。）

                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    con.Close();
                }
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine("ok");
            Console.ReadKey();

            SqlConnectionStringBuilder constrBuilder = new SqlConnectionStringBuilder();
            



            ////禁用连接池
            //string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True;Pooling=false";
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    using (SqlConnection con = new SqlConnection(constr))
            //    {
            //        con.Open();
            //        con.Close();
            //    }
            //}
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedMilliseconds);
            //Console.WriteLine("ok");
            //Console.ReadKey();
        }
    }
}
