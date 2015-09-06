using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.Framework.Common
{
    public class SqlTranslatorHelper
    {
        #region Select
        /// <summary>
        /// 获取查询的Sql语句
        /// </summary>
        /// <param name="Model">条件参数模型</param>
        /// <param name="selectFields">查询的字段集合。eg：id,name</param>
        /// <param name="Table">待查询表名</param>
        /// <returns></returns>
        public static string GetSelectSql(FilterGroup Model, string selectFields, string Table)
        {
            string[] str = selectFields.Split(',');
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (selectFields == "")
                strSql.Append("*");
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    strSql.Append(str[i]);
                    if (i != str.Length - 1)
                        strSql.Append(",");
                }
            }
            strSql.Append(" FROM " + Table);
            if (Model != null)           //model为null，则没有where条件语句
            {
                string commandText = " where " + FilterHelper.GetFilterTanslate(Model);
                strSql.Append(commandText);
            }
            return strSql.ToString();
        }
        #endregion

        #region Delete
        /// <summary>
        ///  获取删除的Sql语句
        /// </summary>
        /// <param name="Model">条件参数模型</param>
        /// <returns>删除的Sql语句</returns>
        public static string GetDeleteSql(FilterGroup Model, string Table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + Table);
            string commandText = " where " + FilterHelper.GetFilterTanslate(Model);
            strSql.Append(commandText);
            return strSql.ToString();
        }
        #endregion

        #region Update
        /// <summary>
        ///  获取修改的Sql语句
        /// </summary>
        /// <param name="Model">条件参数模型</param>
        /// <returns>修改的Sql语句</returns>
        public static string GetUpdateSql(FilterGroup Model, List<FilterParam> list, string Table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + Table + " set ");
            string UpdatefieldsText = FilterHelper.GetFilterTanslate(list);
            strSql.Append(UpdatefieldsText);
            string commandText = " where " + FilterHelper.GetFilterTanslate(Model);
            strSql.Append(commandText);
            return strSql.ToString();
        }
        #endregion

        #region Insert
        public static string GetInsertSql(List<FilterParam> list, string Table)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + Table + "(");
            for (int i = 0; i < list.Count; i++)
            {
                strSql.Append(list[i].Name);
                if (i != list.Count - 1)
                    strSql.Append(",");
            }
            strSql.Append(") values (");
            for (int i = 0; i < list.Count; i++)
            {
                strSql.Append("'" + list[i].Value + "'");
                if (i != list.Count - 1)
                    strSql.Append(",");
            }
            strSql.Append(")");
            return strSql.ToString();
        } 
        #endregion
    }
}
