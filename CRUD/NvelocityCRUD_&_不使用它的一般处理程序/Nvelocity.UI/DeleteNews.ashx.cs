using Nvelocity.BLL;
using Nvelocity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace 一般处理程序三层CRUD
{
    /// <summary>
    /// Summary description for DeleteNewsList
    /// </summary>
    public class DeleteNewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string id = context.Request["id"] ?? "-1";
            int newsId = -1;
            int.TryParse(id, out newsId);

            HKSJ_MainBLL bll = new HKSJ_MainBLL();
            int rowAffected = bll.DeleteByID(newsId);

            if (rowAffected > 0)
            {
                context.Response.Redirect("NewsList.ashx");
            }
            else
            {
                context.Response.Write("delete fails");
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