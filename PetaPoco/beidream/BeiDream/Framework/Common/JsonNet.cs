using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BeiDream.Framework.Common
{
    /// <summary>
    /// 以Newtonsoft.Json的方式返回json数据
    /// </summary>
    public class JsonNet
    {
        public static JObject WriteJObjectResult(bool success, JObject errors)
        {
            JObject jo = new JObject { 
                new JProperty("success",success)
            };
            if (errors != null && errors.HasValues)
            {
                jo.Add(new JProperty("errors", errors));
            }
            return jo;
        }

        /// <summary>
        /// 将前台的验证信息组装成extjs的错误信息对象
        /// </summary>
        /// <param name="ModelState">前台的验证信息对象</param>
        /// <param name="errors">extjs错误信息对象</param>
        public static void ModelStateToJObject(ModelStateDictionary ModelState, JObject errors)
        {
            foreach (var c in ModelState.Keys)
            {
                if (!ModelState.IsValidField(c))
                {
                    string errStr = "";
                    foreach (var err in ModelState[c].Errors)
                    {
                        errStr += err.ErrorMessage + "<br/>";
                    }
                    errors.Add(new JProperty(c, errStr));
                }
            }
        }

        public static JObject WriteJObjectResult(bool success, int total, string message, JArray data)
        {
            return new JObject { 
                new JProperty("success",success),
                new JProperty("total",total),
                new JProperty("Msg",message),
                new JProperty("data",data)
            };
        }

        public static string ProcessSorterString(string[] fields, string sortinfo, string defaultSort)
        {
            if (string.IsNullOrEmpty(sortinfo)) return defaultSort;
            JArray ja = JArray.Parse(sortinfo);
            string result = "";
            foreach (JObject c in ja)
            {
                string field = (string)c["property"];
                if (fields.Contains(field))
                {
                    result += string.Format("it.{0} {1},", field, (string)c["direction"] == "ASC" ? "" : "DESC");
                }
            }
            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }
            else
            {
                result = defaultSort;
            }
            return result;
        }
    }
}