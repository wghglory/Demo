using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.BLL;

namespace CRUD.UI
{
    /// <summary>
    /// ProcessDelete 的摘要说明
    /// </summary>
    public class ProcessDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.获取用户要删除的记录的Id
            string autoId = context.Request.QueryString["id"];
            if (autoId != null)
            {
                //2.调用业务逻辑层实现删除
                UsersBll bll = new UsersBll();
                bll.Delete(int.Parse(autoId));
            }
            //3.重定向到UserList.ashx页面
            context.Response.Redirect("UserList.ashx");

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