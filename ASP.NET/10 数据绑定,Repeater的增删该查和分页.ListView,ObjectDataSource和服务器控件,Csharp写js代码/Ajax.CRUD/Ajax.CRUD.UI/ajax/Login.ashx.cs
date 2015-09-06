using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using System.Web.SessionState;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.获取用户提交过来的用户名与密码
            string loginId = context.Request["loginId"];
            string password = context.Request["password"];
            if (loginId != null && password != null)
            {
                //2.调用业务逻辑层实现校验
                Aspx_UserBll bll = new Aspx_UserBll();
                Aspx_User model = bll.GetUserInfo(loginId, password);
                //3.根据校验结果返回用户对应的值。1表示成功2表示失败
                if (model != null)
                {
                    context.Session["UserInfo"] = model;
                    //成功！
                    context.Response.Write("1");
                }
                else
                {
                    //登录失败！
                    context.Response.Write("2");
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
}