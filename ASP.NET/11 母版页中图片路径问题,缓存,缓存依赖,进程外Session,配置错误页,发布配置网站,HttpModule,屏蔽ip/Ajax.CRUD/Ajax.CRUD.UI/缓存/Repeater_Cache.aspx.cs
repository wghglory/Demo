using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;

namespace Ajax.CRUD.UI._20130808.缓存
{
    public partial class _03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Cache["Students"] == null)
                {
                    //读取数据并绑定
                    Aspx_StudentsBll bll = new Aspx_StudentsBll();
                    List<Aspx_Students> list = bll.GetStudentsBetweentAnd(1, 5);
                    this.Repeater1.DataSource = list;
                    // Cache["Students"] = list;
                    Cache.Insert("Students", list, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
                    this.Repeater1.DataBind();
                }
                else
                {
                    this.Repeater1.DataSource = Cache["Students"];
                    this.Repeater1.DataBind();
                }

            }
        }
    }
}