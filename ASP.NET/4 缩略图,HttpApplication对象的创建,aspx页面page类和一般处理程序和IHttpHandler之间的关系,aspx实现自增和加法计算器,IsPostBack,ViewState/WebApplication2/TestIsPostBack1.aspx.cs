using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class TestIsPostBack1 : System.Web.UI.Page
    {

        public bool MyIsPostBack
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region MyRegion
            //if (Request["hiddenIsPostBack"] != null && Request["hiddenIsPostBack"] == "1")
            //{
            //    this.MyIsPostBack = true;
            //}
            //else
            //{
            //    this.MyIsPostBack = false;
            //}

            //Response.Write("aspx页面默认的IsPostBack属性的值：" + this.IsPostBack + "<br/>");
            //Response.Write("MyIsPostBack属性的值：" + this.MyIsPostBack + "<br/>");
            #endregion
            
        }
    }
}
