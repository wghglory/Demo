<%@ WebHandler Language="C#" Class="ProcessLogin" %>

using System;
using System.Web;

public class ProcessLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //1.获取用户提交过来的数据
        string uid = context.Request["loginId"];
        string pwd = context.Request["pwd"];

        //调用业务逻辑层实现登录
        sc0802.Bll.Aspx_UserBll bll = new sc0802.Bll.Aspx_UserBll();
        Stu.Model.Aspx_User model = bll.GetUserInfo(uid, pwd);
        if (model == null)
        {
            context.Response.Write("2");
        }
        else
        {
            context.Session["UserInfo"] = model;
            context.Response.Write("1");
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