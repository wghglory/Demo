using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using CRUD.BLL;
using CRUD.Model;

namespace CRUD.UI
{
    /// <summary>
    /// ProcessRegister 的摘要说明
    /// </summary>
    public class ProcessRegister : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //1.读取模板
            string html = File.ReadAllText(context.Request.MapPath("templates/register.htm"));
            //获取用户提交过来的数据
            string loginId = context.Request["txtLoginId"];
            string pwd1 = context.Request["txtPassword1"];
            string pwd2 = context.Request["txtPassword2"];
            if (loginId != null && pwd1 != null && pwd2 != null)
            {
                //表示用户提交过来了数据
                //1.校验用户两次输入的密码是否一致
                if (pwd1 == pwd2)
                {
                    //继续处理注册操作
                    //insert语句
                    UsersBll bll = new UsersBll();
                    Users model = new Users();
                    model.LoginId = loginId;
                    model.LoginPwd = pwd2;
                    int r = bll.Add(model);
                    context.Response.Write("注册成功！");
                }
                else
                {
                    //返回用户到注册页面，同时保留用户上次输入的loginId
                    html = html.Replace("<input type=\"text\" name=\"txtLoginId\" value=\"\" />", "<input type=\"text\" name=\"txtLoginId\" value=\"" + loginId + "\" />");
                    html = html.Replace("<input type=\"password\" name=\"txtPassword2\" value=\"\" />", "<input type=\"password\" name=\"txtPassword2\" value=\"\" /><font color=\"red\">两次新密码输入不一致!</font>");
                    context.Response.Write(html);
                }
            }
            else
            {
                //为用户展示一个注册页面
                //2.将数据发送到客户端
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