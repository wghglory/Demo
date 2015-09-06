<%@ WebHandler Language="C#" Class="ProvideTime" %>

using System;
using System.Web;

public class ProvideTime : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        System.Threading.Thread.Sleep(2000);
        context.Response.Write(DateTime.Now.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}