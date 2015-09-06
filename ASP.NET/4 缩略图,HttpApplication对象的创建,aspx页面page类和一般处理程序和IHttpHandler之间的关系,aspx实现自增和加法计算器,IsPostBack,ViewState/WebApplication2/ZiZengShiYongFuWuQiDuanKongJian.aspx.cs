using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ZiZengShiYongFuWuQiDuanKongJian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Length > 0)
            {
                this.TextBox1.Text = (int.Parse(this.TextBox1.Text.Trim()) + 1).ToString();
            }
        }
    }
}