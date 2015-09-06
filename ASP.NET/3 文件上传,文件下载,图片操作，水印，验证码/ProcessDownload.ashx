<%@ WebHandler Language="C#" Class="ProcessDownload" %>

using System;
using System.Web;

public class ProcessDownload : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //获取用户要下载的资源的名称
        string name = context.Request.Params["downloadName"];

        //设置响应报文中，当前资源是一个附件，需要下载。
        context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(name));

        //获取到用户要下载的资源后，读取磁盘文件，把该文件发送给客户端
        context.Response.WriteFile("download/" + name);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}