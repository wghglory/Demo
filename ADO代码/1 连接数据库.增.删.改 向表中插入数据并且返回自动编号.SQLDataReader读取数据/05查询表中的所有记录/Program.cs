using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _05查询表中的所有记录
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 将TblPerson表中的数据输出到控制台
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from TblPerson";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //判断当前的reader是否读取到了数据
                        if (reader.HasRows)
                        {

                            int autoIdIndex = reader.GetOrdinal("autoId");
                            int unameIndex = reader.GetOrdinal("uname");
                            int uageIndex = reader.GetOrdinal("uage");
                            int uheightIndex = reader.GetOrdinal("uheight");

                            //循环读取每一条数据
                            while (reader.Read())
                            {

                                #region 通过SqlDataReader的索引器和GetValue()方法获取列值
                                //通过reader获取行中列的方式一：
                                ////读取当前行中的每一列的数据
                                //object obj1 = reader[0];
                                //object obj2 = reader[1];
                                //object obj3 = reader[2];
                                //object obj4 = reader[3];
                                //Console.WriteLine("{0}\t{1}\t{2}\t{3}", obj1, obj2, obj3, obj4);
                                //通过reader的所引起可以使用列索引，也可以使用列名。reader["列名"];，但是强烈建议使用列索引，如果必须要使用列名，也要使用列索引。

                                ////通过reader获取行中列的方式二：
                                ////reader.GetValue(index)不支持列名。只支持列索引。
                                //object obj1 = reader.GetValue(0);
                                //object obj2 = reader.GetValue(1);

                                ////this.GetOrdinal(name));根据列名获取列的索引。

                                #endregion

                                #region 通过reader获取列值的时候，使用强类型

                                ////autoId, uname, uage, uheight
                                ////当使用强类型的时候，如果数据库中的值为null,则报错。
                                ////避免方式：判断是否为null即可。
                                //int autoId = reader.GetInt32(0);
                                //string name = reader.GetString(1);

                                ////int?表示可空值类型。float?
                                //int? uage = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);

                                //int? height = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3);



                                //Console.WriteLine("{0}\t{1}\t{2}\t{3}", autoId, name, uage, height);
                                #endregion

                                #region 通过列名来获取列的值

                                Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetInt32(uheightIndex), reader.GetString(unameIndex), reader.GetInt32(uageIndex), reader.GetInt32(uheightIndex));
                                #endregion

                            }
                        }
                    }

                    //reader.Close();
                    //reader.Dispose();
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
            #endregion
        }
    }
}
