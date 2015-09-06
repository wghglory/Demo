<%@ WebHandler Language="C#" Class="UserList" %>

using System;
using System.Web;

public class UserList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
        //动态读取数据库中的数据并显示出来。
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}