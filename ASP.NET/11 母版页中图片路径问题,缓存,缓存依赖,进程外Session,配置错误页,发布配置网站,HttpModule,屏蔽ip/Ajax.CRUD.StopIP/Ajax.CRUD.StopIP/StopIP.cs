using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ajax.CRUD.StopIP
{
    public class StopIP : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication ha = sender as HttpApplication;
            if (ha.Request.UserHostAddress == "192.168.1.100")
            {
                ha.Response.Redirect("~/EP1.htm");
            }
        }
    }
}
