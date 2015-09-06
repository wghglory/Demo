using EasyUI.BLL;
using EasyUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EasyUI_CRUD_Pagination.EasyUIandCustomDiv
{
    /// <summary>
    /// Summary description for GetById
    /// </summary>
    public class GetById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int id = int.Parse(context.Request["id"] ?? "0");
            MyOrderBLL bll = new MyOrderBLL();
            MyOrder order = bll.GetById(id);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string orderjson = jss.Serialize(order);
            context.Response.Write(orderjson);

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