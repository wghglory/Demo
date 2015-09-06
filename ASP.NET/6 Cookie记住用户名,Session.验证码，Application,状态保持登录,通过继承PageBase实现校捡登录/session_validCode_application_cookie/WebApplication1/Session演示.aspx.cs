using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Session演示 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["uid"] = "nihao";
            Session["pwd"] = "aa";

            HttpCookie hcSession = new HttpCookie("ASP.NET_SessionId", Session.SessionID);
            hcSession.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(hcSession);   //用cookie模拟长时间有效的session
        }
    }
}