using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class 使用非服务器端控件实现记住用户名 : System.Web.UI.Page
{
    protected string _userName;

    protected void Page_Load(object sender, EventArgs e)
    {
  
        _userName = Request["txtUserName"] == null ? string.Empty : Request["txtUserName"];

        //当用户是回发过来的时候才需要判断checkbox是否被选中，然后执行写入cookie操作
        if (Request["txtUserName"] != null)
        {
            //如果为1，则表示用户需要记住密码
            if (Request["chkRemember"] == "1")
            {
                //写Cookie
                HttpCookie hc = new HttpCookie("UserName", Request["txtUserName"]);
                hc.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(hc);
            }
            else
            {
                ////如果用户没有选中该复选框，则把以前的Cookie删除
                //Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-10);
            }
        }
        else
        {
            //读取Cookie的操作必须是第一次访问该页面才需要读取，如果是回发，则直接把文本框中用户上次输入的内容重新写到文本框即可。
            //加载页面的时候读取Cookie中的值，如果有值，则填写到文本框中
            if (Request.Cookies["UserName"] != null)
            {
                _userName = Request.Cookies["UserName"].Value;
            }
        }
    }
}