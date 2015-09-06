using Nvelocity.BLL;
using Nvelocity.Common;
using Nvelocity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nvelocity.UI
{
    /// <summary>
    /// Summary description for List
    /// </summary>
    public class List : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            SupplierBLL bll = new SupplierBLL();
            IEnumerable<Supplier> suppliers = bll.GetAll();
            string html = CommonHelper.RenderHtml("SupplierList.html", suppliers);

            context.Response.Write(html);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}