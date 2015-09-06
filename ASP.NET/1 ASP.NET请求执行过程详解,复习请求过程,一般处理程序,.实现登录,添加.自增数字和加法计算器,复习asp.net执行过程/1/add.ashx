<%@ WebHandler Language="C#" Class="add" %>

using System;
using System.Web;

public class add : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        if (context.Request.QueryString["n1"] == null || context.Request.QueryString["n2"] == null)
        {
            //表示是第一次访问
            //每当用户第一次访问该页面的时候就读取该模板把它发送给客户端
            string html = System.IO.File.ReadAllText(context.Server.MapPath("add.htm"));
            //第一次用户访问的时候希望“结果文本框”中什么都没有
            html = html.Replace("{result}", string.Empty);
            context.Response.Write(html);
        }
        else
        {

            //获取用户输入的参数
            int n1 = int.Parse(context.Request.QueryString["n1"]);
            int n2 = int.Parse(context.Request.QueryString["n2"]);
            int sum = n1 + n2;
            //读取模板的html代码 
            string html = System.IO.File.ReadAllText(context.Server.MapPath("add.htm"));
            html = html.Replace("<input type=\"text\" name=\"n1\" value=\"0\" />", "<input type=\"text\" name=\"n1\" value=\"" + n1 + "\" />");
            html = html.Replace("<input type=\"text\" name=\"n2\" value=\"0\" />", "<input type=\"text\" name=\"n2\" value=\"" + n2 + "\" />");
            html = html.Replace("{result}", sum.ToString());
            context.Response.Write(html);
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