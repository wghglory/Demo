<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
        context.Response.Write("Hello World");
        context.Response.Write("Hello World");
        context.Response.End();   //之后的不会被响应了
        context.Response.Write("1111");
        context.Response.Write("2222");
        context.Response.Write("33333");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}