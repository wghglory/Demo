using AjaxComment.BLL;
using AjaxComment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AjaxComment.UI.Ajax_JS
{
    /// <summary>
    /// Summary description for GetAllComment
    /// </summary>
    public class GetAllComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.请求数据。
            T_MsgBLL bll = new T_MsgBLL();
            IEnumerable<T_Msg> models = bll.GetAll();

            //2.把数据序列化成一个json格式的字符串返回给用户
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(models);
            context.Response.Write(jsonString);

        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}