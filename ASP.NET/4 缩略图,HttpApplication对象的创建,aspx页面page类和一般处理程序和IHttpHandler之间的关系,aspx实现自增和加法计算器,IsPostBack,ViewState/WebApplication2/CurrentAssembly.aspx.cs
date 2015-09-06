using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace WebApplication2
{
    public partial class CurrentAssembly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("codebehind所在的dll:" + Assembly.GetExecutingAssembly().Location);
            Response.Write("!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }
}