using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using System.Data.SqlClient;

namespace Stu.DAL
{
    public class MyClassDal
    {
        public List<MyClass> GetAllClasses()
        {
            List<MyClass> list = new List<MyClass>();
            string sql = "select * from MyClass";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyClass model = new MyClass();
                        model.ClassId = reader.GetInt32(0);
                        model.ClassName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
