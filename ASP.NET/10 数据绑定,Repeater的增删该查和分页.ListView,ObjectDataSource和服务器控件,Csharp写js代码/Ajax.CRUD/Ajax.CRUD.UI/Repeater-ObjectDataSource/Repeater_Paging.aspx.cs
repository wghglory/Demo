using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.Utility;
using Ajax.CRUD.BLL;

namespace Ajax.CRUD.UI.test
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected string PagerString;
        protected void Page_Load(object sender, EventArgs e)
        {
            int psize = 5;
            int pindex = Request["pageindex"] == null ? 1 : int.Parse(Request["pageindex"]);
            Aspx_StudentsBll bll = new Aspx_StudentsBll();
            int recordCount = bll.GetTotalCount();
            int pageCount = (int)Math.Ceiling(recordCount * 1.0 / psize);

            PagerString = PagerHelper.strPage(recordCount, psize, pageCount, pindex, "WebForm6.aspx?pageindex=");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int sid = Convert.ToInt32(e.CommandArgument);
                Aspx_StudentsBll bll = new Aspx_StudentsBll();
                bll.DeleteByStuId(sid);
                this.Repeater1.DataBind();
            }
        }
    }
}