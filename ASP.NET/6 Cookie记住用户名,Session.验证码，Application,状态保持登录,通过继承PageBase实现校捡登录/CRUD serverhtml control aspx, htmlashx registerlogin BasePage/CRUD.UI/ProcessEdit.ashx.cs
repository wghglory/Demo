using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.BLL;
using CRUD.Model;
using System.IO;

namespace CRUD.UI
{
    /// <summary>
    /// ProcessEdit 的摘要说明
    /// </summary>
    public class ProcessEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string html = File.ReadAllText(context.Request.MapPath("templates/edit.htm"));


            if (context.Request["hiddenIsPostback"] == null)
            {
                //表示是第一次访问
                //1.根据用户请求的Id把对应的数据查询出来
                string autoId = context.Request.QueryString["id"];
                if (autoId != null)
                {
                    //则从数据库中读取数据
                    UsersBll bll = new UsersBll();
                    //查询到了数据
                    Users model = bll.GetUserInfoByAutoId(int.Parse(autoId));

                    //读取模板，替换//2.读取模板，根据查询出的信息，替换模板中的内容
                    html = html.Replace("@autoId", model.AutoId.ToString()).Replace("@loginId", model.LoginId).Replace("@pwd", model.LoginPwd).Replace("@errorTimes", model.ErrorCount.ToString()).Replace("@lastLoginTime", model.LastLoginTime.ToString());
                    context.Response.Write(html);

                    //把替换后的内容输出到客户端
                }
                else
                {
                    context.Response.Write(html);
                }
            }
            else if (context.Request["hiddenIsPostback"] == "true")
            {
                //表示是回发
                //表示要执行更新语句
                string autoId = context.Request["txtAutoId"];
                string loginId = context.Request["txtLoginId"];
                string loginpwd = context.Request["txtPwd"];
                int count = int.Parse(context.Request["txtErrorCount"]);
                DateTime dt = DateTime.Parse(context.Request["txtLastLoginTime"]);

                if (autoId != null)
                {
                    UsersBll bll = new UsersBll();
                    Users model = new Users();
                    model.AutoId = int.Parse(autoId);
                    model.LoginId = loginId;
                    model.LoginPwd = loginpwd;
                    model.ErrorCount = count;
                    model.LastLoginTime = dt;
                    bll.Update(model);
                }
                context.Response.Redirect("UserList.ashx");
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