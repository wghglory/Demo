using EasyUI.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI_CRUD_Pagination.EasyUIandCustomDiv
{
    /// <summary>
    /// Summary description for Delete
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string id = context.Request["id"];
            MyOrderBLL bll = new MyOrderBLL();
            if (bll.DeleteById(int.Parse(id)) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("fail");
            }

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