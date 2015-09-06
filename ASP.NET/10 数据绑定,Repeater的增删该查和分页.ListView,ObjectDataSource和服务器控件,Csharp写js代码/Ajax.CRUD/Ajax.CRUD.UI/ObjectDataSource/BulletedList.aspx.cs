using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI
{
    public partial class BulletedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TblAreaBll bll = new TblAreaBll();
            List<TblArea> list = bll.GetAreasByParentId(0);
            BulletedList1.DataSource = list;
            BulletedList1.DataTextField = "AreaName";
            BulletedList1.DataValueField = "AreaId";
            BulletedList1.DataBind();
        }
    }
}