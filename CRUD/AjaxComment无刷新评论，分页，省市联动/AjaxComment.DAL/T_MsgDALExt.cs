using AjaxComment.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AjaxComment.DAL
{
    public partial class T_MsgDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagesize">每页的记录条数</param>
        /// <param name="pageindex">当前要查看第几页</param>
        /// <param name="recordcount">表中总共的记录条数</param>
        /// <param name="pagecount">一共可以分多少页</param>
        /// <returns></returns>
        public IEnumerable<T_Msg> GetDataByPage(int pagesize, int pageindex, out int recordcount, out int pagecount)
        {
            var list = new List<T_Msg>();
            string sp = "usp_getMsgByPage";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@pagesize",pagesize),
            new SqlParameter("@pageIndex",pageindex),
            new SqlParameter("@recordCount",System.Data.SqlDbType.Int),
            new SqlParameter("@pagecount",System.Data.SqlDbType.Int)
            };
            pms[2].Direction = System.Data.ParameterDirection.Output;
            pms[3].Direction = System.Data.ParameterDirection.Output;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sp, CommandType.StoredProcedure, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T_Msg t_Msg = new T_Msg();

                        t_Msg.Id = reader.GetInt32(0);
                        t_Msg.Title = reader.GetString(1);
                        t_Msg.Message = reader.GetString(2);
                        t_Msg.NickName = reader.GetString(3);
                        t_Msg.IsAnonymous = reader.GetBoolean(4);
                        t_Msg.IPAddress = reader.GetString(5);
                        t_Msg.PostDate = reader.GetDateTime(6);
                        list.Add(t_Msg);
                    }
                }
            }
            recordcount = Convert.ToInt32(pms[2].Value);
            pagecount = Convert.ToInt32(pms[3].Value);
            return list;
        }



    }
}
