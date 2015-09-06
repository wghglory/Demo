using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// CheckUserExists 的摘要说明
    /// </summary>
    public class CheckUserExists : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //检查指定的用户名是否已经被注册
            //1.获取用户提交过来的用户名
            string loginId = context.Request["loginId"];
            if (loginId != null)
            {
                //检查用户名是否存在，如果存在返回1，否则返回0
                Aspx_UserBll bll = new Aspx_UserBll();
                if (bll.CheckUserExists(loginId))
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
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