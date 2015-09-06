using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace Ajax.CRUD.UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        //请求一开始就执行
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string ip = Request.UserHostAddress;
            if (ip == "192.168.1.109" || ip == "192.168.1.25")
            {
                Response.Redirect("~/EP1.htm");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //string errorMsg = Context.Error.Message + Environment.NewLine + Context.Error.StackTrace + Environment.NewLine + "==========================================================" + Environment.NewLine;
            ////1.把错误记录的日志中
            //File.WriteAllText(Server.MapPath("~/log.txt"), errorMsg);

            ////2.将用户重定向到一个新的页面。
            //Response.Redirect("~/EP1.htm");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}