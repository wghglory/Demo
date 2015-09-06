using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ajax.CRUD.Model;
using System.Data.SqlClient;

namespace Ajax.CRUD.DAL
{
    public class TblAreaDal
    {
        /// <summary>
        /// 根据父id,获取子城市
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<TblArea> GetAreasByParentId(int pid)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "select * from TblArea where AreaPid=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@pid", pid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaId = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        model.AreaPId = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2);
                        list.Add(model);
                    }
                }
            }
            return list;
        }
    }
}
