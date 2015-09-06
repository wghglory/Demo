using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 使用服务器端控件记住用户名 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //读取Cookie
        //第一次加载页面才读取Cookie设置文本框
        if (!this.IsPostBack)
        {
            //
            if (Request.Cookies["UserName"] != null)
            {
                this.TextBox1.Text = Request.Cookies["UserName"].Value;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            //记住
            string uname = this.TextBox1.Text.Trim();
            //创建Cookie写Cookie
            HttpCookie hc = new HttpCookie("UserName", uname);
            hc.Expires = DateTime.Now.AddDays(10);
            Response.Cookies.Add(hc);
        }
    }
}