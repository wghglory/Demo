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
    /// Summary description for NewsDetail
    /// </summary>
    public class NewsDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string id = context.Request["id"] ?? "-1";
            int newsId = -1;
            int.TryParse(id, out newsId);

            HKSJ_MainBLL bll = new HKSJ_MainBLL();
            HKSJ_Main news = bll.GetByID(newsId);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", news.ID, news.Title, news.Date, news.Type, news.People, news.Content);

            string tempStr = File.ReadAllText(context.Request.MapPath("/Templates/NewsDetail.html"));
            string result = tempStr.Replace("@trbody", sb.ToString());

            context.Response.Write(result);
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