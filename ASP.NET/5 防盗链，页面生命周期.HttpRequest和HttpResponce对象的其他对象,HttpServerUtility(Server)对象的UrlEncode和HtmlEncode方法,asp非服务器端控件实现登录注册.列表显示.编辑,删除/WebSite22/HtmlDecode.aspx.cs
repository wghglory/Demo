using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string text = "fdsalfdsfsaf";
        string text = "<script type=\"text/javascript\">alert('中毒了！！！！');window.location='http://net.itcast.cn';</script>";
        text = this.Server.HtmlEncode(text);
        //HttpUtility.HtmlDecode(
        this.Response.Write(text);
    }
}