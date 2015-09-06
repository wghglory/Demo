using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.BLL;
using Stu.Model;

namespace CRUD.UI.基本操作练习
{
    public partial class Login : System.Web.UI.Page
    {

        protected string _validCodeErrorMsg;
        protected string LoginErrorMsg;
        protected string _userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            //每次读取页面的时候验证Cookie
            if (Request.Cookies["UserName"] != null)
            {
                _userName = Request.Cookies["UserName"].Value;
            }
            if (Request["txtLoginId"] == null)
            {
                //表示用户第一次请求该页面
            }
            else
            {

                ////每次读取页面的时候验证Cookie
                //if (Request.Cookies["UserName"] != null)
                //{
                //    _userName = Request.Cookies["UserName"].Value;
                //}



                //1.判断用户的验证码是否正确
                if (!(Session["ValidCode"] != null && Session["ValidCode"].ToString() == Request["txtValidCode"]))
                {
                    //表示验证码错误！  或者是验证码有问题
                    _validCodeErrorMsg = "验证码有错误请重新输入！";
                }
                else
                {
                    //验证码正确，记录用户名
                    //1.获取用户输入的用户名
                    string uid = Request["txtLoginId"];
                    string pwd = Request["txtLoginPwd"];
                    //这里checkbox提交过来的数据拿到的依然是Value中的内容
                    string isRem = Request["chkRemember"];
                    if (isRem == "1")
                    {
                        //表示用户选择了记住用户名
                        //那么本次给客户端响应的时候就要向Cookie中写入用户名
                        HttpCookie hcUserName = new HttpCookie("UserName", uid);
                        hcUserName.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(hcUserName);
                    }
                    //Response.Write("===" + isRem + "===");
                    //验证登录操作
                    Aspx_UserBll bll = new Aspx_UserBll();
                    Aspx_User model = bll.GetUserInfo(uid, pwd);
                    if (model != null)
                    {
                        //如果登录成功则把当前的登录信息记录到Session
                        Session["UserInfo"] = model;
                        Response.Redirect("NewsList.aspx");
                    }
                    else
                    {
                        LoginErrorMsg = "登录失败！";
                    }
                }
            }
        }
    }
}