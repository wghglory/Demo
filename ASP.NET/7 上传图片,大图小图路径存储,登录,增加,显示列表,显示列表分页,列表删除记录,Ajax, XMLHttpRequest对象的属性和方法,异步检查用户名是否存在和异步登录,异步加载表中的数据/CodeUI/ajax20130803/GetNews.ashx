<%@ WebHandler Language="C#" Class="GetNews" %>

using System;
using System.Web;
using System.Collections.Generic;

public class GetNews : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        sc0802.Bll.Aspx_NewsBll bll = new sc0802.Bll.Aspx_NewsBll();
        int n1, n2;
        List<Model.Aspx_News> _list = bll.GetNewsByPage(10, 1, out n1, out n2);  // .GetAllNews();
        ////[{"name":"zs","age":18,"gender":"男"},{"name":"ls","age":19,"gender":"女"}]
        //{ "p1":{"name":"zs","age":18},"p2":{""}}

        //程序集 System.Web.Extensions.dll, v4.0.30319
        // C:\Program Files\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Web.Extensions.dll
        System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        string json = jsSerializer.Serialize(_list);
        context.Response.Write(json);
       

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}