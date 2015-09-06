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
    /// Summary description for AddComment
    /// </summary>
    public class AddComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.获取用户提交过来的数据
            string title = context.Request["title"];
            string comment = context.Request["comment"];
            string nickName = context.Request["nickName"];

            if (title != null && comment != null  && nickName != null)
            {
                //2.把用户提交过来的数据插入到数据库中。
                T_MsgBLL bll = new T_MsgBLL();
                T_Msg model = new T_Msg();
                model.Title = title;
                model.Message = comment;
                model.IPAddress = context.Request.UserHostAddress;
                model.NickName = nickName;
                model.PostDate = DateTime.Now;

                T_Msg model_inserted = bll.Add(model);

                var responseObject = new { IsOK = model_inserted != null ? "1" : "0", Model = model_inserted };
                JavaScriptSerializer jss = new JavaScriptSerializer();
                context.Response.Write(jss.Serialize(responseObject));
            }
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