using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cookie非服务器端控件记住用户名 : System.Web.UI.Page
    {
        protected string _userName;

        protected void Page_Load(object sender, EventArgs e)
        {
            _userName = Request["txtUserName"] == null ? string.Empty : Request["txtUserName"];

            //当用户回发时判断是否选中checkbox，然后写入到cookie
            if (Request["txtUserName"] != null)   //回发
            {
                if (Request["chkRem"] == "1")  //remember username
                {
                    HttpCookie hc = new HttpCookie("username", Request["txtUserName"]);
                    hc.Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(hc);
                }
                else
                {
                    //delete the previous record if needed
                    //Response.Cookies["username"].Expires = DateTime.Now.AddDays(-10);
                }
            }
            else  //第一次访问
            {
                //读取cookie必须是第一次访问该页面时读取。如果是回发，则读取记录的cookie写到文本框
                if (Request.Cookies["username"] != null)
                {
                    _userName = Request.Cookies["username"].Value;
                }
            }

        }
    }
}