using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scripts.Model;
using System.Data.SqlClient;
using Itcast.Cn;

namespace Scripts.DAL
{
    public partial class T_ScriptsDal
    {
        public List<T_Scripts> GetScriptsByParentId(int pid)
        {
            List<T_Scripts> list = new List<T_Scripts>();
            string sql = "select ScriptId,ScriptTitle from T_Scripts where ScriptParentId=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@pid", pid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T_Scripts model = new T_Scripts();
                        model.ScriptId = reader.GetInt32(0);
                        model.ScriptTitle = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        public object GetScriptMessageByScriptId(int sid)
        {
            string sql = "select ScriptMsg from T_Scripts where ScriptId=@sid";
            return SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, new SqlParameter("@sid", sid));
        }

        public int AddScripts(T_Scripts model)
        {
            string sql = "insert into T_Scripts values(@title,@msg,@pid)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@title",model.ScriptTitle),
            new SqlParameter("@msg",model.ScriptMsg),
            new SqlParameter("@pid",model.ScriptParentId)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }

        public int DeleteByScriptId(int sid)
        {
            string sql = "delete from T_Scripts where scriptId=@sid";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@sid", sid));
        }

        public int UpdateScript(T_Scripts model)
        {
            string sql = "update T_Scripts set ScriptTitle=@title,ScriptMsg=@msg where ScriptId=@sid";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@title",model.ScriptTitle),
            new SqlParameter("@msg",model.ScriptMsg),
            new SqlParameter("@sid",model.ScriptId)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
        }
    }
}
