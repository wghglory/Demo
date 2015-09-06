using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.BLL;

namespace CRUD.UI.AspxNoServerControl
{
    public partial class Login : System.Web.UI.Page
    {
        //用来显示出错时的消息
        protected string _errorMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.处理用户提交过来的数据，并且校验登录是否成功
            //1.1获取用户提交的数据
            string loginId = this.Request["txtLoginId"];
            string loginPwd = this.Request["txtPassword"];
            if (loginId != null && loginPwd != null)
            {
                //然后再访问数据库验证登录
                UsersBll bll = new UsersBll();
                bool b = bll.CheckUserLogin(loginId, loginPwd);
                if (b)
                {
                    this.Response.Redirect("UserList.aspx");
                }
                else
                {
                    _errorMessage = "登录失败!";
                }
            }

        }
    }
}