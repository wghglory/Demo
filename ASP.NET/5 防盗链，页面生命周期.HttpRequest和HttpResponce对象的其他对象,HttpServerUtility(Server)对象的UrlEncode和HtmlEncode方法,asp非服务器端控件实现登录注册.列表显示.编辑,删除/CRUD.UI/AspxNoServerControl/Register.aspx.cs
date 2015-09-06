using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Model;

namespace CRUD.UI.AspxNoServerControl
{
    public partial class Register : System.Web.UI.Page
    {

        protected string _errorMessage;
        protected string _loginId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //1获取用户提交的数据,做简单校验，然后把数据插入到数据库中
            string uid = this.Request.Params["txtLoginId"];
            string pwd = this.Request.Params["txtPassword1"];
            string pwd1 = this.Request.Form["txtPassword2"];
            _loginId = uid;
            if (uid != null && pwd != null && pwd1 != null)
            {
                if (pwd1 == pwd)
                {
                    //表示用户两次输入的密码是正确的。
                    BLL.UsersBll bll = new BLL.UsersBll();
                    Users model = new Users();
                    model.LoginId = uid;
                    model.LoginPwd = pwd;
                    int r = bll.Add(model);
                    if (r > 0)
                    {
                        _errorMessage = "注册成功！，请访问login.aspx登录！";
                    }
                    else
                    {
                        _errorMessage = "注册失败！";
                    }
                }
                else
                {
                    //表示两次输入密码有误！
                    _errorMessage = "两次输入密码不一致！";
                }
            }
        }
    }
}