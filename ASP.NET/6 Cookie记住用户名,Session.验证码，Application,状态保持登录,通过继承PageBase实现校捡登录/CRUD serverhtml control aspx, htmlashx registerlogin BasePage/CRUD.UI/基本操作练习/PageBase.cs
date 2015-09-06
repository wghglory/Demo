using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.UI.基本操作练习
{
    public class PageBase : System.Web.UI.Page
    {
        //在父类中把Page_Load，标记虚方法
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}