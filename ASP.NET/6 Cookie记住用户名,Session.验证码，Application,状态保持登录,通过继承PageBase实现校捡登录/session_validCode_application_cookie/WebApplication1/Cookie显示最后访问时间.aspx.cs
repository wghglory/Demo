using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cookie显示最后访问时间 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie hc = Request.Cookies["LastVisitTime"];
            if (hc != null)
            {
                this.Label1.Text = "最后访问时间：" + hc.Value;
            }


            WriteCookie();
        }

        private void WriteCookie()
        {
            //每次用户刷新页面都要把当前时间写入到Cookie中
            HttpCookie cookie1 = new HttpCookie("LastVisitTime", DateTime.Now.ToString());
            //设置有效期
            cookie1.Expires = DateTime.Now.AddDays(1);

            //设置该cookie的有效域名，即访问该域名的时候浏览器会自动携带该cookie
            cookie1.Domain = " localhost ";

            //设置cookie的有效路径，/表示网站根目录，即访问该网站下的所有路径，都会携带该cookie
            cookie1.Path = "/";

            //限制了不能通过js脚本来操作Cookie
            cookie1.HttpOnly = true;

            //如果为true，则表示必须使用SSL，即https的时候浏览器才会将该cookie携带，并访问网站，否则浏览器不自动携带。
            cookie1.Secure = false;

            Response.Cookies.Add(cookie1);
        }
    }
}