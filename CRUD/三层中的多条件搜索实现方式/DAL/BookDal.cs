﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _02三层中的多条件搜索实现方式.DAL
{
    class BookDal
    {
        public List<string> Search(List<Condition> list)
        {
            StringBuilder sbSql = new StringBuilder("select * from books ");
            List<string> wheres = new List<string>();
            List<SqlParameter> pms = new List<SqlParameter>();
            foreach (Condition item in list)
            {
                //假设 item.PropertyName中存储的就是数据库中的列名
                //item.PropertyName
                StringBuilder sbWhere = new StringBuilder();
                sbWhere.AppendFormat(" {0} ", item.PropertyName);
                SqlParameter p1 = new SqlParameter("@" + item.PropertyName, item.Value);
                switch (item.Operation)
                {
                    case Opt.Equal:
                        sbWhere.Append(" = ");
                        break;
                    case Opt.NotEqual:
                        sbWhere.Append(" <> ");
                        break;
                    case Opt.GreaterThan:
                        sbWhere.Append(" > ");
                        break;
                    case Opt.LessThan:
                        sbWhere.Append(" < ");
                        break;
                    case Opt.Like:
                        sbWhere.Append(" like ");
                        p1.Value = "%" + p1.Value + "%";
                        break;
                }

                pms.Add(p1);
                //拼接对应的列的值
                sbWhere.AppendFormat(" @{0} ", item.PropertyName);
                wheres.Add(sbWhere.ToString());
            }
            //现在wheres集合中存储的就是每个条件。
            // wheres
            if (wheres.Count > 0)
            {
                sbSql.Append(" where " + string.Join(" and ", wheres.ToArray()));
                //SqlHelper.ExecuteReader(sbSql.ToString(),pms.ToArray());
            }
            //输出sql语句
            Console.WriteLine(sbSql.ToString());

            //循环输出参数名与参数值
            foreach (SqlParameter pam in pms)
            {
                Console.WriteLine(pam.ParameterName + "   " + pam.Value.ToString());
            }

            return null;
        }

    }
}
