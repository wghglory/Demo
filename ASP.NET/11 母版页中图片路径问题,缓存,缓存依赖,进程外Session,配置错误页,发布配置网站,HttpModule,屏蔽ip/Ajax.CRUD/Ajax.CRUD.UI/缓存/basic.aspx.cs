using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ajax.CRUD.UI._20130808.缓存
{
    public partial class _01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cache是针对网站所有用户的，不是只针对特定用户，在所有页面中都可以使用。
            //与Session略有不同。
            if (Cache["Time"] == null)
            {
                //这种写法只要应用程序不重新启动, 一直有效。
                // Cache["Time"] = DateTime.Now.ToString();

                //设置一个缓存的过期时间（绝对过期时间）
                // Cache.Insert("Time", DateTime.Now.ToString(), null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);

                //设置”滑动过期日期“Slide Expiration
                Cache.Insert("Time", DateTime.Now.ToString(), null, DateTime.MaxValue, TimeSpan.FromSeconds(3));
            }
            Response.Write(Cache["Time"]);
        }
    }
}