using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class JiaFaJiSuanQiFuWuQiDuanKongJian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.TextBox1.Text.Trim().Length > 0 && this.TextBox2.Text.Trim().Length > 0)
            {
                this.TextBox3.Text = (int.Parse(this.TextBox1.Text.Trim()) + int.Parse(this.TextBox2.Text.Trim())).ToString();
            }
        }
    }
}