<%@ WebHandler Language="C#" Class="ProcessLogin" %>

using System;
using System.Web;
/// <summary>
/// 处理用户登录的一般处理程序
/// </summary>
public class ProcessLogin : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //在这里获取用户的请求，并处理用户的请求，最后再将请求结果设置到Response中。
        context.Response.ContentType = "text/html";

        #region MyRegion
        ////1.获取用户提交到服务器的数据
        ////get请求时，服务器获取用户数据的方式
        ////context.Request
        ////通过context.Request.QueryString[]的方式只能获取get请求提交过来的数据
        //string loginId = context.Request.QueryString["txtLoginId"];
        //string loginPwd = context.Request.QueryString["txtLoginPwd"];

        ////获取post请求提交过来的数据
        //string loginId = context.Request.Form["txtLoginId"];
        //string loginPwd = context.Request.Form["txtLoginPwd"];

        //string loginId = context.Request.Params["txtLoginId"];
        //string loginPwd = context.Request.Params["txtLoginPwd"];
        ////context.Request[""]
        //context.Response.Write("用户名：" + loginId + "    密码：" + loginPwd);
        #endregion

        //获取post请求提交过来的数据
        string loginId = context.Request.Form["txtLoginId"];
        string loginPwd = context.Request.Form["txtLoginPwd"];

        //2.连接数据库比对用户名与密码，判断是否登录正确
        string connStr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True;";
        int n = -1;
        using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connStr))
        {
            //创建Sql语句
            string sql = "select count(*) from Users where loginId=@uid and loginpwd=@pwd";
            System.Data.SqlClient.SqlParameter[] pms = new System.Data.SqlClient.SqlParameter[] { 
            new System.Data.SqlClient.SqlParameter("@uid",loginId),
            new System.Data.SqlClient.SqlParameter("@pwd",loginPwd)
            };
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(pms);
                con.Open();
                n = (int)cmd.ExecuteScalar();
            }
        }
        if (n > 0)
        {
            //假设当登录成功后，跳转到一个UserList页面，该页面中可以显示当前Users表中的所有数据的记录。
            context.Response.Write("登录成功！");
        }
        else
        {
            //context.Response.Write("登录失败！");
            //当验证用户名密码失败后，不要直接显示“失败！”字样，而是要再次跳转到login.htm页面，让用户重新登录
            //如果登录失败，让用户跳转到login.htm页面。

            //Redirect()，下面这句话表示服务器向客户端发出了一个响应，这个响应就是302（重定向）.
            //客户端浏览器获取到这个响应的时候，就会自动再次发出一个请求，请求上次302响应中Location所指向的地址。既然是向login.htm发出的一次新请求，那么由于login.htm中本身文本框中就没有任何数据，所以这次请求返回的login.htm中不可能保存上次的用户输入内容。
            //context.Response.Redirect("login.htm");

            //而是在服务器端进行字符串拼接，把拼接好的内容直接响应给用户
            //context.Server.MapPath("login.htm")把网页的相对路径转换成了一个磁盘的绝对路径。
            string loginHtml = System.IO.File.ReadAllText(context.Server.MapPath("login.htm"));
            loginHtml = loginHtml.Replace("<input type=\"text\" name=\"txtLoginId\" value=\"\" />", "<input type=\"text\" name=\"txtLoginId\" value=\"" + loginId + "\" />");
            loginHtml = loginHtml.Replace("<input type=\"password\" name=\"txtLoginPwd\" value=\"\" />", "<input type=\"password\" name=\"txtLoginPwd\" value=\"" + loginPwd + "\" /><font color=\"red\">登录失败！</font>");
            context.Response.Write(loginHtml);

        }

        //3.如果正确设置响应内容


        //4.如果错误，设置另外的响应内容
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}