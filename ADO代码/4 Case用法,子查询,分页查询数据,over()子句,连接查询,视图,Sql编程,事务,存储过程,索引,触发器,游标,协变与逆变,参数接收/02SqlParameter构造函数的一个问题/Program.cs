using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _02SqlParameter构造函数的一个问题
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "insert into TblPerson values(@name,@age,@height)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlParameter[] pms = new SqlParameter[] { 
                    new SqlParameter("@name","张怀晶"),
                    new SqlParameter("@age",(object)0),
                    new SqlParameter("@height",160)
                    };
                    cmd.Parameters.AddRange(pms);
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    Console.WriteLine(r);
                }
            }
            Console.ReadKey();
        }

    }
}
