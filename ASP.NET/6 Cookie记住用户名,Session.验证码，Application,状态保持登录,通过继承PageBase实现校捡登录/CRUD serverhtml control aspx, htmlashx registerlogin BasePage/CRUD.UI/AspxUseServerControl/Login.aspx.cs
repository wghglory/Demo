using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.UI.AspxUseServerControl
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //执行登录操作
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text.Trim().Length > 0 && this.TextBox2.Text.Length > 0)
            {
                //调用业务层实现登录
                BLL.UsersBll bll = new BLL.UsersBll();
                bool b = bll.CheckUserLogin(this.TextBox1.Text.Trim(), this.TextBox2.Text);
                if (b)
                {
                    Response.Redirect("htmlpage1.htm");
                }
                else
                {
                    this.Label1.Text = "登录失败！";
                }
            }
            else
            {
                this.Label1.Text = "请输入用户名或密码！！";
            }
        }
    }
}