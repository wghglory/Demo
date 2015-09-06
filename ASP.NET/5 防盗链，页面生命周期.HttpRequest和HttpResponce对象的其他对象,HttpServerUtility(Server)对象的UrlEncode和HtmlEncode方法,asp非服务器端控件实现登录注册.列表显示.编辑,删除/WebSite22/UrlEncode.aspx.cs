using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string uu = HttpUtility.UrlEncode("传智播客.net培训");//不用老方法： this.Server.UrlEncode("传智播客.net培训");
        this.Response.Write(uu);
        this.Response.Write("<br/>");
        this.Response.Write(this.Server.UrlDecode(uu));  
        //string msg = "http://localhost:7721/WebSite22/Default4.aspx";
        //this.Response.Write(this.Server.UrlEncode(msg));  //不要这样。只对需要的内容编码
        //HttpUtility.
    }
}