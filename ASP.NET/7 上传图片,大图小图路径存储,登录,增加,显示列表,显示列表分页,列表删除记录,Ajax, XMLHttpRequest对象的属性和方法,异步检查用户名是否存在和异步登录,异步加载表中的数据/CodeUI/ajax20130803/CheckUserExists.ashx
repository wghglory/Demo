<%@ WebHandler Language="C#" Class="CheckUserExists" %>

using System;
using System.Web;

public class CheckUserExists : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //如果存在该用户则返回UserExists,如果不存在返回UserNotExists
        string name = context.Request["loginId"];

        sc0802.Bll.Aspx_UserBll bll = new sc0802.Bll.Aspx_UserBll();
        int r = bll.CheckUserExists(name);
        if (r > 0)
        {
            context.Response.Write("UserExists");
        }
        else
        {
            context.Response.Write("UserNotExists");
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