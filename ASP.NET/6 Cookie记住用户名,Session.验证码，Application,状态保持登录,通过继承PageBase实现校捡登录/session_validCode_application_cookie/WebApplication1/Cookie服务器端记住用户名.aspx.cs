using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cookie记住用户名 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)  //第一次
            {
                //读取Cookie并赋值
                if (Request.Cookies["userName"] != null)
                {
                    string name = Request.Cookies["userName"].Value;
                    this.TextBox1.Text = name;
                }
            }
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {           
            // 判断Checkbox是否被选中，如果被选中则向客户端写入一个username的cookie
            if (this.CheckBox1.Checked)
            {
                string txt = this.TextBox1.Text;
                //则向客户端发送一个userName的Cookie
                HttpCookie hcUserName = new HttpCookie("userName", txt);
                hcUserName.Expires = DateTime.Now.AddDays(10);
                hcUserName.Path = "/";   //让cookie在网站所有目录下传递。/根目录
                Response.Cookies.Add(hcUserName);
            }
            else
            {
                //删除客户端的userName的Cookie
                if (Request.Cookies["userName"] != null)
                {
                    HttpCookie hc = Request.Cookies["userName"];
                    hc.Expires = DateTime.Now.AddDays(-10);
                    Response.Cookies.Add(hc);
                }

            }
        }
    }
}