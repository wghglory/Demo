using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Util.Validations;

namespace BeiDream.UI
{
    public static class JsonExtension
    {
        public static JsonResultExtension ExtjsJsonResult(this Controller c, bool IsSuccess, object data = null, List<string> msg = null)
        {
            JsonResultExtension result = new JsonResultExtension();
            result.ExtjsUISerialize = true;
            string msgs = "";
            if(msg!=null)
            {
                foreach (var message in msg)
                {
                    msgs += message + "<br/>";
                }
            }
            result.msg = msgs;
            result.success = IsSuccess;
            result.data = data;
            return result;
        }
        public static JsonResultExtension ExtjsGridJsonResult(this Controller c, object data,long total)
        {
            dynamic errors = new System.Dynamic.ExpandoObject(); 
            JsonResultExtension result = new JsonResultExtension();
            result.ExtjsUISerialize = true;
            result.success = true;
            result.total = total;
            result.data = data;
            return result;
        }
        public static JsonResultExtension ExtjsFromJsonResult(this Controller c, bool IsSuccess, ValidationResultCollection ValidationResultCollection = null, List<string> msg = null)
        {
            JsonResultExtension result = new JsonResultExtension();
            if (ValidationResultCollection != null && ValidationResultCollection.Count != 0)
            {
                Dictionary<string, string> Dictionary = new Dictionary<string, string>();
                foreach (var item in ValidationResultCollection)
                {
                    Dictionary.Add(item.MemberNames.First(), item.ErrorMessage);
                }
                result.errors = Dictionary;
            }
            else
            {
                result.errors = null;
            }
            result.ExtjsUISerialize = true;
            result.success = IsSuccess;
            string msgs = "";
            if (msg != null)
            {
                foreach (var message in msg)
                {
                    msgs += message + "<br/>";
                }
            }
            result.msg = msgs;
            return result;
        }
    }
}