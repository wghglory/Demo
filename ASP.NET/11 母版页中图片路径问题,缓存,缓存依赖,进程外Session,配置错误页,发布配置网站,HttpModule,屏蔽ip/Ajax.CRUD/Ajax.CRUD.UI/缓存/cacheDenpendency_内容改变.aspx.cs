using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ajax.CRUD.UI._20130808.缓存
{
    public partial class _05 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["Time"] == null)
            {
                Cache.Insert("Time", DateTime.Now, new System.Web.Caching.CacheDependency(Server.MapPath("userfile.txt")));
            }
            Response.Write(Cache["Time"].ToString());
        }
    }
}