<%@ WebHandler Language="C#" Class="_01Handler" %>

using System;
using System.Web;
using System.Text;

public class _01Handler : IHttpHandler
{
    //不用模板，完全拼接字符串返回前台, 缺点：不能和美工配合控制样式！
    public void ProcessRequest(HttpContext context)
    {
        //设置响应报文头中的Content-Type值。
        context.Response.ContentType = "text/html";
        //context.Response.Write("Hello World");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<html><head><title>你好！</title></head><body><h1>" + DateTime.Now.ToString() + "</h1></body></html>");

        //将数据发送到响应中
        context.Response.Write(sb.ToString());


        //context.Response.ContentType = "text/plain";
        //System.Text.StringBuilder stringBuilder = new StringBuilder();
        //stringBuilder.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
        //stringBuilder.AppendLine("<head><title>Shit</title></head><body>");
        //for (int i = 0; i < 6; i++)
        //{
        //    stringBuilder.AppendLine("<h" + (i + 1) + ">" + DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture) + "</h" + (i + 1) + ">");
        //}
        //stringBuilder.AppendLine("</body></html>");
        //context.Response.Write(stringBuilder.ToString());

        //context.Response.ContentType = "image/jpeg";
        //context.Response.WriteFile("1.jpg");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}