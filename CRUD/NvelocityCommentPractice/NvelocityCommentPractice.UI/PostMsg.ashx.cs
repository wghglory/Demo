using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NvelocityCommentPractice.Common;
using NvelocityCommentPractice.BLL;
using NvelocityCommentPractice.Model;

namespace NvelocityCommentPractice.UI
{
    /// <summary>
    /// PostMsg 的摘要说明
    /// </summary>
    public class PostMsg : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string save = context.Request["Save"];
            if (string.IsNullOrEmpty(save))
            {
                var data = new{Title="发表留言"};
                //展示发表留言页面
                string html = CommonHelper.RenderHtml("PostMsg.htm", data);
                context.Response.Write(html);
            }
            else //发表留言
            {
                string title = context.Request["Title"];
                string msg = context.Request["Msg"];
                string nickName = context.Request["NickName"];
                bool isAnonymous = (context.Request["IsAnonymous"] == "on");
                string ipAddress = context.Request.UserHostAddress;//得到访问者的IP地址
                //todo：数据校验

                T_Msg model = new T_Msg();
                model.Title =title;
                model.Message=msg;
                model.NickName=nickName;
                model.IsAnonymous=isAnonymous;
                model.IPAddress=ipAddress;
                model.PostDate = DateTime.Now;

                T_MsgBLL bll = new T_MsgBLL();
                bll.Add(model);

                context.Response.Redirect("ViewMsgs.ashx");
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