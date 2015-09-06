<%@ WebHandler Language="C#" Class="ProcessRegist" %>

using System;
using System.Web;

public class ProcessRegist : IHttpHandler
{

    //处理用户的注册请求
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //1.获取用户输入的用户名、密码
        string uid = context.Request.Form["txtLoginId"];
        string pwd1 = context.Request.Form["txtPassword1"];
        string pwd2 = context.Request.Form["txtPassword2"];

        //校验用户两次输入的密码是否一致
        if (pwd1 != pwd2)
        {
            //如果两次输入密码不一致，还是将用户返回到注册页面。
            //读取regist.htm页面的内容，将用户输入的内如也添加进去，然后在把新字符串响应给用户。
            string registHtml = System.IO.File.ReadAllText(context.Server.MapPath("regist.htm"));
            registHtml = registHtml.Replace("<input type=\"text\" name=\"txtLoginId\" value=\"\" />", "<input type=\"text\" name=\"txtLoginId\" value=\"" + uid + "\" />").Replace("<input type=\"password\" name=\"txtPassword2\" value=\"\" />", "<input type=\"password\" name=\"txtPassword2\" value=\"\" /><font color=\"red\">两次输入密码不一致，请重新输入！</font>");
            context.Response.Write(registHtml);
        }
        else
        {
            //如果两次输入的密码一致，则将该用户插入到数据中
            //执行插入操作
            string sql = "insert into Users(loginId,loginPwd) values(@uid,@pwd)";
            System.Data.SqlClient.SqlParameter[] pms = new System.Data.SqlClient.SqlParameter[] { 
            new System.Data.SqlClient.SqlParameter("@uid",uid),
            new System.Data.SqlClient.SqlParameter("@pwd",pwd2)
            };
            int r = Itcast.Cn.SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);
            if (r > 0)
            {
                context.Response.Write("注册成功！");
            }
            else
            {
                context.Response.Write("注册失败！");
            }

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