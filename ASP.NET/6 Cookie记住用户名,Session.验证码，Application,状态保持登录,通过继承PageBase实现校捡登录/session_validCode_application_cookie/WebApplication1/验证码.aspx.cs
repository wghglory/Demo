using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class 验证码 : System.Web.UI.Page
    {
        protected string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取用户输入的验证码
            string validCode = Request["validcode"];
            if (validCode != null && Session["ValidCode"] != null) //session is from ValidCode.ashx
            {
                if (Session["ValidCode"].ToString() == validCode)
                {
                    msg = "验证码正确";
                }
                else
                {
                    msg = "不正确";
                }
            }
        }
    }
}