using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ajax.CRUD.Model;
using Ajax.CRUD.BLL;
using System.Web.Caching;

namespace Ajax.CRUD.UI._20130808.缓存
{
    public partial class _06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //自己写一个返回List集合的方法
            if (!this.IsPostBack)
            {
                if (Cache["List"] == null)
                {
                    TblCommentsBll bll = new TblCommentsBll();
                    //读取数据
                    List<TblComments> list = bll.GetAllComments();
                    this.Repeater1.DataSource = list;
                    //Cache["List"] = list;
                    Cache.Insert("List", list, new SqlCacheDependency("apsxDbEntityName", "TblComments"));
                    this.Repeater1.DataBind();
                }
                else
                {
                    this.Repeater1.DataSource = Cache["List"];
                    this.Repeater1.DataBind();
                }

            }
        }
    }
}