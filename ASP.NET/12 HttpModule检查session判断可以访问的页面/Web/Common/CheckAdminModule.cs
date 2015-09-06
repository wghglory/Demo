using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Web.Common
{

    //老式，不要忘记：在配置文件中配置一下。
    //<httpModules>
    //    <add name="CheckAdminModule" type="Web.Common.CheckAdminModule"/>
    //</httpModules>

    //新iis7以上
    //   <system.webServer>
    //  <modules>
    //    <add name="CheckAdminModule" type="Web.Common.CheckAdminModule"/>
    //  </modules>
    //</system.webServer>
    public class CheckAdminModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(OnRequest);

        }
        public void OnRequest(object source, EventArgs e)
        {

            HttpApplication application = source as HttpApplication;//得到Application
            HttpContext context = application.Context;//得到请求上下文.
            Uri url = context.Request.Url;//得到当前请求的URL

            //请求Admin目录下的文件时，需要进行身份验证，只有管理员才能访问.
            if (url.AbsolutePath.ToLower().StartsWith("/admin") && url.AbsolutePath != "/admin/adminlogin.aspx")
            {
                //adminlogin.aspx不需要身份验证

                if (HttpContext.Current.Session["Name"] == null)
                {
                    HttpContext.Current.Response.Redirect("adminlogin.aspx");
                }

            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
