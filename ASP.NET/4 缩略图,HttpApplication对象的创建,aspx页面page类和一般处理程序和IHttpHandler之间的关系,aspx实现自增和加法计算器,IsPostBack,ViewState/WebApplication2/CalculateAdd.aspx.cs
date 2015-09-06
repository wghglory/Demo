using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class CalculateAdd : System.Web.UI.Page
    {

        protected int _number1;
        protected int _number2;
        protected int _sum;
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.获取用户提交过来的两个文本框中的数据
            int n1 = Request["txtNum1"] == null ? 0 : int.Parse(Request["txtNum1"]);
            int n2 = Request["txtNum2"] == null ? 0 : int.Parse(Request["txtNum2"]);
            int sum = n1 + n2;

            this._number1 = n1;
            this._number2 = n2;
            this._sum = sum;
        }
    }
}