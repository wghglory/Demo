using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sc0802.Bll;
using Stu.Model;

public partial class GuanLi_Login : System.Web.UI.Page
{
    protected string _userName;
    protected string _errorMsg;

    protected void Page_Load(object sender, EventArgs e)
    {
        _userName = Request["txtLoginId"] == null ? string.Empty : Request["txtLoginId"];

        //判断如果是回发过来的时候获取用户选择的复选框中的值，进行记住密码曹组
        if (Request["txtPassword"] != null)
        {
            //表示回发
            if (Request["chkRemember"] == "1")
            {
                //写Cookie
                HttpCookie hc = new HttpCookie("UserName", Request["txtLoginId"]);
                hc.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(hc);
            }

            //进行检查验证码
            if (CheckValidCode())
            {
                string uid = Request["txtLoginId"];
                string pwd = Request["txtPassword"];
                //验证码成功！
                //进行登录操作
                Aspx_UserBll bll = new Aspx_UserBll();
                Aspx_User model = bll.GetUserInfo(uid, pwd);
                if (model == null)
                {
                    _errorMsg = "登录失败！";
                }
                else
                {
                    Session["UserInfo"] = model;
                    Response.Redirect("NewsList.aspx");
                }
            }
            else
            {
                //验证码失败！
                _errorMsg = "验证码失败";
            }
        }
        else
        {
            //表示第一次请求
            if (Request.Cookies["UserName"] != null)
            {
                _userName = Request.Cookies["UserName"].Value;
            }
        }
    }

    //识别验证码
    private bool CheckValidCode()
    {
        if (Session["ValidCode"] != null && Session["ValidCode"].ToString() == Request["txtValidcode"])
        {
            return true;
        }
        return false;
    }
}