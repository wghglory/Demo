using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            lock ("OnLine")
            {
                int n = Application["OnLineUsers"] == null ? 0 : Convert.ToInt32(Application["OnLineUsers"]);
                n++;
                Application["OnLineUsers"] = n;
            }

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            lock ("OnLine")
            {
                int n = Application["OnLineUsers"] == null ? 0 : Convert.ToInt32(Application["OnLineUsers"]);
                n--;
                Application["OnLineUsers"] = n < 0 ? 0 : n;
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}