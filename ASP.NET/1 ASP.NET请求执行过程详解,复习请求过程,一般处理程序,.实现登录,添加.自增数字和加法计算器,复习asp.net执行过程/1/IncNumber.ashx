<%@ WebHandler Language="C#" Class="IncNumber" %>

using System;
using System.Web;

public class IncNumber : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //当 context.Request.Form["name"] == null的时候，则表示是第一次请求，
        //因为第一次请求时在浏览器地址栏中直接输入一个地址：http://localhost:1318/WebSite12/IncNumber.ashx //此时是一个Get请求，并且该请求的url中没有带任何参数，所以无论如何通过Request方法获取"name"的值的时候一定是null
        //当第二次点击按钮访问的时候，由于表单元素已经生成，那么这次再访问服务器，则会将表单元素中的内容一起提交给服务器，所以第二次访问的时候context.Request.Form["name"]就一定不是null了。除非表单中根本就没有name这个元素。
        int n = context.Request.Form["name"] == null ? 0 : int.Parse(context.Request.Form["name"]) + 1;
        //int n = 0;
        //if (context.Request.Form["name"] == null)
        //{
        //    n = 0;
        //}
        //else
        //{
        //    n = int.Parse(context.Request.Form["name"]);
        //    n++;
        //}

        string IncNumberHtml = System.IO.File.ReadAllText(context.Server.MapPath("IncNumber.htm"));
        IncNumberHtml = IncNumberHtml.Replace("{value}", n.ToString());
        context.Response.Write(IncNumberHtml);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}