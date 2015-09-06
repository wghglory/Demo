using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01三层.Model;
using System.Data.SqlClient;
using Itcast.Cn;

namespace _01三层.DAL
{
    public class TblAreaDal
    {
        //select AreaId,AreaName from TblArea where AreaPid=@pid

        public List<TblArea> GetAreaByParentId(int areaPid)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "select AreaId,AreaName from TblArea where AreaPid=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@pid", areaPid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaId = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }

            return list;
        }


        //delete from TblArea where areaId=@aid
        //根据AreaId删除一条记录
        public int DeleteAreaByAreaId(int areaId)
        {
            string sql = "delete from TblArea where areaId=@aid";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@aid", areaId));
        }
    }
}
