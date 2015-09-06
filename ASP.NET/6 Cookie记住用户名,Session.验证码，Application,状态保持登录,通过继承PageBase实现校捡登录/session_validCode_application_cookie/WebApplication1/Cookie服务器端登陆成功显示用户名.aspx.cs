using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cookie服务器端登陆成功显示用户名 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //每次用户访问该页面的时候都要获取Cookie中的值
            //如果有值，则提示用户：欢迎XXX否则，显示游客。
            //获取Cookie

            HttpCookie ckName = Request.Cookies["userName"];
            if (ckName != null)
            {
                Label1.Text = "欢迎：" + ckName.Value;
            }
            else
            {
                Label1.Text = "游客！";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = this.TextBox1.Text.Trim();  //get login textbox username
            
            HttpCookie hc = new HttpCookie("userName", name);
            hc.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(hc);
        }
    }
}