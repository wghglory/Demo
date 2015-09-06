using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AjaxComment.BLL;
using AjaxComment.Model;
using AjaxComment.Common;

namespace AjaxComment.UI
{
    /// <summary>
    /// ViewMsgs 的摘要说明
    /// </summary>
    public class ViewMsgs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            T_MsgBLL bll = new T_MsgBLL();
            IEnumerable<T_Msg> msgs = bll.GetAll();

            //DataTable msgs = SqlHelper.ExecuteDataTable("select * from T_Msgs");
            //var data = new { Title="查看所有留言",Msgs=msgs.Rows};

            var data = new { Title = "查看所有留言", Msgs = msgs };
            string html = CommonHelper.RenderHtml("ViewMsgs.htm", data);
            context.Response.Write(html);
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