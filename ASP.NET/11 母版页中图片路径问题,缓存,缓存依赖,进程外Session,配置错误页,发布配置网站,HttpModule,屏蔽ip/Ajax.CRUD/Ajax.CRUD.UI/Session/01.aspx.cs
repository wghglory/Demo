using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ajax.CRUD.UI._20130808.Session
{
    public partial class _01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                Response.Write(Session["UserName"]);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserName"] = this.TextBox1.Text;
            Session["p"] = new Person() { Name = "黄林", Age = 18, Email = "hl@yahoo.com" };
        }
    }


}