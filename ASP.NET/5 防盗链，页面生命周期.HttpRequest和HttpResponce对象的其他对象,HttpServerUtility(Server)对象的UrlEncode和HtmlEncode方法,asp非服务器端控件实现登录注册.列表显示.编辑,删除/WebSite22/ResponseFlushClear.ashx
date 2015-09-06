<%@ WebHandler Language="C#" Class="Test1" %>

using System;
using System.Web;

public class Test1 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //context.Server
        context.Response.ContentType = "text/html";
        for (int i = 0; i < 10; i++)
        {
            context.Response.Write("这是第" + i + "次输出。<br/>");
            //Flush()清空当前缓冲区，并把缓冲区的内容发送给浏览器
            //context.Response.Flush();
            //清空缓冲区，缓冲区的内容被销毁了，没有发送到浏览器中。
            context.Response.Clear();
            System.Threading.Thread.Sleep(400);
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