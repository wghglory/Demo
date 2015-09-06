using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _02Command对象StatementCompleted事件
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "insert into TblClass values('AAAAAAAAAAA','AAAAAAAAAAAAAAA级班级');delete from TblClass where tclassId in(6,7,9);update TblClass set tclassName='XXXXXX' where tclassId=19;";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.StatementCompleted += new System.Data.StatementCompletedEventHandler(cmd_StatementCompleted);
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    Console.WriteLine(r);
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }

        static void cmd_StatementCompleted(object sender, System.Data.StatementCompletedEventArgs e)
        {
            Console.WriteLine("本次操作影响了：{0}", e.RecordCount);
        }
    }
}
