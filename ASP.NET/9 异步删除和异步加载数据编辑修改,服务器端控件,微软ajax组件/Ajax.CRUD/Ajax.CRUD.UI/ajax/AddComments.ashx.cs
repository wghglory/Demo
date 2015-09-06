using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ajax.CRUD.BLL;
using Ajax.CRUD.Model;
using System.Web.Script.Serialization;

namespace Ajax.CRUD.UI.ajax
{
    /// <summary>
    /// AddComments 的摘要说明
    /// </summary>
    public class AddComments : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //1.获取用户提交过来的数据
            string title = context.Request["title"];
            string content = context.Request["content"];
            string email = context.Request["email"];
            if (title != null && content != null && email != null)
            {
                //2.把用户提交过来的数据插入到数据库中。
                TblCommentsBll bll = new TblCommentsBll();
                TblComments model = new TblComments();
                model.Title = title;
                model.Content = content;
                model.Email = email;
                //此时返回值r,表示的是刚刚插入的这条记录的AutoId
                int r = bll.Add(model);



                var responseObject = new { IsOK = r > 0 ? "1" : "0", AutoId = r };
                JavaScriptSerializer jss = new JavaScriptSerializer();
                context.Response.Write(jss.Serialize(responseObject));

                ////3.根据数据库返回结果，响应用户。
                //if (r > 0)
                //{

                //    context.Response.Write("1");
                //}
                //else
                //{
                //    var responseObject = new { IsOK = "0", AutoId = r };
                //    context.Response.Write("0");
                //}
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