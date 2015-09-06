using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI.Repeater_ObjectDataSource
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TblAreaBll bll = new TblAreaBll();
            List<TblArea> list = bll.GetAreasByParentId(0);
            this.BulletedList1.DataSource = list;
            this.BulletedList1.DataTextField = "AreaName";
            this.BulletedList1.DataValueField = "AreaId";
            this.BulletedList1.DataBind();
        }
    }
}