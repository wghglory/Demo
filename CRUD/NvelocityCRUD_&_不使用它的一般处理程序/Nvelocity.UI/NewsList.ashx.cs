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
    /// Summary description for NewsList
    /// </summary>
    public class NewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            HKSJ_Main model = new HKSJ_Main();
            HKSJ_MainBLL bll = new HKSJ_MainBLL();
            IEnumerable<HKSJ_Main> newslist = bll.GetAll();

            StringBuilder sb = new StringBuilder();
            foreach (var news in newslist)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href='NewsDetail.ashx?id={0}'>details</a>&nbsp;<a href='EditNews.ashx?Action=Edit&id={0}'>edit</a>&nbsp;<a href='DeleteNews.ashx?id={0}'>delete</a></td></tr>", news.ID, news.Title, news.Date, news.People);
            }
            string tempString = File.ReadAllText(context.Request.MapPath("/Templates/NewsList.html"));
            string result = tempString.Replace("@trbody", sb.ToString());
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