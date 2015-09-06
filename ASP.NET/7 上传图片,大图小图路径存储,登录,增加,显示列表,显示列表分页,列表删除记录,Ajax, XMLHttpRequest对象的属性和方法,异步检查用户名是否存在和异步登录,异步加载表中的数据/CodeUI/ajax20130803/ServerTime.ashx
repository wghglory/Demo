<%@ WebHandler Language="C#" Class="ServerTime" %>

using System;
using System.Web;

public class ServerTime : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        #region get
        //context.Response.ContentType = "text/plain";
        //string id = context.Request.QueryString["编号"];
        //string name = context.Request["姓名"];
        //context.Response.Write(DateTime.Now.ToString() + "<br/>" + id + "<br/>" + name);
        #endregion

        #region post

        System.Threading.Thread.Sleep(2000);
        context.Response.ContentType = "text/plain";
        string name = context.Request.Form["name"];
        string age = context.Request["age"];
        string gender = context.Request["gender"];
        context.Response.Write(DateTime.Now.ToString() + "<br/>" + name + "<br/>" + age + "<br/>" + gender);

        #endregion

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}