//============================================================
//author:Guanghui Wang
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AjaxComment.Model;

namespace AjaxComment.DAL
{
    public partial class TblAreaDAL
    {

        public IEnumerable<TblArea> GetAreasByParentId(int pid)
        {
            var list = new List<TblArea>();
            string sql = "SELECT * FROM TblArea WHERE AreaPId = @pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@pid", pid)))
            {
                while (reader.Read())
                {
                    list.Add(ToModel(reader));
                }
            }
            return list;
        }

    }
}