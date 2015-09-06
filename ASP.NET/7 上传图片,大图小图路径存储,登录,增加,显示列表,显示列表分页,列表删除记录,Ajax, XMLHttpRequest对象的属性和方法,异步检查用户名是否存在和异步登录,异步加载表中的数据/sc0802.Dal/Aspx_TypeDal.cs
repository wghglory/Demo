using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stu.Model;
using System.Data.SqlClient;
using Itcast.Cn;

namespace sc0802.Dal
{
    public class Aspx_TypeDal
    {
        public List<Aspx_Type> GetAllTypes()
        {
            List<Aspx_Type> list = new List<Aspx_Type>();
            string sql = "select * from Aspx_Type";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Aspx_Type model = new Aspx_Type();
                        model.TypeId = reader.GetInt32(0);
                        model.TypeName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
