using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = (int.Parse(Label1.Text) + 1).ToString();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Response.Write(DateTime.Now.ToString());
        }
    }
}