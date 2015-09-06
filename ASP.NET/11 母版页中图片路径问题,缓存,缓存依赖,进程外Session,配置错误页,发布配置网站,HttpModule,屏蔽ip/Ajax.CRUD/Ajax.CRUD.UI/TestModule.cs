using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax.CRUD.UI.test2
{
    public class TestModule : IHttpModule
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
            ha.Response.Write("在自定义的HttpModule中注册的BeginRequest事件：【" + DateTime.Now.ToString() + "】");
        }
    }
}