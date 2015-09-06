using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace _04DataTable与DataSet
{
    class Program
    {
        static void Main(string[] args)
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

            //================手动遍历DataSet中的表与行=====================
            //1.遍历DataSet中的表
            foreach (DataTable dtItem in ds.Tables)
            {
                Console.WriteLine("表名：{0}", dtItem.TableName);
                //循环该表中的每一行
                foreach (DataRow drItem in dtItem.Rows)
                {
                    //循环每一列
                    for (int i = 0; i < dtItem.Columns.Count; i++)
                    {
                        Console.Write("  {0}  ", drItem[i]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
