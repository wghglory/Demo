using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BeiDream.Framework.Common
{
    public static class Tools
    {
         ///<summary>
         ///验证字符串是否有sql注入字段
         ///</summary>
         ///<param name="input"></param>
         ///<returns></returns>
        public static bool IsValidInput(object objInput)
        {
            try
            {
                if (Tools.IsNullOrEmpty(objInput))    //字段可为空,修改为返回TRUE
                    return true;
                else
                {
                    string input = objInput.ToString();
                    //替换单引号
                    input = input.Replace("'", "''").Trim();

                    //检测攻击性危险字符串
                    string testString = "and |or |exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
                    string[] testArray = testString.Split('|');
                    foreach (string testStr in testArray)
                    {
                        if (input.ToLower().IndexOf(testStr) != -1)
                        {
                            //检测到攻击字符串,清空传入的值
                            input = "";
                            return false;
                        }
                    }

                    //未检测到攻击字符串
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         ///<summary>
         ///判断对象是否为空，为空返回true
         ///</summary>
        /// <param name="data">要验证的对象</param>
        public static bool IsNullOrEmpty(object data)
        {
            //如果为null
            if (data == null)
            {
                return true;
            }

            //如果为""
            if (data.GetType() == typeof(String))
            {
                if (string.IsNullOrEmpty(data.ToString().Trim()))
                {
                    return true;
                }
            }

            //如果为DBNull
            if (data.GetType() == typeof(DBNull))
            {
                return true;
            }

            //不为空
            return false;
        }
        /// <summary>
        /// 强制转化为string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjToStr(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            if (obj.Equals(DBNull.Value))
            {
                return "";
            }
            return Convert.ToString(obj);
        }

        /// <summary>
        /// DataTable行列转置
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static DataTable GetNewDataTable(DataTable dt)
        {
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add("ColumnName", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtNew.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
            }
            foreach (DataColumn dc in dt.Columns)
            {
                DataRow drNew = dtNew.NewRow();
                drNew["ColumnName"] = dc.ColumnName;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drNew[i + 1] = dt.Rows[i][dc].ToString();
                }
                dtNew.Rows.Add(drNew);
            }
            return dtNew;
        }
    }
}
