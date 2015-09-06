using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CRUD.BLL;

namespace CRUD.UI
{
    /// <summary>
    /// ProcessLogin 的摘要说明
    /// </summary>
    public class ProcessLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //让当前的ashx读取login.htm模板中的内容，并且显示出来
            //注意：把相对路径写正确
            string html = File.ReadAllText(context.Request.MapPath("templates/login.htm"));

            //1.获取用户输入的数据
            string loginId = context.Request["txtLoginId"];
            string loginPwd = context.Request["txtPwd"];
            if (loginId != null && loginPwd != null)
            {
                //访问数据库校验
                //直接调用业务逻辑层执行验证操作
                UsersBll bll = new UsersBll();
                if (bll.CheckUserLogin(loginId, loginPwd))
                {
                    //登录成功！
                    context.Response.Redirect("UserList.ashx");
                }
                else
                {
                    //登录失败
                    html = html.Replace("<input type=\"password\" name=\"txtPwd\" value=\"\" />", "<input type=\"password\" name=\"txtPwd\" value=\"\" /><font color=\"red\">登录失败！</font>");
                    html = html.Replace("<input type=\"text\" name=\"txtLoginId\" value=\"\" />", "<input type=\"text\" name=\"txtLoginId\" value=\"" + loginId + "\" />");
                    context.Response.Write(html);
                }
            }
            else
            {
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
}