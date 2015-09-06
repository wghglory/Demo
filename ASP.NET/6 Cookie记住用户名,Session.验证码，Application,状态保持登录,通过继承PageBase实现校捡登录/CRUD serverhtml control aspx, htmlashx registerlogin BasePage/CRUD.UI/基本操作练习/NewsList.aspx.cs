using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.UI.基本操作练习
{
    public partial class NewsList : PageBase
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (Session["UserInfo"] == null)
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);//调用了父类中的Page_Load方法，进行身份验证
            ///在这里再做自己的Page_Load要做的事情，
        }
    }
}