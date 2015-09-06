using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.Utility;
using Ajax.CRUD.BLL;

namespace Ajax.CRUD.UI.ObjectDataSource
{
    public partial class RepeaterShowByPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            #region 根据每页条数、当前要查看的记录条数、总数据等，生成页导航的html标签，并且设置到Literal中。

            Aspx_StudentsBll bll = new Aspx_StudentsBll();

            int rcount = bll.GetTotalCount();
            int pindex = Request["pageindex"] == null ? 1 : int.Parse(Request["pageindex"]);
            int psize = 5;
            int pcount = (int)Math.Ceiling(rcount * 1.0 / psize);

            //每次页面加载的时候生成分页的导航html，并设置到Literal中
            this.Literal1.Text = PagerHelper.strPage(rcount, psize, pcount, pindex, "RepeaterShowByPage.aspx?pageindex=");
            #endregion
           
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}