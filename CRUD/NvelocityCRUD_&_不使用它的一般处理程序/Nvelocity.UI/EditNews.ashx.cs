using Nvelocity.BLL;
using Nvelocity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace 一般处理程序三层CRUD
{
    /// <summary>
    /// Summary description for EditNewsList
    /// </summary>
    public class EditNewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //=============================Show Add======================================
            if (context.Request["Action"] == "AddNew")
            {
                string addNew = File.ReadAllText(context.Request.MapPath("/Templates/EditNews.html"));
                addNew = addNew.Replace("@title", "").Replace("@people", "").Replace("@type", "").Replace("@date", "").Replace("@content", "");
                context.Response.Write(addNew);
            }

            //=============================Show Edit====================================
            else if (context.Request["Action"] == "Edit" && context.Request["id"] != null)
            {
                string id = context.Request["id"];
                int newsId = -1;
                int.TryParse(id, out newsId);

                HKSJ_Main newsEdit = new HKSJ_MainBLL().GetByID(newsId);

                string showEdit = File.ReadAllText(context.Request.MapPath("/Templates/EditNews.html"));
                showEdit = showEdit.Replace("@title", newsEdit.Title).Replace("@people", newsEdit.People).Replace("@type", newsEdit.Type).Replace("@date", newsEdit.Date.ToString()).Replace("@content", newsEdit.Content).Replace("@hId", newsId.ToString());
                context.Response.Write(showEdit);

            }

            //======================Save================================
            else
            {
                //context.Request["title"] != null && context.Request["date"] != null && context.Request["people"] != null && context.Request["content"] != null && context.Request["type"] != null

                string title = context.Request["title"];
                string date = context.Request["date"];
                string people = context.Request["people"];
                string content = context.Request["content"];
                string type = context.Request["type"];
                if (!Regex.IsMatch(type, @"\d{8}"))
                {
                    type = "00000000";
                }

                HKSJ_Main news = new HKSJ_Main();
                news.Title = title;
                DateTime today = DateTime.Now;
                DateTime.TryParse(date, out today);
                news.Date = today;
                news.People = people;
                news.Content = content;
                news.Type = type;

                HKSJ_MainBLL bll = new HKSJ_MainBLL();

                if (context.Request["id"] == null)   //新增保存
                {
                    bll.Add(news);
                }
                else //编辑保存
                {
                    string id = context.Request["id"];
                    int newsId = -1;
                    int.TryParse(id, out newsId);
                    news.ID = newsId;
                    bll.Update(news);
                }
                context.Response.Redirect("NewsList.ashx");
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