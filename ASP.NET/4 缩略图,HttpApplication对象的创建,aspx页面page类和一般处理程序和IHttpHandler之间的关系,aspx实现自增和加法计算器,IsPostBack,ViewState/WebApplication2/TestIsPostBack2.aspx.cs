using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itcast.Cn;

namespace WebApplication2
{
    public partial class TestIsPostBack2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //如果不是回发，表示第一次加载
            {
                string sql = "select count(*) from T_Seats";
                object objCount = SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text);
                this.textbox1.Text = "这是从数据库中查询出的大量的数据：" + objCount.ToString();
            }
           

        }
    }
}