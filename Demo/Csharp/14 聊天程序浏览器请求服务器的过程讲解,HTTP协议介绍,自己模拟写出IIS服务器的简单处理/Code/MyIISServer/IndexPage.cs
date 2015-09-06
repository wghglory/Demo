using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyIISServer
{
    public class IndexPage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ResponseBody = Encoding.UTF8.GetBytes("<font color='red' size='7' face='幼圆'>Hello World!</font>");
        }
    }
}
