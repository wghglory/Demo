using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ZiZeng : System.Web.UI.Page
    {

        protected int _number;

        protected void Page_Load(object sender, EventArgs e)
        {
            //1.获取用户提交过来的数据 
            _number = Request["txtNumber"] == null ? 0 : int.Parse(Request["txtNumber"]) + 1;

            Response.Write("今天是个好日子，不热！！！！！");
        }
    }
}