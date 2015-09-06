using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.BLL;

namespace Ajax.CRUD.UI.test
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Aspx_StudentsBll bll = new Aspx_StudentsBll();
                this.Repeater1.DataSource = bll.GetAllStudents();
                this.Repeater1.DataBind();
            }
           
        }
    }
}