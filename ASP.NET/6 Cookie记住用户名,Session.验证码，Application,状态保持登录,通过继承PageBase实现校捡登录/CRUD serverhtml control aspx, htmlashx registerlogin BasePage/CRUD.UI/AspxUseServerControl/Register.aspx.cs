using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Model;

namespace CRUD.UI.AspxUseServerControl
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //使用服务器端控件后不需要考虑请求和响应，直接在这里像windows窗体应用程序一样编程就可以了。
            if (this.TextBox1.Text.Trim().Length > 0 && this.TextBox2.Text.Trim().Length > 0 && this.TextBox3.Text.Trim().Length > 0)
            {
                if (this.TextBox2.Text == this.TextBox3.Text)
                {
                    //开始注册
                    BLL.UsersBll bll = new BLL.UsersBll();
                    Users model = new Users();
                    model.LoginId = this.TextBox1.Text.Trim();
                    model.LoginPwd = this.TextBox2.Text.Trim();

                    bll.Add(model);
                    Response.Write("成功！");
                }
                else
                {
                    this.Label1.Text = "两次密码不一致！";
                }
            }
            else
            {
                this.Label1.Text = "字段值必须输入！";
            }
        }
    }
}