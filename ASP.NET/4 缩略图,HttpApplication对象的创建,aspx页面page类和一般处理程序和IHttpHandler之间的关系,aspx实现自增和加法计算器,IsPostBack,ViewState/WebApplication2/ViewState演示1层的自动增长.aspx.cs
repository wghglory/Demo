using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ViewState演示1层的自动增长 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ViewState[".netDarkHorseSeven"] = "一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！一匹黑色的马！！！就像法拉利一样。。。 ";

            this.ViewState["页面中第二个层下面的文本框的值"] = "aa";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.dv1.InnerText = (int.Parse(this.dv1.InnerText) + 1).ToString();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Response.Write("触发了文本框2的文本改变事件");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}